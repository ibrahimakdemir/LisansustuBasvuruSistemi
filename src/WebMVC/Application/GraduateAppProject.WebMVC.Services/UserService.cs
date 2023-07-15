using AutoMapper;
using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses.UserResponses;
using GraduateAppProject.Entities;
using GraduateAppProject.Infrastructure.Models;
using GraduateAppProject.WebMVC.Repositories;
using GraduateAppProject.WebMVC.Services.Extensions;

namespace GraduateAppProject.WebMVC.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly IGraduateInformationService _graduateService;

        public UserService(IUserRepository userRepository, IMapper mapper, HttpClient httpClient, IGraduateInformationService graduateInformationService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpClient = httpClient;
            _graduateService = graduateInformationService;
        }

        public int? CheckUser(string citizenNumber, string password)
        {
            var user = _userRepository.GetByCitizenNumber(citizenNumber);
            
            if (user!= null && user.Password == password)
            {
                return user.CitizenId;
            }
            return 0;
        }

        public async Task<int> CheckUserAsync(string citizenNumber, string password)
        {
            var user = await _userRepository.GetByCitizenNumberAsync(citizenNumber);

            if (user != null && user.Password == password)
            {
                return user.CitizenId;
            }
            return 0;
        }

        public async Task<IList<UserAlesExamDTO>> GetUserAlesExamDTOByCitizenIdAsync(int citizenId)
        {
            string endPoint = $"GetAlesExamsByCitizenId?id={citizenId}";
            var userAlesExamDTO = await _httpClient.GetApiResponse<IList<UserAlesExamDTO>>(endPoint);           
            return userAlesExamDTO;
        }

        public async Task<IList<UserBachelorDegreeDTO>> GetUserBachelorDegreeDTOByCitizenIdAsync(int citizenId)
        {
            string endPoint = $"GetBachelorDegreesByCitizenId?id={citizenId}";
            var userBachelorDegreeDTO = await _httpClient.GetApiResponse<IList<UserBachelorDegreeDTO>>(endPoint);
            return userBachelorDegreeDTO;
        }

        public async Task<IList<UserDoctorateDegreeDTO>> GetUserDoctorateDegreeDTOByCitizenIdAsync(int citizenId)
        {
            string endPoint = $"GetDoctorateDegreesByCitizenId?id={citizenId}";
            var userDoctorateDegreeDTO = await _httpClient.GetApiResponse<IList<UserDoctorateDegreeDTO>>(endPoint);
            return userDoctorateDegreeDTO;
        }

        public async Task<UserIdentityInformationDTO> GetUserIdentityInformationDTOByCitizenIdAsync(int citizenId)
        {
            string endPoint = $"GetIdentityInformationsByCitizenId?id={citizenId}";
            var userIdentityInformationDTO = await _httpClient.GetApiResponse<UserIdentityInformationDTO>(endPoint);
            var user = await _userRepository.GetUserByCitizenIdAsync(citizenId);
            
            if (user != null)
            {
                userIdentityInformationDTO.PhotoURL = user.PhotoUrl;
                userIdentityInformationDTO.Id = user.Id;
            }
                

            return userIdentityInformationDTO;
        }
        public async Task<IList<UserMasterDegreeDTO>> GetUserMasterDegreeDTOByCitizenIdAsync(int citizenId)
        {
            string endPoint = $"GetMasterDegreesByCitizenId?id={citizenId}";
            var userMasterDegreeDTO = await _httpClient.GetApiResponse<IList<UserMasterDegreeDTO>>(endPoint);
            return userMasterDegreeDTO;
        }

        public async Task<IList<UserYdsExamDTO>> GetUserYdsExamDTOByCitizenIdAsync(int citizenId)
        {
            string endPoint = $"GetYdsExamsByCitizenId?id={citizenId}";
            var userYdsExamsDTO = await _httpClient.GetApiResponse<IList<UserYdsExamDTO>>(endPoint);
            return userYdsExamsDTO;
        }

        public string GetUserRoleByCitizenId(int citizenId)
        {
            var userId = _userRepository.GetUserIdByCitizenId(citizenId);
            var userRole = _userRepository.GetUserRoleByUserId(userId);
            return userRole;
        }

        public async Task<string> GetUserRoleByCitizenIdAsync(int citizenId)
        {
            var userId = await _userRepository.GetUserIdByCitizenIdAsync(citizenId);
            var userRole = await _userRepository.GetUserRoleByUserIdAsync(userId);
            return userRole;
        }        

        public bool IsRegistered(int citizenId)
        {
            return _userRepository.IsRegistered(citizenId);
        }

        public async Task<bool> IsRegisteredAsync(int citizenId)
        {
            return await _userRepository.IsRegisteredAsync(citizenId);
        }

        public void RegisterUser(CreateNewUserRequest request)
        {
            var response = _mapper.Map<User>(request);
            _userRepository.Create(response);
        }

        public async Task RegisterUserAsync(CreateNewUserRequest request)
        {
            var response = _mapper.Map<User>(request);
            await _userRepository.CreateAsync(response);
        }

        public int GetUserIdByCitizenId(int citizenId)
        {
            var user = _userRepository.GetUserByCitizenId(citizenId);
            return user.Id;
        }

        public async Task<int> GetUserIdByCitizenIdAsync(int citizenId)
        {
            var user = await _userRepository.GetUserByCitizenIdAsync(citizenId);
            return user.Id;
        }

        public int GetCitizenIdByUserId(int userId)
        {
            return _userRepository.GetCitizenIdByUserId(userId);
        }

        public Task<int> GetCitizenIdByUserIdAsync(int userId)
        {
            return _userRepository.GetCitizenIdByUserIdAsync(userId);
        }

        public async Task<UserContactInformationDTO> GetUserContactInformationDTOByCitizenIdAsync(int citizenId)
        {
            var user = await _userRepository.GetUserByCitizenIdAsync(citizenId);
            var response = user.ConvertToDTO<User, UserContactInformationDTO>(_mapper);
            return response;
        }

        public async Task UpdateUserContactInformationsByUserIdAsync(int userId, string mailAdress, string phoneNumber, string address)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user != null)
            {
                user.Address = address;
                user.Email = mailAdress;
                user.PhoneNumber = phoneNumber;
                await _userRepository.UpdateAsync(user);
            }
        }

        public async Task UpdateUserPhotoURLByUserIdAsync(int userId, string filePath)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user != null)
            {
                user.PhotoUrl = filePath;
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task<IList<GraduateProgram>> GetUserApplicationProgramByUserIdAsync(int userId)
        {
            var graduatePrograms = new List<GraduateProgram>();
            var userApplications =await  _userRepository.GetUserApplicationsByUserIdAsync(userId);

            
            foreach (var application in userApplications)
            {
                var program = await _graduateService.GetGraduateProgramWithInfoByProgramIdAsync(application.GraduateProgramId);
                graduatePrograms.Add(program);
            }
            return graduatePrograms;
        }

        public async Task ApplyToProgramAsync(int userId, int programId)
        {
            await _userRepository.ApplyToGraduateProgramAsync(userId,programId);
        }
    }
}
