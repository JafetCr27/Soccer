using System.ComponentModel.DataAnnotations;
namespace Soccer.Web.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "El campo {0} no permite mas de {1} caracteres.")]
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Logo")]
        public string LogoPath { get; set; }
    }
}
