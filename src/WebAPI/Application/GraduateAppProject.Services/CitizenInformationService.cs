using AutoMapper;
using GraduateAppProject.DataTransferObjects;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Infrastructure.Models;
using GraduateAppProject.Repositories;
using GraduateAppProject.Services.Extensions;

namespace GraduateAppProject.Services
{
    public class CitizenInformationService : ICitizenInformationService
    {
        private readonly ICitizenInformationRepository _repository;
        private readonly ICitizenRepository _citizenRepository;
        private readonly IMapper _mapper;
        public CitizenInformationService(ICitizenInformationRepository repository, ICitizenRepository citizenRepository, IMapper mapper)
        {
            _repository = repository;
            _citizenRepository = citizenRepository;
            _mapper = mapper;
        }

        public IList<CitizenAlesExamsDTO> GetCitizenAlesExamsDTOByCitizenId(int citizenId)
        {
            var alesExams = _repository.GetAlesExamByCitizenId(citizenId);
            var response = alesExams.ConvertToDTO<IList<AlesExam>, IList<CitizenAlesExamsDTO>>(_mapper);
            return response;
        }

        public async Task<IList<CitizenAlesExamsDTO>> GetCitizenAlesExamsDTOByCitizenIdAsync(int citizenId)
        {
            var alesExams = await _repository.GetAlesExamByCitizenIdAsync(citizenId);
            var response = alesExams.ConvertToDTO< IList<AlesExam>, IList< CitizenAlesExamsDTO>>(_mapper);
            return response;
        }

        public IList<CitizenBachelorDegreesDTO> GetCitizenBachelorDegreesDTOByCitizenId(int citizenId)
        {
            var bachelorDegrees = _repository.GetBachelorDegreeByCitizenId(citizenId);
            var response = bachelorDegrees.ConvertToDTO<IList<BachelorDegree>, IList<CitizenBachelorDegreesDTO>>(_mapper);
            return response;
        }

        public async Task<IList<CitizenBachelorDegreesDTO>> GetCitizenBachelorDegreesDTOByCitizenIdAsync(int citizenId)
        {
            var bachelorDegrees = await _repository.GetBachelorDegreeByCitizenIdAsync(citizenId);
            var response = bachelorDegrees.ConvertToDTO<IList<BachelorDegree>, IList<CitizenBachelorDegreesDTO>>(_mapper);
            return response;
        }

        public IList<CitizenDoctorateDegreesDTO> GetCitizenDoctorateDegreesDTOByCitizenId(int citizenId)
        {
            var doctorateDegrees = _repository.GetDoctorateDegreeByCitizenId(citizenId);
            var response = doctorateDegrees.ConvertToDTO<IList<DoctorateDegree>, IList<CitizenDoctorateDegreesDTO>>(_mapper);
            return response;
        }

        public async Task<IList<CitizenDoctorateDegreesDTO>> GetCitizenDoctorateDegreesDTOByCitizenIdAsync(int citizenId)
        {
            var doctorateDegrees = await _repository.GetDoctorateDegreeByCitizenIdAsync(citizenId);
            var response = doctorateDegrees.ConvertToDTO<IList<DoctorateDegree>, IList<CitizenDoctorateDegreesDTO>>(_mapper);
            return response;
        }

        public CitizenIdentityInformationsDTO GetCitizenIdentityInformationsDTOByCitizenId(int citizenId)
        {
            var citizenInfo = _citizenRepository.Get(citizenId);
            var response = citizenInfo.ConvertToDTO<Citizen, CitizenIdentityInformationsDTO>(_mapper);
            return response;
        }

        public async Task<CitizenIdentityInformationsDTO> GetCitizenIdentityInformationsDTOByCitizenIdAsync(int citizenId)
        {
            var citizenInfo = await _citizenRepository.GetAsync(citizenId);
            var response = citizenInfo.ConvertToDTO<Citizen, CitizenIdentityInformationsDTO>(_mapper);
            return response;
        }

        public CitizenInformationsModel GetCitizenInformationsModelByCitizenId(int citizenId)
        {
            var model = new CitizenInformationsModel()
            {
                Citizen = _citizenRepository.Get(citizenId),
                AlesExam = _repository.GetAlesExamByCitizenId(citizenId),
                BachelorDegree = _repository.GetBachelorDegreeByCitizenId(citizenId),
                DoctorateDegree = _repository.GetDoctorateDegreeByCitizenId(citizenId),
                MasterDegree = _repository.GetMasterDegreeByCitizenId(citizenId),
                YdsExam = _repository.GetYdsExamByCitizenId(citizenId),
            };

            return model;
        }

        public async Task<CitizenInformationsModel> GetCitizenInformationsModelByCitizenIdAsync(int citizenId)
        {
            var model = new CitizenInformationsModel()
            {
                Citizen = await _citizenRepository.GetAsync(citizenId),
                AlesExam = await _repository.GetAlesExamByCitizenIdAsync(citizenId),
                BachelorDegree = await _repository.GetBachelorDegreeByCitizenIdAsync(citizenId),
                DoctorateDegree = await _repository.GetDoctorateDegreeByCitizenIdAsync(citizenId),
                MasterDegree = await _repository.GetMasterDegreeByCitizenIdAsync(citizenId),
                YdsExam = await _repository.GetYdsExamByCitizenIdAsync(citizenId),
            };

            return model;
        }

        public IList<CitizenMasterDegreesDTO> GetCitizenMasterDegreesDTOByCitizenId(int citizenId)
        {
            var masterDegrees = _repository.GetMasterDegreeByCitizenId(citizenId);
            var response = masterDegrees.ConvertToDTO<IList<MasterDegree>, IList<CitizenMasterDegreesDTO>>(_mapper);
            return response;
        }

        public async Task<IList<CitizenMasterDegreesDTO>> GetCitizenMasterDegreesDTOByCitizenIdAsync(int citizenId)
        {
            var masterDegrees = await _repository.GetMasterDegreeByCitizenIdAsync(citizenId);
            var response = masterDegrees.ConvertToDTO<IList<MasterDegree>, IList<CitizenMasterDegreesDTO>>(_mapper);
            return response;
        }

        public IList<CitizenYdsExamsDTO> GetCitizenYdsExamsDTOByCitizenId(int citizenId)
        {
            var ydsExams = _repository.GetYdsExamByCitizenId(citizenId);
            var response = ydsExams.ConvertToDTO<IList<YdsExam>, IList<CitizenYdsExamsDTO>>(_mapper);
            return response;
        }

        public async Task<IList<CitizenYdsExamsDTO>> GetCitizenYdsExamsDTOByCitizenIdAsync(int citizenId)
        {
            var ydsExams = await _repository.GetYdsExamByCitizenIdAsync(citizenId);
            var response = ydsExams.ConvertToDTO<IList<YdsExam>, IList<CitizenYdsExamsDTO>>(_mapper);
            return response;
        }
    }
}
