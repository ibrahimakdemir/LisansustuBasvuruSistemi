using System.ComponentModel.DataAnnotations;

namespace GraduateAppProject.MVC.Models
{
    public class CitizenCheckerModel
    {
        [Required(ErrorMessage ="Adınızı Giriniz!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyadınızı Giriniz!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Lütfen Kimlik Numaranızı Giriniz!")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Kimlik Numarası 11 Haneli Olmalıdır!")]
        public string CitizenNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Doğum Yılınızı Giriniz!")]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Doğum Yılınızı Giriniz!")]
        public int BirthYear { get; set; }


    }
}
