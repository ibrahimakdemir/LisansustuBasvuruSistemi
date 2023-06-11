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
    public class EFCitizenInformationRepository : ICitizenInformationRepository
    {
        private readonly CitizensInfoApiDbContext _context;

        public EFCitizenInformationRepository(CitizensInfoApiDbContext context)
        {
            _context = context;
        }

        public IList<AlesExam> GetAlesExamByCitizenId(int citizenId)
        {
            var ales = _context.AlesExams.AsNoTracking().Where(a=>a.CitizenId == citizenId).ToList();
            return ales;
        }

        public async Task<IList<AlesExam>> GetAlesExamByCitizenIdAsync(int citizenId)
        {
            var ales = await _context.AlesExams.AsNoTracking().Where(a => a.CitizenId == citizenId).ToListAsync();
            return ales;
        }

        public IList<BachelorDegree> GetBachelorDegreeByCitizenId(int citizenId)
        {
            var bachelor = _context.BachelorDegrees.AsNoTracking().Where(a => a.CitizenId == citizenId).ToList();
            return bachelor;
        }

        public async Task<IList<BachelorDegree>> GetBachelorDegreeByCitizenIdAsync(int citizenId)
        {
            var bachelor = await _context.BachelorDegrees.AsNoTracking().Where(a => a.CitizenId == citizenId).ToListAsync();
            return bachelor;
        }

        public IList<DoctorateDegree> GetDoctorateDegreeByCitizenId(int citizenId)
        {
            var doctorate = _context.DoctorateDegrees.AsNoTracking().Where(a => a.CitizenId == citizenId).ToList();
            return doctorate;
        }

        public async Task<IList<DoctorateDegree>> GetDoctorateDegreeByCitizenIdAsync(int citizenId)
        {
            var doctorate = await _context.DoctorateDegrees.AsNoTracking().Where(a => a.CitizenId == citizenId).ToListAsync();
            return doctorate;
        }

        public IList<MasterDegree> GetMasterDegreeByCitizenId(int citizenId)
        {
            var master = _context.MasterDegrees.AsNoTracking().Where(a => a.CitizenId == citizenId).ToList();
            return master;
        }

        public async Task<IList<MasterDegree>> GetMasterDegreeByCitizenIdAsync(int citizenId)
        {
            var master = await _context.MasterDegrees.AsNoTracking().Where(a => a.CitizenId == citizenId).ToListAsync();
            return master;
        }

        public IList<YdsExam> GetYdsExamByCitizenId(int citizenId)
        {
            var yds = _context.YdsExams.AsNoTracking().Where(a => a.CitizenId == citizenId).ToList();
            return yds;
        }

        public async Task<IList<YdsExam>> GetYdsExamByCitizenIdAsync(int citizenId)
        {
            var yds = await _context.YdsExams.AsNoTracking().Where(a => a.CitizenId == citizenId).ToListAsync();
            return yds;
        }
    }
}
