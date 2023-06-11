using GraduateAppProject.WebMVC.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateAppProject.Entities
{
    public class RequiredMajor: IEntity
    {
        //[ForeignKey(nameof(GraduateProgramId))]
        public int GraduateProgramId { get; set; }
        //[ForeignKey(nameof(GraduateMajorForProgramId))]
        public int GraduateMajorForProgramId { get; set; }


        public GraduateProgram GraduateProgram { get; set; }
        public GraduateMajorForProgram GraduateMajorForProgram { get; set; }
    }
}
