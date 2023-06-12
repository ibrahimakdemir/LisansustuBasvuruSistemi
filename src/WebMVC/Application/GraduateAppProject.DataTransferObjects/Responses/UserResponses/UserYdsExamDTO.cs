using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses.UserResponses
{
    public class UserYdsExamDTO
    {
        public int Id { get; set; }
        public string DocumentUrl { get; set; }

        public decimal YdsGrade { get; set; }

        public int Year { get; set; }
    }
}
