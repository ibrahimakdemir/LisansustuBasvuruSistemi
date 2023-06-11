using GraduateAppProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Entities
{
    public class GraduateMajorForProgram : IEntity
    {
        public int Id { get; set; }

        public string GraduateMajorName { get; set; } = null!;

        public int InstituteForGraduateProgramId { get; set; }

        //public virtual ICollection<GraduateProgram> GraduatePrograms { get; set; } = new List<GraduateProgram>();
        public virtual ICollection<RequiredMajor> RequiredMajor { get; set; } = new List<RequiredMajor>();
        public virtual InstituteForGraduateProgram InstituteForGraduateProgram { get; set; } = null!;
    }
}
