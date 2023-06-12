using GraduateAppProject.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Infrastructure.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(CitizensInfoApiDbContext dbContext, IConfiguration configuration)
        {
            SeedCitizen(dbContext, configuration);
        }

        private static void SeedCitizen(CitizensInfoApiDbContext dbContext, IConfiguration configuration)
        {
            if (!dbContext.Citizens.Any())
            {
                var citizenList = new List<Citizen>();
                //Adding citizens with their educational informations(Bachelor, Doctorate, ...)
                for (int i = 0; i < 10; i++)
                {
                    var citizen = SeedDataCreatorExtensions.CreateFakeCitizens(configuration);
                    citizenList.Add(citizen);
                }
                dbContext.Citizens.AddRange(citizenList);
                dbContext.SaveChanges();
            }
        }
    }
}
