using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class OnlinePlatform : IEntity
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }

        public ICollection<GraduateProgram> GraduatePrograms { get; set; } = new HashSet<GraduateProgram>();

    }
}
