using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateAppProject.Entities
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        public string? CitizenNumber { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? PhotoUrl { get; set; }
        public string? PhoneNumber { get; set; }

        [NotMapped]
        public ICollection<Announcement> Announcements { get; set; } = new HashSet<Announcement>();
        [NotMapped]
        public ICollection<GraduateProgram> GraduatePrograms { get; set; } = new HashSet<GraduateProgram>();
        [NotMapped]
        public ICollection<HelpMessage> HelpMessages { get; set; } = new HashSet<HelpMessage>();
        [NotMapped]
        public ICollection<UsersApplication> UsersApplications { get; set; } = new HashSet<UsersApplication>();

        public ICollection<UsersLogin> UsersLogins { get; set; } = new HashSet<UsersLogin>();
        [NotMapped]
        public ICollection<UsersRole> UsersRoles { get; set; } = new HashSet<UsersRole>();

        [NotMapped]
        public ICollection<InformationsUpdate> InformationsUpdates { get; set; } = new HashSet<InformationsUpdate>();
    }
}
