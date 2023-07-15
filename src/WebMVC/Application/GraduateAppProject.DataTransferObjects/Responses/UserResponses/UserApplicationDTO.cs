using GraduateAppProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses.UserResponses
{
    public class UserApplicationDTO
    {
        public IList<GraduateProgram> GraduatePrograms { get; set; }
    }
}
