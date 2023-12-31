﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses.UserResponses
{
    public class UserIdentityInformationDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string CitizenNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }
        public string? PhotoURL { get; set; }

    }
}
