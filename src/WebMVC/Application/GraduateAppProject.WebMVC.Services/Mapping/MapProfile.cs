using AutoMapper;
using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.DataTransferObjects.Responses.UserResponses;
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
            CreateMap<CreateNewMailRequest, HelpMessage>();
            CreateMap<HelpMessage, MailDisplayResponse>();
            CreateMap<User, UserContactInformationDTO>();
                                                                        
            //.ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.Price));
            //şeklinde yaparak entity'de olmayan ama dto'da olan propertylerin atamasını gerçekleştirebiliriz. 
        }
    }
}
