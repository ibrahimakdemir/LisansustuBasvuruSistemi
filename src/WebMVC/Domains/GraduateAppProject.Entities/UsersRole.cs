using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class UsersRole : IEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        [ForeignKey(nameof(GraduateProgram))]
        public int GraduateProgramId { get; set; }
        public bool IsActive { get; set; }
        //[ForeignKey(nameof(Admin))]
        //public int RoleGivenBy { get; set; } // Which admin gave this role? -> AdminId


        public User User { get; set; }
        //public User Admin { get; set; }
        public Role Role { get; set; }
        public GraduateProgram GraduateProgram { get; set; }
    }
}
