using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Requests
{
    public class CreateNewMailRequest
    {
        public bool IsRegistered { get; set; } //If user was not registered -> use the mail system to reply
        public int? SenderId { get; set; } // It can be null, if user was not registered
        public string? GuestFirstName { get; set; }
        public string? GuestLastName { get; set; }
        public string? GuestMailAddress { get; set; }
        public string Message { get; set; }
    }
}
