using AutoMapper;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Infrastructure.Models;

namespace GraduateAppProject.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Citizen, CitizenIdentityInformationsDTO>();
            CreateMap<AlesExam, CitizenAlesExamsDTO>();
            CreateMap<BachelorDegree, CitizenBachelorDegreesDTO>();
            CreateMap<DoctorateDegree, CitizenDoctorateDegreesDTO>();
            CreateMap<MasterDegree, CitizenMasterDegreesDTO>();
            CreateMap<YdsExam, CitizenYdsExamsDTO>();            
        }
    }
}
