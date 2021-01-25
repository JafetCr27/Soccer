namespace Soccer.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using Data.Entities;
    using System.ComponentModel.DataAnnotations;
    public class TeamViewModel : Team
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
