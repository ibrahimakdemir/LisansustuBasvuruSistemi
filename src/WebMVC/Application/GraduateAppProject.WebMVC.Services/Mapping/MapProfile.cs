using AutoMapper;
using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Entities;

namespace GraduateAppProject.WebMVC.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Announcement, AnnouncementDisplayResponse>();
            CreateMap<GraduateProgram, GraduateProgramDisplayResponse>();
            CreateMap<CreateNewUserRequest, User>();
            CreateMap<CreateNewGraduateProgramRequest, GraduateProgram>();
                                                                        
            //.ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.Price));
            //şeklinde yaparak entity'de olmayan ama dto'da olan propertylerin atamasını gerçekleştirebiliriz. 
        }
    }
}
