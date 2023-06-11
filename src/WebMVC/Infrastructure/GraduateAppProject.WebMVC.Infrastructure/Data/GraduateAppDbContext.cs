using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraduateAppProject.WebMVC.Infrastructure.Data
{
    public class GraduateAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AlesExamsRequirement> AlesExamsRequirements { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ApplicationsState> ApplicationsStates { get; set; }
        public DbSet<RequiredMajor> RequiredMajors { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<InstituteForGraduateProgram> InstituteForGraduatePrograms { get; set; }
        public DbSet<GraduateMajorForProgram> GraduateMajorForPrograms { get; set; }
        public DbSet<GraduateProgram> GraduatePrograms { get; set; }
        public DbSet<HelpMessage> HelpMessages { get; set; }
        public DbSet<InformationsUpdate> InformationsUpdates { get; set; }
        public DbSet<OnlinePlatform> OnlinePlatforms { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersApplication> UsersApplications { get; set; }
        public DbSet<UsersLogin> UsersLogins { get; set; }
        public DbSet<UsersRole> UsersRoles { get; set; }
        public DbSet<YdsExamsRequirement> YdsExamsRequirements { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=AKDEMIR-DESKTOP\\SQLEXPRESS;Database=GraduateAppDB;Trusted_Connection=True;TrustServerCertificate=True;");
        //}
        public GraduateAppDbContext(DbContextOptions<GraduateAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequiredMajor>()
                        .HasKey(rm => new { rm.GraduateProgramId, rm.GraduateMajorForProgramId });

            modelBuilder.Entity<RequiredMajor>()
                        .HasOne(rm => rm.GraduateProgram)
                        .WithMany()
                        .HasForeignKey(rm => rm.GraduateProgramId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RequiredMajor>()
                        .HasOne(rm => rm.GraduateMajorForProgram)
                        .WithMany()
                        .HasForeignKey(rm => rm.GraduateMajorForProgramId)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
