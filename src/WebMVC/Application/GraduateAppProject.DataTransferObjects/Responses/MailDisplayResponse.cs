using GraduateAppProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses
{
    public class MailDisplayResponse
    {
        public int Id { get; set; }
        public bool IsRegistered { get; set; } //If user was not registered -> use the mail system to reply
        public int? SenderId { get; set; } // It can be null, if user was not registered
        public string? GuestFirstName { get; set; }
        public string? GuestLastName { get; set; }
        public string? GuestMailAddress { get; set; }
        public string Message { get; set; }
    }
}
