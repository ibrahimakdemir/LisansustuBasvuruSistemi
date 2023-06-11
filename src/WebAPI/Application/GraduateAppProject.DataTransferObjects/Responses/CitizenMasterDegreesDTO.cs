﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Responses
{
    public class CitizenMasterDegreesDTO
    {
        public int DepartmentId { get; set; }

        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int GradeType { get; set; }

        public decimal DegreeGrade { get; set; }

        public bool WithThesis { get; set; }

        public int LanguageId { get; set; }

        public string DiplomaUrl { get; set; } = null!;

        public string? TranscriptUrl { get; set; }
    }
}
