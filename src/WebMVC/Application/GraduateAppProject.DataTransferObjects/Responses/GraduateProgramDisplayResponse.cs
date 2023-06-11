using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses
{
    public class GraduateProgramDisplayResponse
    {
        public int Id { get; set; }
        public int GraduateMajorId { get; set; }
        //public int InstituteId { get; set; }
        public int LanguageId { get; set; }
        public int Capacity { get; set; }
        public string Semester { get; set; }
        public int AcademicYear { get; set; }
    }
}
