using System.ComponentModel.DataAnnotations;

namespace GraduateAppProject.MVC.Models
{
    public class UserRegisterModel
    {
        public int CitizenId { get; set; }
        public string CitizenNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz!")]
        public string Password { get; set; }
    }
}
