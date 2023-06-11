using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.DataTransferObjects.Responses.UserResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Services
{
    public interface IUserService
    {
        //Burada mvc de lazım olan servisler yazılacaktır. Örneğin GetUserDisplayResponse,
        //burada sadece kullanıcının bilgilerini anasayfada sol panelde göstermek ve
        //bilgi güncelleme sayfasında gösterilecek ama hiçbiri güncelleyemez,
        //sadece mail, tel, password ... gibi sisteme ile ilgili bilgileri güncelleyebilir.
        int? CheckUser(string citizenNumber, string password);
        Task<int> CheckUserAsync(string citizenNumber, string password);
        bool IsRegistered(int citizenId);
        Task<bool> IsRegisteredAsync(int citizenId);
        void RegisterUser(CreateNewUserRequest request);
        Task RegisterUserAsync(CreateNewUserRequest request);

        string GetUserRoleByCitizenId(int citizenId);
        Task<string> GetUserRoleByCitizenIdAsync(int citizenId);



        IList<UserAlesExamDTO> GetUserAlesExamDTOByCitizenId(int citizenId);
        Task<IList<UserAlesExamDTO>> GetUserAlesExamDTOByCitizenIdAsync(int citizenId);
        IList<UserBachelorDegreeDTO> GetUserBachelorDegreeDTOByCitizenId(int citizenId);
        Task<IList<UserBachelorDegreeDTO>> GetUserBachelorDegreeDTOByCitizenIdAsync(int citizenId);
        IList<UserDoctorateDegreeDTO> GetUserDoctorateDegreeDTOByCitizenId(int citizenId);
        Task<IList<UserDoctorateDegreeDTO>> GetUserDoctorateDegreeDTOByCitizenIdAsync(int citizenId);
        UserIdentityInformationDTO GetUserIdentityInformationDTOByCitizenId(int citizenId);
        Task<UserIdentityInformationDTO> GetUserIdentityInformationDTOByCitizenIdAsync(int citizenId);
        IList<UserMasterDegreeDTO> GetUserMasterDegreeDTOByCitizenId(int citizenId);
        Task<IList<UserMasterDegreeDTO>> GetUserMasterDegreeDTOByCitizenIdAsync(int citizenId);
        IList<UserYdsExamDTO> GetUserYdsExamDTOByCitizenId(int citizenId);
        Task<IList<UserYdsExamDTO>> GetUserYdsExamDTOByCitizenIdAsync(int citizenId);
    }
}
