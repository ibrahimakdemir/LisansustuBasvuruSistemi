using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects
{
    public class GraduateProgramWithAllInfoModel
    {
        public GraduateProgram GraduateProgram { get; set; }
        public GraduateMajorForProgram GraduateMajorForProgram { get; set; }
        public InstituteForGraduateProgram InstituteForGraduateProgram { get; set; }
        public Language Language { get; set; }
    }
}
