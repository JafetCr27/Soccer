
using Soccer.Web.Helpers;
using Soccer.Web.Models;

namespace Soccer.Web.Controllers
{
    using Data;
    using Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeamsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public TeamsController(DataContext context,
                                IImageHelper imageHelper,
                                IConverterHelper converterHelper)
        {
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamViewModel team)
        {
            if (!ModelState.IsValid) return View(team);
            try
            {
                var path = string.Empty;
                if (team.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(team.LogoFile, "Teams");
                }
                var teamEntity = _converterHelper.ToTeam(team, path, true);
                _context.Add(teamEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                if (e.InnerException != null && e.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "No se puede el equipo " + team.Nombre + " verifique que el registro no se encuentre duplicado");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }
            return View(team);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            var teamViewModel = _converterHelper.ToTeamViewModel(team);
            return View(teamViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamViewModel teamViewModel)
        {
            if (id != teamViewModel.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid) return View(teamViewModel);
            var path = teamViewModel.LogoPath;
            if (teamViewModel.LogoFile != null)
            {
                path = await _imageHelper.UploadImageAsync(teamViewModel.LogoFile, "Teams");
            }
            var teamEntity = _converterHelper.ToTeam(teamViewModel, path, false);
            _context.Update(teamEntity);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,
                    e.InnerException != null && e.InnerException.Message.Contains("duplicate")
                        ? $"No se puede registrar el equipo: {teamViewModel.Nombre} verifique que el registro no se encuentre duplicado"
                        : e.Message);
            }
            return View(teamViewModel);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
