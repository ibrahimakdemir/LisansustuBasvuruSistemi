using GraduateAppProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects
{
    public class CitizenInformationsModel
    {
        public Citizen Citizen { get; set; }
        public IList<AlesExam> AlesExam { get; set; }
        public IList<BachelorDegree> BachelorDegree { get; set; }
        public IList<DoctorateDegree> DoctorateDegree { get; set; }
        public IList<MasterDegree> MasterDegree { get; set; }
        public IList<YdsExam> YdsExam { get; set; }
    }
}
