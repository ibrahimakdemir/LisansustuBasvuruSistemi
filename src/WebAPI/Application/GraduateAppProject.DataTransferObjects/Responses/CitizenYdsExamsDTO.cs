using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses
{
    public class CitizenYdsExamsDTO
    {
        public string DocumentUrl { get; set; } = null!;

        public decimal YdsGrade { get; set; }

        public int Year { get; set; }
    }
}
