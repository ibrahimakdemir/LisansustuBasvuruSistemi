using AutoMapper;
using GraduateAppProject.DataTransferObjects;
using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Entities;
using GraduateAppProject.WebMVC.Repositories;
using GraduateAppProject.WebMVC.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Services
{
    public class GraduateInformationService : IGraduateInformationService
    {
        private readonly IGraduateInformationRepository _repository;
        private readonly IMapper _mapper;

        public GraduateInformationService(IGraduateInformationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public GraduateProgramWithAllInfoModel GetGraduateProgramInformationsModel()
        {
            throw new NotImplementedException();
        }

        public Task<GraduateProgramWithAllInfoModel> GetGraduateProgramInformationsModelAsync()
        {
            throw new NotImplementedException();
        }

        public GraduateProgramWithAllInfoModel GetGraduateProgramInformationsModelByProgram(GraduateProgram program)
        {
            var major = _repository.GetGraduateMajorForProgramById(program.GraduateMajorId);
            var institute = _repository.GetInstituteForGraduateProgramById(major.InstituteForGraduateProgramId);
            var language = _repository.GetLanguageById(program.LanguageId);
            var model = new GraduateProgramWithAllInfoModel()
            {
                GraduateProgram = program,
                GraduateMajorForProgram = major,
                InstituteForGraduateProgram = institute,
                Language = language
            };
            return model;
        }

        public Task<GraduateProgramWithAllInfoModel> GetGraduateProgramInformationsModelByProgramAsync(GraduateProgram program)
        {
            throw new NotImplementedException();
        }

        public GraduateProgramWithAllInfoModel GetGraduateProgramInformationsModelByProgramId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GraduateProgramWithAllInfoModel> GetGraduateProgramInformationsModelByProgramIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       

        public IEnumerable<AnnouncementDisplayResponse> GetAnnouncementDisplayResponses()
        {
            var announcements = _repository.GetAnnouncements();
            var response = announcements.ConvertToDisplayResponsesForAnnouncement(_mapper);
            return response;
        }

        public async Task<IEnumerable<AnnouncementDisplayResponse>> GetAnnouncementDisplayResponsesAsync()
        {
            var announcements = await _repository.GetAnnouncementsAsync();
            var response = announcements.ConvertToDisplayResponsesForAnnouncement(_mapper);
            return response;
        }
        public IList<GraduateProgram> GetGraduateProgramWithInfo()
        {
            return _repository.GetGraduateProgramWithAllInfo();
        }

        public IEnumerable<GraduateProgramDisplayResponse> GetGraduateProgramDisplayResponses()
        {
            var graduatePrograms = _repository.GetGraduatePrograms();
            var response = graduatePrograms.ConvertToDisplayResponsesForGraduatePrograms(_mapper);
            return response;
        }

        public async Task<IEnumerable<GraduateProgramDisplayResponse>> GetGraduateProgramDisplayResponsesAsync()
        {
            var graduatePrograms = await _repository.GetGraduateProgramsAsync();
            var response = graduatePrograms.ConvertToDisplayResponsesForGraduatePrograms(_mapper);

            return response;
        }

        public async Task CreateNewGraduateProgramAsync(CreateNewGraduateProgramRequest request)
        {
            request.IsActive = true;
            var graduateProgram = request.ConvertToDTO<CreateNewGraduateProgramRequest, GraduateProgram>(_mapper);
            await _repository.CreateAsync(graduateProgram);
        }

        public async Task<IList<GraduateMajorForProgram>> GetGraduateMajorsAsync()
        {
            return await _repository.GetGraduateMajorForProgramsAsync();
        }
        public IList<GraduateMajorForProgram> GetGraduateMajors()
        {
            return _repository.GetGraduateMajorForPrograms();
        }
        public async Task<IList<Language>> GetLanguagesAsync()
        {
            return await _repository.GetLanguageAsync();
        }
        public IList<Language> GetLanguages()
        {
            return _repository.GetLanguages();
        }
        public async Task<IList<OnlinePlatform>> GetPlatformsAsync()
        {
            return await _repository.GetOnlinePlatformAsync();
        }
        public IList<OnlinePlatform> GetPlatforms()
        {
            return _repository.GetOnlinePlatforms();
        }
    }
}
