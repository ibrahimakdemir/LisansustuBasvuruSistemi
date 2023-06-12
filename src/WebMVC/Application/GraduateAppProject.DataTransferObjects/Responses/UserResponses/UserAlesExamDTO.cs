using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses.UserResponses
{
    public class UserAlesExamDTO
    {
        public int Id { get; set; }
        public string DocumentUrl { get; set; }

        public decimal AlesSayisalGrade { get; set; }

        public decimal AlesEsitAgirlikGrade { get; set; }

        public decimal AlesSozelGrade { get; set; }

        public int Year { get; set; }
    }
}
