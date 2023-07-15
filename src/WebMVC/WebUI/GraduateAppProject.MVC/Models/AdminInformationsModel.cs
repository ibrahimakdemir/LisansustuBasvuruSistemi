using GraduateAppProject.DataTransferObjects.Responses.UserResponses;

namespace GraduateAppProject.MVC.Models
{
    public class AdminInformationsModel
    {
        public UserIdentityInformationDTO? UserIdentityInformationDTO { get; set; }
        public UserContactInformationDTO? UserContactInformationDTO { get; set; }
    }
}
