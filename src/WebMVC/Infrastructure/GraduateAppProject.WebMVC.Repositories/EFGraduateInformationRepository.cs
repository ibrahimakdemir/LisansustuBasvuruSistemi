using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Entities;
using GraduateAppProject.WebMVC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GraduateAppProject.WebMVC.Repositories
{
    public class EFGraduateInformationRepository : IGraduateInformationRepository
    {
        private readonly GraduateAppDbContext _dbContext;

        public EFGraduateInformationRepository(GraduateAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<AlesExamsRequirement> GetAlesExamsRequirements()
        {
            throw new NotImplementedException();
        }

        public Task<IList<AlesExamsRequirement>> GetAlesExamsRequirementsAsync()
        {
            throw new NotImplementedException();
        }

        public IList<Announcement> GetAnnouncements()
        {
            var announcements = _dbContext.Announcements.AsNoTracking().Where(a => a.IsActive).ToList();
            return announcements;
        }

        public async Task<IList<Announcement>> GetAnnouncementsAsync()
        {
            var announcements = await _dbContext.Announcements.AsNoTracking().Where(a => a.IsActive).ToListAsync();
            return announcements;
        }

        public IList<GraduateProgram> GetGraduateProgramWithAllInfo()
        {
            var graduates = _dbContext.GraduatePrograms.Include(g => g.GraduateMajor)
                                                      .Include(g => g.Language)
                                                      .Include(g => g.OnlinePlatform).AsNoTracking().Where(g => g.IsActive)
                                                      .ToList();
            return graduates;
        }

        public async Task<IList<GraduateProgram>> GetGraduateProgramWithAllInfoAsync()
        {
            var graduates = await _dbContext.GraduatePrograms.Include(g => g.GraduateMajor)
                                                      .Include(g => g.Language)
                                                      .Include(g => g.OnlinePlatform).AsNoTracking().Where(g => g.IsActive)
                                                      .ToListAsync();
            return graduates;
        }

        public async Task<IList<GraduateProgram>> GetGraduateProgramsAsync()
        {
            var graduates = await _dbContext.GraduatePrograms.AsNoTracking().Where(g => g.IsActive).ToListAsync();
            return graduates;
        }

        public IList<ApplicationsState> GetApplicationsStates()
        {
            throw new NotImplementedException();
        }

        public Task<IList<ApplicationsState>> GetApplicationsStatesAsync()
        {
            throw new NotImplementedException();
        }

        public IList<GraduateMajorForProgram> GetGraduateMajorForPrograms()
        {
            var majors = _dbContext.GraduateMajorForPrograms.AsNoTracking().ToList();
            return majors;
        }

        public async Task<IList<GraduateMajorForProgram>> GetGraduateMajorForProgramsAsync()
        {
            var majors = await _dbContext.GraduateMajorForPrograms.AsNoTracking().ToListAsync();
            return majors;
        }

        public IList<GraduateProgram> GetGraduatePrograms()
        {
            var graduates = _dbContext.GraduatePrograms.AsNoTracking().Where(g => g.IsActive).ToList();
            return graduates;
        }

        

        public IList<HelpMessage> GetHelpMessages()
        {
            throw new NotImplementedException();
        }

        public Task<IList<HelpMessage>> GetHelpMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<InformationsUpdate>> GetInformationsUpdateAsync()
        {
            throw new NotImplementedException();
        }

        public IList<InformationsUpdate> GetInformationsUpdates()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<InstituteForGraduateProgram>> GetInstituteForGraduateProgramsAsync()
        {
            var institutes = await _dbContext.InstituteForGraduatePrograms.AsNoTracking().ToListAsync();
            return institutes;
        }

        public IList<InstituteForGraduateProgram> GetInstituteForGraduatePrograms()
        {
            var institutes = _dbContext.InstituteForGraduatePrograms.AsNoTracking().ToList();
            return institutes;
        }

        public async Task<IList<Language>> GetLanguageAsync()
        {
            var languages = await _dbContext.Languages.AsNoTracking().ToListAsync();
            return languages;
        }

        public IList<Language> GetLanguages()
        {
            var languages = _dbContext.Languages.AsNoTracking().ToList();
            return languages;
        }

        public async Task<IList<OnlinePlatform>> GetOnlinePlatformAsync()
        {
            return await _dbContext.OnlinePlatforms.AsNoTracking().ToListAsync();
        }

        public IList<OnlinePlatform> GetOnlinePlatforms()
        {
            return _dbContext.OnlinePlatforms.AsNoTracking().ToList();
        }

        public async Task<IList<Reason>> GetReasonAsync()
        {
            return await _dbContext.Reasons.AsNoTracking().ToListAsync();
        }

        public IList<Reason> GetReasons()
        {
            return _dbContext.Reasons.AsNoTracking().ToList();

        }

        public IList<YdsExamsRequirement> GetYdsExamsRequirements()
        {
            throw new NotImplementedException();
        }

        public Task<IList<YdsExamsRequirement>> GetYdsExamsRequirementsAsync()
        {
            throw new NotImplementedException();
        }

        public Announcement GetAnnouncementById(int id)
        {
            var announcement = _dbContext.Announcements.AsNoTracking().FirstOrDefault(a => a.Id == id);
            return announcement;
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(int id)
        {
            var announcement = await _dbContext.Announcements.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            return announcement;
        }

        public GraduateProgram GetGraduateProgramById(int id)
        {
            var program = _dbContext.GraduatePrograms.AsNoTracking().FirstOrDefault(a => a.Id == id);
            return program;
        }

        public async Task<GraduateProgram> GetGraduateProgramByIdAsync(int id)
        {
            var program = await _dbContext.GraduatePrograms.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            return program;
        }

        public AlesExamsRequirement GetAlesExamsRequirementById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AlesExamsRequirement> GetAlesExamsRequirementByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationsState GetApplicationStateById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationsState> GetApplicationsStateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public GraduateMajorForProgram GetGraduateMajorForProgramById(int id)
        {
            var major = _dbContext.GraduateMajorForPrograms.AsNoTracking().FirstOrDefault(a => a.Id == id);
            return major;
        }

        public async Task<GraduateMajorForProgram> GetGraduateMajorForProgramByIdAsync(int id)
        {
            var major = await _dbContext.GraduateMajorForPrograms.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            return major;
        }

        public HelpMessage GetHelpMessageById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HelpMessage> GetHelpMessageByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public InstituteForGraduateProgram GetInstituteForGraduateProgramById(int id)
        {
            var institute = _dbContext.InstituteForGraduatePrograms.AsNoTracking().FirstOrDefault(a => a.Id == id);
            return institute;
        }

        public async Task<InstituteForGraduateProgram> GetInstituteForGraduateProgramByIdAsync(int id)
        {
            var institute = await _dbContext.InstituteForGraduatePrograms.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            return institute;
        }

        public Language GetLanguageById(int id)
        {
            var language = _dbContext.Languages.AsNoTracking().FirstOrDefault(a => a.Id == id);
            return language;
        }

        public async Task<Language> GetLanguageByIdAsync(int id)
        {
            var language = await _dbContext.Languages.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            return language;
        }

        public OnlinePlatform GetOnlinePlatformById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OnlinePlatform> GetOnlinePlatformByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Reason GetReasonById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reason> GetReasonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public YdsExamsRequirement GetYdsExamsRequirementById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<YdsExamsRequirement> GetYdsExamsRequirementByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       

        public async Task CreateAsync(GraduateProgram graduateProgram)
        {
            await _dbContext.GraduatePrograms.AddAsync(graduateProgram);
            await _dbContext.SaveChangesAsync();
        }

        public void Create(GraduateProgram graduateProgram)
        {
            _dbContext.GraduatePrograms.Add(graduateProgram);
            _dbContext.SaveChangesAsync();
        }

        public GraduateProgram GetGraduateProgramWithAllInfoByProgramId(int id)
        {
            var program = _dbContext.GraduatePrograms.Include(g => g.GraduateMajor)
                                                     .Include(g => g.Language)
                                                     .Include(g => g.OnlinePlatform).AsNoTracking()
                                                     .FirstOrDefault(g => g.IsActive && g.Id == id);
            return program;
        }

        public async Task<GraduateProgram> GetGraduateProgramWithAllInfoByProgramIdAsync(int id)
        {
            var program = await _dbContext.GraduatePrograms.Include(g => g.GraduateMajor)
                                                      .Include(g => g.Language)
                                                      .Include(g => g.OnlinePlatform).AsNoTracking()
                                                      .FirstOrDefaultAsync(g => g.IsActive && g.Id == id);
            return program;
        }

        public async Task DisableGraduateProgramByProgramIdAsync(int programId)
        {
            var program = await _dbContext.GraduatePrograms.FirstOrDefaultAsync(gp => gp.Id == programId);
            if (program != null)
                program.IsActive = false;
            _dbContext.GraduatePrograms.Update(program);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<UsersApplication>> GetApplicationsByProgramIdAsync(int programId)
        {
            return await _dbContext.UsersApplications.Where(ua=>ua.GraduateProgramId == programId && ua.ApplicationStateId !=1).ToListAsync();
        }

        public async Task DisableApplicationsByProgramIdAsync(int programId)
        {
            var applications = await _dbContext.UsersApplications.Where(ua=>ua.GraduateProgramId == programId).ToListAsync();
            applications.ForEach(a => a.IsActive = false);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserApplicationAsync(UsersApplication application)
        {
            _dbContext.UsersApplications.Update(application);
            await _dbContext.SaveChangesAsync();
        }
    }
}
