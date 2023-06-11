using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.DataTransferObjects.Requests
{
    public class CreateNewGraduateProgramRequest
    {
        [Required]
        public int GraduateMajorId { get; set; }
        [Required]
        public bool WithThesis { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public bool HasExamRequirement { get; set; }
        [Required]
        public bool HasMajorRequirement { get; set; }
        [Required]
        public DateTime InterviewDate { get; set; }
        [Required]
        public bool IsInterviewRemote { get; set; }
        public int? OnlinePlatformId { get; set; }
        public string? InterviewPlace { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string Semester { get; set; }
        [Required]
        public int AcademicYear { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public string? Detail { get; set; }
        
    }
}
