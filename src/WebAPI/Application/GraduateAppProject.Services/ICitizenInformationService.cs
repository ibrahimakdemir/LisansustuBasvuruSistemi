using GraduateAppProject.DataTransferObjects;
using GraduateAppProject.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Services
{
    public interface ICitizenInformationService
    {
        public Task<CitizenInformationsModel> GetCitizenInformationsModelByCitizenIdAsync(int citizenId);
        public CitizenInformationsModel GetCitizenInformationsModelByCitizenId(int citizenId);
        public Task<IList<CitizenAlesExamsDTO>> GetCitizenAlesExamsDTOByCitizenIdAsync(int citizenId);
        public IList<CitizenAlesExamsDTO> GetCitizenAlesExamsDTOByCitizenId(int citizenId);
        public Task<IList<CitizenBachelorDegreesDTO>> GetCitizenBachelorDegreesDTOByCitizenIdAsync(int citizenId);
        public IList<CitizenBachelorDegreesDTO> GetCitizenBachelorDegreesDTOByCitizenId(int citizenId);
        public Task<IList<CitizenDoctorateDegreesDTO>> GetCitizenDoctorateDegreesDTOByCitizenIdAsync(int citizenId);
        public IList<CitizenDoctorateDegreesDTO> GetCitizenDoctorateDegreesDTOByCitizenId(int citizenId);
        public Task<CitizenIdentityInformationsDTO> GetCitizenIdentityInformationsDTOByCitizenIdAsync(int citizenId);
        public CitizenIdentityInformationsDTO GetCitizenIdentityInformationsDTOByCitizenId(int citizenId);
        public Task<IList<CitizenMasterDegreesDTO>> GetCitizenMasterDegreesDTOByCitizenIdAsync(int citizenId);
        public IList<CitizenMasterDegreesDTO> GetCitizenMasterDegreesDTOByCitizenId(int citizenId);
        public Task<IList<CitizenYdsExamsDTO>> GetCitizenYdsExamsDTOByCitizenIdAsync(int citizenId);
        public IList<CitizenYdsExamsDTO> GetCitizenYdsExamsDTOByCitizenId(int citizenId);
    }
}
