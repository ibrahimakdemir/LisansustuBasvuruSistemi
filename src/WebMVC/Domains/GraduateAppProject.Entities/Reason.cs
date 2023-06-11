using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class Reason : IEntity
    {
        public int Id { get; set; }
        public string ReasonName { get; set; }

        public ICollection<UsersApplication> UsersApplications { get; set; } = new HashSet<UsersApplication>();

    }
}
