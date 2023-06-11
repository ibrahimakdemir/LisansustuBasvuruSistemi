using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class UsersApplication : IEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(GraduateProgram))]
        public int GraduateProgramId { get; set; }
        //[ForeignKey(nameof(LogInformation))]
        //public int LogInformationId { get; set; }
        [ForeignKey(nameof(ApplicationsState))]
        public int ApplicationStateId { get; set; }
        [ForeignKey(nameof(Reason))]
        public int ReasonId { get; set; }
        //[ForeignKey(nameof(Admin))]
        //public int AdminId { get; set; }
        public bool IsConfirmedByApplicant { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(Receipt))]
        public int ReceiptId { get; set; } // If graduate program has the thesis, the receipt should upload

        public User User { get; set; }
        public GraduateProgram GraduateProgram { get; set; }
        //public LogInformation LogInformation { get; set; }
        public ApplicationsState ApplicationsState { get; set; }
        public Reason Reason { get; set; }
        //public User Admin { get; set; }
        public Receipt Receipt { get; set; }
    }
}
