using GraduateAppProject.Entities;

namespace GraduateAppProject.MVC.Models
{
    public class UserApplicationsWithStateAndReasonModel
    {
        public GraduateProgram  GraduateProgram { get; set; }
        public int ReasonId { get; set; }
        public int StateId { get; set;}
    }
}
