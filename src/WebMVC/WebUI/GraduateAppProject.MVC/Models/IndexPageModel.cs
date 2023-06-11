using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Entities;

namespace GraduateAppProject.MVC.Models
{
    public class IndexPageModel
    {
        public IList<AnnouncementDisplayResponse> Announcements { get; set; }
        public IList<GraduateProgram> GraduatePrograms { get; set; }
    }
}
