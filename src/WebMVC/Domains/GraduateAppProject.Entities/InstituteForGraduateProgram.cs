using GraduateAppProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Entities
{
    public class InstituteForGraduateProgram : IEntity
    {

        public int Id { get; set; }

        public string InstituteName { get; set; } = null!;

        public virtual ICollection<GraduateMajorForProgram> GraduateMajorForProgram { get; set; } = new List<GraduateMajorForProgram>();
    }
}
