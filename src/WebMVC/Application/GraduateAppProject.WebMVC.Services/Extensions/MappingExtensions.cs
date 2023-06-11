using AutoMapper;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Services.Extensions
{
    public static class MappingExtensions
    {
        public static IEnumerable<AnnouncementDisplayResponse> ConvertToDisplayResponsesForAnnouncement(this IEnumerable<Announcement> announcements, IMapper mapper)
        {
            return mapper.Map<IEnumerable<AnnouncementDisplayResponse>>(announcements);
        }
        public static IEnumerable<GraduateProgramDisplayResponse> ConvertToDisplayResponsesForGraduatePrograms(this IEnumerable<GraduateProgram> graduatePrograms, IMapper mapper)
        {

            return mapper.Map<IEnumerable<GraduateProgramDisplayResponse>>(graduatePrograms);
        }
        public static Tout ConvertToDTO<Tin, Tout>(this Tin value, IMapper mapper)
        {
            return mapper.Map<Tout>(value);
        }
    }
}
