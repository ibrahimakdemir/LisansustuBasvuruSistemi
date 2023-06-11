using GraduateAppProject.WebMVC.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateAppProject.Entities
{
    public class GraduateProgram : IEntity
    {
        public int Id { get; set; }
        public int GraduateMajorId { get; set; }
        public bool WithThesis { get; set; }
        public int LanguageId { get; set; }
        public bool HasExamRequirement { get; set; }
        public bool HasMajorRequirement { get; set; }
        public DateTime InterviewDate { get; set; }
        public bool IsInterviewRemote { get; set; }
        public int? OnlinePlatformId { get; set; }
        public string? InterviewPlace { get; set; }
        public int Capacity { get; set; }
        public string Semester { get; set; }
        public int AcademicYear { get; set; }
        public bool IsActive { get; set; }
        public string? Detail { get; set; }
        [ForeignKey(nameof(Admin))]
        public int? OpenedById { get; set; }

        public GraduateMajorForProgram GraduateMajor { get; set; }
        public Language Language { get; set; }
        public OnlinePlatform OnlinePlatform { get; set; }
        public User Admin { get; set; }
        [NotMapped]
        public ICollection<RequiredMajor> RequiredMajors { get; set; } = new HashSet<RequiredMajor>();
    }
}
