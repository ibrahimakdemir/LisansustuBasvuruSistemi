using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class AlesExamsRequirement : IEntity
    {
        public int Id { get; set; }
        public int AlesGrade { get; set; }
        public int AlesSayisalGrade { get; set; }
        public int AlesSozelGrade { get; set; }
        public int AlesEsitAgirlikGrade { get; set; }
        [ForeignKey(nameof(GraduateProgram))]
        public int GraduateProgramId { get; set; }

        public GraduateProgram GraduateProgram { get; set; }
    }
}
