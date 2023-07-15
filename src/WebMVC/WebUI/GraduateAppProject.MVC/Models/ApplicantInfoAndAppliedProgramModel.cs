using GraduateAppProject.Entities;

namespace GraduateAppProject.MVC.Models
{
    public class ApplicantInfoAndAppliedProgramModel
    {
        public ApplicantInformationsModel ApplicantInformationsModel { get; set; }
        public GraduateProgram GraduateProgram { get; set; }
        public EvaluateApplicationModel EvaluateApplicationModel { get; set; }
    }
}
