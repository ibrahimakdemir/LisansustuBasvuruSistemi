using GraduateAppProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Requests
{
    public class CreateNewApplicationRequest
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [ForeignKey(nameof(GraduateProgram))]
        public int GraduateProgramId { get; set; }

        [ForeignKey(nameof(ApplicationsState))]
        public int ApplicationStateId { get; set; }
        [ForeignKey(nameof(Reason))]
        public int ReasonId { get; set; }

        public bool IsConfirmedByApplicant { get; set; }
        public bool IsActive { get; set; }
        //[ForeignKey(nameof(Receipt))]
        //public int ReceiptId { get; set; } // If graduate program has the thesis, the receipt should upload

    }
}
