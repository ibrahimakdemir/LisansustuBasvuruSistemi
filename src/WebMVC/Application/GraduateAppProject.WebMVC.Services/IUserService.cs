using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.DataTransferObjects.Responses.UserResponses;
using GraduateAppProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        int GetUserIdByCitizenId(int citizenId);
        Task<int> GetUserIdByCitizenIdAsync(int citizenId);
        int GetCitizenIdByUserId(int userId);
        Task<int> GetCitizenIdByUserIdAsync(int userId);


        Task<IList<UserAlesExamDTO>> GetUserAlesExamDTOByCitizenIdAsync(int citizenId);
        Task<IList<UserBachelorDegreeDTO>> GetUserBachelorDegreeDTOByCitizenIdAsync(int citizenId);
        Task<IList<UserDoctorateDegreeDTO>> GetUserDoctorateDegreeDTOByCitizenIdAsync(int citizenId);
        Task<UserIdentityInformationDTO> GetUserIdentityInformationDTOByCitizenIdAsync(int citizenId);
        Task<IList<UserMasterDegreeDTO>> GetUserMasterDegreeDTOByCitizenIdAsync(int citizenId);
        Task<IList<UserYdsExamDTO>> GetUserYdsExamDTOByCitizenIdAsync(int citizenId);
        Task<UserContactInformationDTO> GetUserContactInformationDTOByCitizenIdAsync(int citizenId);
        Task UpdateUserContactInformationsByUserIdAsync(int userId, string mailAdress, string phoneNumber, string address);
        Task UpdateUserPhotoURLByUserIdAsync(int userId, string filePath);
        Task<IList<GraduateProgram>> GetUserApplicationProgramByUserIdAsync(int userId);
        Task ApplyToProgramAsync(int userId, int programId);
    }
}
