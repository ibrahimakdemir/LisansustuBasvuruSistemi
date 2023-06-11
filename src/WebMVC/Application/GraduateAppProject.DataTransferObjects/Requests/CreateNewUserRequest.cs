using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Requests
{
    public class CreateNewUserRequest
    {
        public int? CitizenId { get; set; }
        public string CitizenNumber { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? PhotoUrl { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
