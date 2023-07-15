using GraduateAppProject.MVC.Models;
using GraduateAppProject.WebMVC.Services;

namespace GraduateAppProject.MVC.Extensions
{
    public static class GetApplicantInformationsExtensions
    {
        public static async Task<ApplicantInformationsModel> GetApplicantInformationsModelAsync(int userId, IUserService _userService)
        {
            var citizenId = await _userService.GetCitizenIdByUserIdAsync(userId);
            var infoModel = new ApplicantInformationsModel()
            {
                UserContactInformationDTO = await _userService.GetUserContactInformationDTOByCitizenIdAsync(citizenId),
                UserIdentityInformationDTO = await _userService.GetUserIdentityInformationDTOByCitizenIdAsync(citizenId),
                UserAlesExamDTO = await _userService.GetUserAlesExamDTOByCitizenIdAsync(citizenId),
                UserBachelorDegreeDTO = await _userService.GetUserBachelorDegreeDTOByCitizenIdAsync(citizenId),
                UserDoctorateDegreeDTO = await _userService.GetUserDoctorateDegreeDTOByCitizenIdAsync(citizenId),
                UserMasterDegreeDTO = await _userService.GetUserMasterDegreeDTOByCitizenIdAsync(citizenId),
                UserYdsExamDTO = await _userService.GetUserYdsExamDTOByCitizenIdAsync(citizenId)
            };
            return infoModel;

        }
    }
}
