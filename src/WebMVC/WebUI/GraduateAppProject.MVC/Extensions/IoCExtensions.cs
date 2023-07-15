using GraduateAppProject.WebMVC.Infrastructure.Data;
using GraduateAppProject.WebMVC.Repositories;
using GraduateAppProject.WebMVC.Services;
using Microsoft.EntityFrameworkCore;

namespace GraduateAppProject.MVC.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IGraduateInformationService, GraduateInformationService>();
            services.AddScoped<IGraduateInformationRepository, EFGraduateInformationRepository>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddDbContext<GraduateAppDbContext>(option => option.UseSqlServer(connectionString));
            return services;

        }
    }
}
