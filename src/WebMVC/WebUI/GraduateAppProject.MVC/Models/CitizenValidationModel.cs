using System.ComponentModel.DataAnnotations;

namespace GraduateAppProject.MVC.Models
{
    public class CitizenValidationModel
    {
        [Required]
        public string citizenNumber { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public int birthYear { get; set; }
    }
}
