using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses
{
    public class CitizenAlesExamsDTO
    {
        public string DocumentUrl { get; set; } = null!;

        public decimal AlesSayisalGrade { get; set; }

        public decimal AlesEsitAgirlikGrade { get; set; }

        public decimal AlesSozelGrade { get; set; }

        public int Year { get; set; }
    }
}
