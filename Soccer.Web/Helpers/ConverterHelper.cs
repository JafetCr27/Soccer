namespace Soccer.Web.Helpers
{
    using Data.Entities;
    using Models;
    public class ConverterHelper : IConverterHelper
    {
        public Team ToTeam(TeamViewModel model, string path, bool isNew)
        {
            return new Team
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Nombre = model.Nombre
            };
        }

        public TeamViewModel ToTeamViewModel(Team team)
        {
            return new TeamViewModel
            {
                Id = team.Id,
                LogoPath = team.LogoPath,
                Nombre =  team.Nombre
            };
        }
    }
}
