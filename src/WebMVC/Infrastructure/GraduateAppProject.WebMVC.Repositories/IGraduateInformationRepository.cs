using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Entities;

namespace GraduateAppProject.WebMVC.Repositories
{
    public interface IGraduateInformationRepository
    {
        Task CreateAsync(GraduateProgram graduateProgram);
        void Create(GraduateProgram graduateProgram);
        

        IList<Announcement> GetAnnouncements();
        Task<IList<Announcement>> GetAnnouncementsAsync();
        Announcement GetAnnouncementById(int id);
        Task<Announcement> GetAnnouncementByIdAsync(int id);
        IList<GraduateProgram> GetGraduatePrograms();
        Task<IList<GraduateProgram>> GetGraduateProgramsAsync();
        GraduateProgram GetGraduateProgramById(int id);
        Task<GraduateProgram> GetGraduateProgramByIdAsync(int id);
        IList<AlesExamsRequirement> GetAlesExamsRequirements();
        Task<IList<AlesExamsRequirement>> GetAlesExamsRequirementsAsync();
        AlesExamsRequirement GetAlesExamsRequirementById(int id);
        Task<AlesExamsRequirement> GetAlesExamsRequirementByIdAsync(int id);
        IList<ApplicationsState> GetApplicationsStates();
        Task<IList<ApplicationsState>> GetApplicationsStatesAsync();
        ApplicationsState GetApplicationStateById(int id);
        Task<ApplicationsState> GetApplicationsStateByIdAsync(int id);
        IList<GraduateMajorForProgram> GetGraduateMajorForPrograms();
        Task<IList<GraduateMajorForProgram>> GetGraduateMajorForProgramsAsync();
        GraduateMajorForProgram GetGraduateMajorForProgramById(int id);
        Task<GraduateMajorForProgram> GetGraduateMajorForProgramByIdAsync(int id);
        IList<HelpMessage> GetHelpMessages();
        Task<IList<HelpMessage>> GetHelpMessagesAsync();
        HelpMessage GetHelpMessageById(int id);
        Task<HelpMessage> GetHelpMessageByIdAsync(int id);
        IList<InformationsUpdate> GetInformationsUpdates();
        Task<IList<InformationsUpdate>> GetInformationsUpdateAsync();
        IList<InstituteForGraduateProgram> GetInstituteForGraduatePrograms();
        Task<IList<InstituteForGraduateProgram>> GetInstituteForGraduateProgramsAsync();
        InstituteForGraduateProgram GetInstituteForGraduateProgramById(int id);
        Task<InstituteForGraduateProgram> GetInstituteForGraduateProgramByIdAsync(int id);
        IList<Language> GetLanguages();
        Task<IList<Language>> GetLanguageAsync();
        Language GetLanguageById(int id);
        Task<Language> GetLanguageByIdAsync(int id);
        IList<OnlinePlatform> GetOnlinePlatforms();
        Task<IList<OnlinePlatform>> GetOnlinePlatformAsync();
        OnlinePlatform GetOnlinePlatformById(int id);
        Task<OnlinePlatform> GetOnlinePlatformByIdAsync(int id);
        IList<Reason> GetReasons();
        Task<IList<Reason>> GetReasonAsync();
        Reason GetReasonById(int id);
        Task<Reason> GetReasonByIdAsync(int id);
        IList<YdsExamsRequirement> GetYdsExamsRequirements();
        Task<IList<YdsExamsRequirement>> GetYdsExamsRequirementsAsync();
        YdsExamsRequirement GetYdsExamsRequirementById(int id);
        Task<YdsExamsRequirement> GetYdsExamsRequirementByIdAsync(int id);
        IList<GraduateProgram> GetGraduateProgramWithAllInfo();
    }
}
