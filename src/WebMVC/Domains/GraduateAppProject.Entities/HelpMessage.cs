using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class HelpMessage : IEntity
    {
        public int Id { get; set; }
        public bool IsRegistered { get; set; } //If user was not registered -> use the mail system to reply
        [ForeignKey(nameof(Sender))]
        public int? SenderId { get; set; } // It can be null, if user was not registered
        //[ForeignKey(nameof(Receiver))]
        //public int ReceiverId { get; set; }
        [ForeignKey(nameof(GraduateProgram))]
        public int GraduateProgramId { get; set; } // Which program is the message about?

        public string? GuestFirstName { get; set; }
        public string? GuestLastName { get; set; }
        public string? GuestMailAddress { get; set; }

        public string Message { get; set; }

        public bool IsRead { get; set; }

        public User Sender { get; set; }
        //public User Receiver { get; set; }
        public GraduateProgram GraduateProgram { get; set; }
    }
}
