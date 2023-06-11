using GraduateAppProject.Infrastructure.Models;

namespace GraduateAppProject.Repositories
{
    public interface ICitizenRepository : IRepository<Citizen>
    {
        Task<Citizen> GetCitizenByCitizenNumberAsync(string encryptedCitizenNumber);
        Citizen GetCitizenByCitizenNumber(string encryptedCitizenNumber);
        Task<int> CheckCitizenAsync(string encryptedCitizenNumber, string firstName, string lastName, int birthYear);
        int CheckCitizen(string encryptedCitizenNumber, string firstName, string lastName, int birthYear);

    }
}
