using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses.UserResponses
{
    public class UserDoctorateDegreeDTO
    {
        public int Id { get; set; }
        public int GraduateMajorId { get; set; }

        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string DiplomaUrl { get; set; }

        public int LanguageId { get; set; }
    }
}
