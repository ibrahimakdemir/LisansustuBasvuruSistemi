using GraduateAppProject.MVC.Models;

namespace GraduateAppProject.MVC.CacheTools
{
    public class CacheDataInfoForApplicantPages
    {
        public ApplicantInformationsModel ApplicantInformationsModel { get; set; }
        // UserLandingPageModel contains applicant's infos(Yds, Ales, Master, Bachelor, Doctorate)
        public DateTime CacheTime { get; set; }

    }
}
