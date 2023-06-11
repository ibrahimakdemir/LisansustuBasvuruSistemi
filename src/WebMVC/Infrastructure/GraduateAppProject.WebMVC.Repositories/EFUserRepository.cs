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
            return entity.Id;
        }

        public async Task<int> CreateAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
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
            throw new NotImplementedException();
        }

        public IList<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByCitizenId(int citizenId)
        {
            var user = _dbContext.Users.Include(u=>u.UsersRoles).AsNoTracking().FirstOrDefault(u => u.CitizenId == citizenId);
            return user;
        }

        public async Task<User> GetUserByCitizenIdAsync(int citizenId)
        {
            var user = await _dbContext.Users.Include(u => u.UsersRoles).AsNoTracking().FirstOrDefaultAsync(u => u.CitizenId == citizenId);
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
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
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
    }
}
