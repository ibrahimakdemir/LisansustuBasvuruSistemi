using GraduateAppProject.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Infrastructure.Data
{
    public static class DbSeeding
    {
        // This method is responsible for seeding the database with initial data.
        public static void SeedDatabase(CitizensInfoApiDbContext dbContext, IConfiguration configuration)
        {
            SeedCitizen(dbContext, configuration);
        }

        // This method seeds the Citizens table with fake citizen data.
        private static void SeedCitizen(CitizensInfoApiDbContext dbContext, IConfiguration configuration)
        {
            // Check if the Citizens table is empty
            if (!dbContext.Citizens.Any())
            {
                var citizenList = new List<Citizen>();

                // Adding citizens with their educational information (e.g., Bachelor, Doctorate, ...)
                for (int i = 0; i < 10; i++)
                {
                    var citizen = SeedDataCreatorExtensions.CreateFakeCitizens(configuration);
                    citizenList.Add(citizen);
                }

                // Add the citizen list to the database context and save changes
                dbContext.Citizens.AddRange(citizenList);
                dbContext.SaveChanges();
            }
        }
    }

}
