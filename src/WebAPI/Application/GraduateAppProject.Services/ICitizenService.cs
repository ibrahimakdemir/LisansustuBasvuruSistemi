using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Services
{
    public interface ICitizenService
    {
        Task<int> IsValidCitizenAsync(CheckCitizenRequest request);
        int IsValidCitizen(CheckCitizenRequest request);
        Task<IList<Citizen>> GetCitizensAsync();
        IList<Citizen> GetCitizens();


    }
}
