using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class YdsExamsRequirement : IEntity
    {
        public int Id { get; set; }
        public int YdsGrade { get; set; }
        [ForeignKey(nameof(GraduateProgram))]
        public int GraduateProgramId { get; set; }

        public GraduateProgram GraduateProgram { get; set; }
    }
}
