using GraduateAppProject.Infrastructure.Data;
using GraduateAppProject.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Repositories
{
    public class EFCitizenRepository : ICitizenRepository
    {
        private readonly CitizensInfoApiDbContext _context;

        public EFCitizenRepository(CitizensInfoApiDbContext context)
        {
            _context = context;
        }

        public int CheckCitizen(string encryptedCitizenNumber, string firstName, string lastName, int birthYear)
        {
            var normalizedFirstName = firstName.ToLowerInvariant();
            var normalizedLastName = lastName.ToLowerInvariant();
            var citizen = _context.Citizens.AsNoTracking()
                                             .FirstOrDefault(c => c.CitizenNumber == encryptedCitizenNumber
                                                               && c.FirstName == normalizedFirstName
                                                               && c.LastName == normalizedLastName
                                                               && c.BirthDate.Year == birthYear);

            if (citizen == null)
            {
                return 0;
            }
            return citizen.Id;
        }

        public async Task<int> CheckCitizenAsync(string encryptedCitizenNumber, string firstName, string lastName, int birthYear)
        {
            var normalizedFirstName = firstName.ToLowerInvariant();
            var normalizedLastName = lastName.ToLowerInvariant();
            var citizen = await _context.Citizens.AsNoTracking()
                                             .FirstOrDefaultAsync(c => c.CitizenNumber == encryptedCitizenNumber
                                                               && c.FirstName == normalizedFirstName
                                                               && c.LastName == normalizedLastName
                                                               && c.BirthDate.Year == birthYear);

            if (citizen == null)
            {
                return 0;
            }
            return citizen.Id;
        }

        public int Create(Citizen entity)
        {
            _context.Citizens.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public async Task<int> CreateAsync(Citizen entity)
        {
            await _context.Citizens.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public void Delete(int id)
        {
            var citizen = _context.Citizens.Find(id);
            _context.Citizens.Remove(citizen);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var citizen = await _context.Citizens.FindAsync(id);
            _context.Citizens.Remove(citizen);
            await _context.SaveChangesAsync();
        }

        public Citizen Get(int id)
        {
            return _context.Citizens.AsNoTracking().FirstOrDefault(c=>c.Id == id);
        }

        public IList<Citizen> GetAll()
        {
            return _context.Citizens.AsNoTracking().ToList();
        }

        public async Task<IList<Citizen>> GetAllAsync()
        {
            return await _context.Citizens.AsNoTracking().ToListAsync();
        }

        public async Task<Citizen> GetAsync(int id)
        {
            return await _context.Citizens.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public Citizen GetCitizenByCitizenNumber(string encryptedCitizenNumber)
        {
            return _context.Citizens.AsNoTracking().FirstOrDefault(c => c.CitizenNumber == encryptedCitizenNumber);
        }

        public async Task<Citizen> GetCitizenByCitizenNumberAsync(string encryptedCitizenNumber)
        {
            return await _context.Citizens.AsNoTracking().FirstOrDefaultAsync(c => c.CitizenNumber == encryptedCitizenNumber);
        }

        public async Task UpdateAsync(Citizen entity)
        {
            _context.Citizens.Update(entity);
            await _context.SaveChangesAsync();
        }
        public void Update(Citizen entity)
        {
            throw new NotImplementedException();
        }

    }
}
