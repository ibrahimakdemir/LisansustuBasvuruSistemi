using GraduateAppProject.Infrastructure.Models;

namespace GraduateAppProject.DataTransferObjects.Responses
{
    public class CitizenIdentityInformationsDTO
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public string MotherName { get; set; } = null!;

        public string CitizenNumber { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; } = null!;
    }
}
