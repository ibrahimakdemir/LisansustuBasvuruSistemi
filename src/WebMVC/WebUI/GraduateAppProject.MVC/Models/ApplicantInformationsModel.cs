using GraduateAppProject.DataTransferObjects.Responses.UserResponses;

namespace GraduateAppProject.MVC.Models
{
    public class ApplicantInformationsModel
    {
        public UserIdentityInformationDTO UserIdentityInformationDTO { get; set; }
        public IList<UserAlesExamDTO> UserAlesExamDTO { get; set; }
        public IList<UserBachelorDegreeDTO> UserBachelorDegreeDTO { get; set; }
        public IList<UserDoctorateDegreeDTO> UserDoctorateDegreeDTO { get; set; }
        public IList<UserMasterDegreeDTO> UserMasterDegreeDTO { get; set; }
        public IList<UserYdsExamDTO> UserYdsExamDTO { get; set; }
    }
}
