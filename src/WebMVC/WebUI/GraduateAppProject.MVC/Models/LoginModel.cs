using System.ComponentModel.DataAnnotations;

namespace GraduateAppProject.MVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Lütfen Kimlik Numaranızı Giriniz!")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage ="Kimlik Numarası 11 Haneli Olmalıdır!")]
        public long CitizenNumber { get; set; }
        [Required(ErrorMessage = "Hatalı Kimlik Numarası!")]
        public string Password { get; set; }
    }
}
