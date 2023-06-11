using GraduateAppProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        User GetByCitizenNumber(string citizenNumber);
        Task<User> GetByCitizenNumberAsync(string citizenNumber);
        User GetUserByCitizenId(int citizenId);
        Task<User> GetUserByCitizenIdAsync(int citizenId);
        int GetUserIdByCitizenId(int citizenId);
        Task<int> GetUserIdByCitizenIdAsync(int citizenId);
        string GetUserRoleByUserId(int userId);
        Task<string> GetUserRoleByUserIdAsync(int userId);
        bool IsRegistered(int citizenId);
        Task<bool> IsRegisteredAsync(int citizenId);
        //int RegistereUser(int citizenId, string mailAddress, string password);
        //Task<int> RegistereUserAsync(int citizenId, string mailAddress, string password);


    }
}
