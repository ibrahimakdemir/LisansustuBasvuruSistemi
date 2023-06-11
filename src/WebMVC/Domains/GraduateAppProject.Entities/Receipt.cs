using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class Receipt: IEntity
    {
        public int Id { get; set; }
        public string ReceiptURL { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UsersApplication> UsersApplications { get; set; } = new HashSet<UsersApplication>();

    }
}
