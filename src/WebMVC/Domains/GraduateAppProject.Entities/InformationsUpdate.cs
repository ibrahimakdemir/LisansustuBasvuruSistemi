using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Entities
{
    public class InformationsUpdate : IEntity
    {
        public int Id { get; set; }
        public bool ModifiedByOwn { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; } // Which user's information was updated?
        //[ForeignKey(nameof(Admin))]
        //public int? AdminId { get; set; } // Which user made this update?
        public string ModifiedInfo { get; set; }
        public string BeforeModify { get; set; }
        public string AfterModify { get; set; }

        public User User { get; set; }
        //public User Admin { get; set; }
    }
}
