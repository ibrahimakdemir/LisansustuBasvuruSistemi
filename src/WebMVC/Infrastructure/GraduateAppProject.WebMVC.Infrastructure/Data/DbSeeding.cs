using AutoMapper.Configuration;
using Bogus;
using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraduateAppProject.WebMVC.Infrastructure.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(GraduateAppDbContext dbContext, IConfiguration configuration)
        {
            
            SeedAnnouncement(dbContext);
            SeedApplicationState(dbContext);
            SeedOnlinePlatform(dbContext);
            SeedReason(dbContext);
            SeedRole(dbContext);
            SeedLanguage(dbContext);
            SeedInstitute(dbContext);
            SeedGraduateMajor(dbContext);
            SeedGraduateProgram(dbContext);
            SeedAdmin(dbContext);

        }

        private static void SeedAdmin(GraduateAppDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var admin = new User()
                {
                    CitizenId = 25,
                    CitizenNumber = "VhwrcVkRa+41v3otU1vUFg==",
                    IsAdmin = true,
                    Password = "Lv3rRiDoAio=",
                    Email = "admin@gmail.com"

                };
                
                dbContext.Users.Add(admin);
                dbContext.SaveChanges();
                dbContext.UsersRoles.Add(new UsersRole()
                {
                    UserId = admin.Id,
                    RoleId = 2,
                    GraduateProgramId = 1,
                    IsActive = true
                });
                dbContext.SaveChanges();
            }
        }

        private static void SeedGraduateProgram(GraduateAppDbContext dbContext)
        {
            if (!dbContext.GraduatePrograms.Any())
            {
                var programs = new List<GraduateProgram>()
                {
                    new()
                    {
                        GraduateMajorId = new Faker().Random.Int(1, 101),
                        // Toplam Yüksek Lisans bölüm sayısını tutan değişken 101'in yerine yazılabilir.
                        // Veya min ve max id değerlerini tutan değişkenler kullanılabilir.
                        WithThesis = new Faker().Random.Bool(),
                        LanguageId = new Faker().Random.Int(1,10),
                        HasExamRequirement = false,
                        HasMajorRequirement = false,
                        InterviewDate = new Faker().Date.Between(DateTime.Now.AddDays(7), DateTime.Now.AddDays(21)),
                        IsInterviewRemote = true,
                        OnlinePlatformId = new Faker().Random.Int(1,6),
                        Capacity = new Faker().Random.Int(1,10),
                        Semester = (new Faker().Random.Bool())?"Güz":"Bahar",
                        AcademicYear = DateTime.Now.Year,
                        IsActive = true,
                        Detail = new Faker().Random.Words(10)
                    }
                };
                dbContext.GraduatePrograms.AddRange(programs);
                dbContext.SaveChanges();
            }
        }

        private static void SeedGraduateMajor(GraduateAppDbContext dbContext)
        {
            if (!dbContext.GraduateMajorForPrograms.Any())
            {
                var majors = CreateSeedDataExtensions.GraduateMajorsList();
                dbContext.GraduateMajorForPrograms.AddRange(majors);
                dbContext.SaveChanges();
            }
        }

        private static void SeedInstitute(GraduateAppDbContext dbContext)
        {
            if (!dbContext.InstituteForGraduatePrograms.Any())
            {
                var institutes = new List<InstituteForGraduateProgram>()
                {
                    new(){ InstituteName = "Fen Bilimleri Enstitüsü"},
                    new(){ InstituteName = "Sosyal Bilimler Enstitüsü"},
                    new(){ InstituteName = "Sağlık Bilimleri Enstitüsü"},
                    new(){ InstituteName = "Bağımlılık ve Adli Bilimler Enstitüsü"}
                };
                dbContext.InstituteForGraduatePrograms.AddRange(institutes);
                dbContext.SaveChanges();
            }
        }

        private static void SeedLanguage(GraduateAppDbContext dbContext)
        {
            if (!dbContext.Languages.Any())
            {
                var languages = new List<Language>()
                {
                    new() { LanguageName="Türkçe"},
                    new() { LanguageName="İngilizce"},
                    new() { LanguageName="İspanyolca"},
                    new() { LanguageName="Fransızca"},
                    new() { LanguageName="Almanca"},
                    new() { LanguageName="İtalyanca"},
                    new() { LanguageName="Çince"},
                    new() { LanguageName="Japonca"},
                    new() { LanguageName="Arapça"},
                    new() { LanguageName="Rusça"}

                };
                dbContext.Languages.AddRange(languages);
                dbContext.SaveChanges();
            }
        }

        private static void SeedRole(GraduateAppDbContext dbContext)
        {
            if (!dbContext.Roles.Any())
            {
                var roles = new List<Role>()
                {
                    new() { RoleName="Aday"},
                    new() { RoleName="Admin"},
                    new() { RoleName="Görevli"}

                };
                dbContext.Roles.AddRange(roles);
                dbContext.SaveChanges();
            }
        }

        private static void SeedReason(GraduateAppDbContext dbContext)
        {
            if (!dbContext.Reasons.Any())
            {
                var reasons = new List<Reason>()
                {
                    new() { ReasonName="Eğitim Yetersiz"},
                    new() { ReasonName="YDS Puanı Yetersiz"},
                    new() { ReasonName="ALES Puanı Yetersiz"},
                    new() { ReasonName="Dekont Eksik"},
                    new() { ReasonName="Yetersiz Belge"}
                };
                dbContext.Reasons.AddRange(reasons);
                dbContext.SaveChanges();
            }
        }

        private static void SeedOnlinePlatform(GraduateAppDbContext dbContext)
        {
            if (!dbContext.OnlinePlatforms.Any())
            {
                var platforms = new List<OnlinePlatform>()
                {
                    new() { PlatformName="Zoom"},
                    new() { PlatformName="Microsoft Teams"},
                    new() { PlatformName="Google Meet"},
                    new() { PlatformName="Skype"},
                    new() { PlatformName="Cisco Webex"},
                    new() { PlatformName="Diğer"}
                };
                dbContext.OnlinePlatforms.AddRange(platforms);
                dbContext.SaveChanges();
            }
        }

        private static void SeedApplicationState(GraduateAppDbContext dbContext)
        {
            if (!dbContext.ApplicationsStates.Any())
            {
                var states = new List<ApplicationsState>()
                {
                    new() { State="Onay/ Kabul edildi"},
                    new() { State = "Reddedildi"},
                    new() { State = "İnceleniyor/ Değerlendiriliyor"},
                    new() { State = "İptal edildi"},
                    new() { State = "Tamamlanmadı"}
                };
                dbContext.ApplicationsStates.AddRange(states);
                dbContext.SaveChanges();
            }
        }

        private static void SeedAnnouncement(GraduateAppDbContext dbContext)
        {
            if (!dbContext.Announcements.Any())
            {
                dbContext.Announcements.AddRange(CreateSeedDataExtensions.MultiAnnouncementCreator(10));
                dbContext.SaveChanges();
            }
        }

    }
}
