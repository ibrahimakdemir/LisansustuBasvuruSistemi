using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        // 1- Admin
        // 2- Applicant
        // 3- Department Authority
        public ICollection<UsersRole> UsersRoles { get; set; } = new HashSet<UsersRole>();

    }
}
