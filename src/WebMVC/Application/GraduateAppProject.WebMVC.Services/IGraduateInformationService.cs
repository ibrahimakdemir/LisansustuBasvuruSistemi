using GraduateAppProject.DataTransferObjects;
using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Services
{
    public interface IGraduateInformationService
    {
        public Task<GraduateProgramWithAllInfoModel> GetGraduateProgramInformationsModelAsync();
        public GraduateProgramWithAllInfoModel GetGraduateProgramInformationsModel();
        public Task<GraduateProgramWithAllInfoModel> GetGraduateProgramInformationsModelByProgramIdAsync(int id);
        public GraduateProgramWithAllInfoModel GetGraduateProgramInformationsModelByProgramId(int id);
        public Task<GraduateProgramWithAllInfoModel> GetGraduateProgramInformationsModelByProgramAsync(GraduateProgram program);
        public GraduateProgramWithAllInfoModel GetGraduateProgramInformationsModelByProgram(GraduateProgram program);
        IList<GraduateProgram> GetGraduateProgramWithInfo();
        Task<IList<GraduateProgram>> GetGraduateProgramWithInfoAsync();
        GraduateProgram GetGraduateProgramWithInfoByProgramId(int id);
        Task<GraduateProgram> GetGraduateProgramWithInfoByProgramIdAsync(int id);

        public IEnumerable<AnnouncementDisplayResponse> GetAnnouncementDisplayResponses();
        public Task<IEnumerable<AnnouncementDisplayResponse>> GetAnnouncementDisplayResponsesAsync();
        public IEnumerable<GraduateProgramDisplayResponse> GetGraduateProgramDisplayResponses();
        public Task<IEnumerable<GraduateProgramDisplayResponse>> GetGraduateProgramDisplayResponsesAsync();
        Task CreateNewGraduateProgramAsync(CreateNewGraduateProgramRequest request);
        Task<IList<GraduateMajorForProgram>> GetGraduateMajorsAsync();
        IList<GraduateMajorForProgram> GetGraduateMajors();
        Task<IList<Language>> GetLanguagesAsync();
        IList<Language> GetLanguages();
        Task<IList<OnlinePlatform>> GetPlatformsAsync();
        IList<OnlinePlatform> GetPlatforms();
        Task DeleteGraduateProgramByProgramIdAsync(int programId);
        Task<IList<UsersApplication>> GetApplicationByProgramIdAsync(int programId);
        Task EvaluateUserApplicationAsync(UsersApplication application);
        Task<IList<Reason>> GetReasonsAsync();
    }
}

