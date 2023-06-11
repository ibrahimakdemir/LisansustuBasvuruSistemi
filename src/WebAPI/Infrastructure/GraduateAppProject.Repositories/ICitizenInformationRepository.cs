using GraduateAppProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Repositories
{
    public interface ICitizenInformationRepository
    {
        IList<AlesExam> GetAlesExamByCitizenId(int citizenId);
        Task<IList<AlesExam>> GetAlesExamByCitizenIdAsync(int citizenId);

        IList<BachelorDegree> GetBachelorDegreeByCitizenId(int citizenId);
        Task<IList<BachelorDegree>> GetBachelorDegreeByCitizenIdAsync(int citizenId);

        IList<DoctorateDegree> GetDoctorateDegreeByCitizenId(int citizenId);
        Task<IList<DoctorateDegree>> GetDoctorateDegreeByCitizenIdAsync(int citizenId);

        IList<MasterDegree> GetMasterDegreeByCitizenId(int citizenId);
        Task<IList<MasterDegree>> GetMasterDegreeByCitizenIdAsync(int citizenId);

        IList<YdsExam> GetYdsExamByCitizenId(int citizenId);
        Task<IList<YdsExam>> GetYdsExamByCitizenIdAsync(int citizenId);

    }
}
