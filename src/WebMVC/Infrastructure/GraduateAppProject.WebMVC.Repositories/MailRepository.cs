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
    public class MailRepository : IMailRepository
    {
        private readonly GraduateAppDbContext _context;

        public MailRepository(GraduateAppDbContext context)
        {
            _context = context;
        }

        public int Create(HelpMessage entity)
        {
            _context.HelpMessages.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public async Task<int> CreateAsync(HelpMessage entity)
        {
            await _context.HelpMessages.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public void Delete(int id)
        {
            var mail = _context.HelpMessages.Find(id);
            if (mail != null)
            {
                _context.HelpMessages.Remove(mail);
            }
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var mail = await _context.HelpMessages.FindAsync(id);
            if (mail != null)
            {
                _context.HelpMessages.Remove(mail);
            }
            await _context.SaveChangesAsync();
        }

        public HelpMessage Get(int id)
        {
            return _context.HelpMessages.Find(id);
        }

        public IList<HelpMessage> GetAll()
        {
            return _context.HelpMessages.AsNoTracking().ToList();
        }

        public async Task<IList<HelpMessage>> GetAllAsync()
        {
            return await _context.HelpMessages.AsNoTracking().ToListAsync();
        }

        public async Task<HelpMessage> GetAsync(int id)
        {
            return await _context.HelpMessages.FindAsync(id);
        }

        public void Update(HelpMessage entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(HelpMessage entity)
        {
            throw new NotImplementedException();
        }
    }
}
