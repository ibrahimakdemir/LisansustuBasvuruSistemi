using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class UsersLogin : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string IpAddress { get; set; }
        public DateTime Date { get; set; }
        public string? BrowserInfo { get; set; }
        public string? MachineInfo { get; set; }


        public User User { get; set; }
    }
}
