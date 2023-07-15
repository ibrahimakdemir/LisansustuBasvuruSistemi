using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly GraduateAppDbContext _dbContext;

        public EFUserRepository(GraduateAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            _dbContext.UsersRoles.Add(new UsersRole() 
            {
                UserId = entity.Id,
                RoleId = 1,
                GraduateProgramId = 1,
                IsActive = true
            });
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public async Task<int> CreateAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            await _dbContext.UsersRoles.AddAsync(new UsersRole()
            {
                UserId = entity.Id,
                RoleId = 1,
                GraduateProgramId = 1,
                IsActive = true
            });
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return _dbContext.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }

        public IList<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public User GetUserByCitizenId(int citizenId)
        {
            var user = _dbContext.Users.Include(u=>u.UsersRoles).AsNoTracking().FirstOrDefault(u => u.CitizenId == citizenId);
            return user;
        }

        public async Task<User> GetUserByCitizenIdAsync(int citizenId)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.CitizenId == citizenId);
            return user;
        }

        public User? GetByCitizenNumber(string citizenNumber)
        {
            var user = _dbContext.Users.AsNoTracking().FirstOrDefault(u => u.CitizenNumber == citizenNumber);
            return user;
        }

        public async Task<User?> GetByCitizenNumberAsync(string citizenNumber)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.CitizenNumber == citizenNumber);
            return user;
        }

        public bool IsRegistered(int citizenId)
        {
            return _dbContext.Users.Any(u=>u.CitizenId == citizenId);
        }

        public async Task<bool> IsRegisteredAsync(int citizenId)
        {
            return await _dbContext.Users.AnyAsync(u => u.CitizenId == citizenId);
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();

        }

        public int GetUserIdByCitizenId(int citizenId)
        {
            var user = _dbContext.Users.FirstOrDefault(u=>u.CitizenId==citizenId);
            return user.Id;
        }

        public async Task<int> GetUserIdByCitizenIdAsync(int citizenId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.CitizenId == citizenId);
            return user.Id;
        }

        public string GetUserRoleByUserId(int userId)
        {
            var usersRole = _dbContext.UsersRoles.Include(ur=>ur.Role).FirstOrDefault(r => r.UserId == userId);
            return usersRole.Role.RoleName;
        }

        public async Task<string> GetUserRoleByUserIdAsync(int userId)
        {
            var usersRole = await _dbContext.UsersRoles.Include(ur => ur.Role).FirstOrDefaultAsync(r => r.UserId == userId);
            return usersRole.Role.RoleName;
        }

        public int GetCitizenIdByUserId(int userId)
        {
            var user =  _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            return user.CitizenId;
        }

        public async Task<int> GetCitizenIdByUserIdAsync(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user.CitizenId;
        }

        public IList<UsersApplication> GetUserApplicationsByUserId(int userId)
        {
            var applications = _dbContext.UsersApplications.Include(ua=>ua.GraduateProgram)
                                                           .Include(ua=>ua.ApplicationsState)
                                                           .Include(ua=>ua.Reason)
                                                           .AsNoTracking()
                                                           .Where(u => u.UserId == userId)
                                                           .ToList();
            return applications;
        }

        public async Task<IList<UsersApplication>> GetUserApplicationsByUserIdAsync(int userId)
        {
            var applications = await _dbContext.UsersApplications.Include(ua => ua.GraduateProgram)
                                                           .Include(ua => ua.ApplicationsState)
                                                           .Include(ua => ua.Reason)
                                                           .AsNoTracking()
                                                           .Where(u => u.UserId == userId && u.IsActive)
                                                           .ToListAsync();
            return applications;
        }

        public async Task ApplyToGraduateProgramAsync(int userId, int programId)
        {
            var newApplication = new UsersApplication()
            {
                UserId = userId,
                GraduateProgramId = programId,
                ApplicationStateId = 3, //Waiting
                ReasonId = 1,
                IsConfirmedByApplicant = true,
                IsActive = true
            };
            await _dbContext.UsersApplications.AddAsync(newApplication);
            await _dbContext.SaveChangesAsync();
        }
    }
}
