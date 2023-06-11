using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses.UserResponses
{
    public class UserYdsExamDTO
    {
        public string DocumentUrl { get; set; } = null!;

        public decimal YdsGrade { get; set; }

        public int Year { get; set; }
    }
}
