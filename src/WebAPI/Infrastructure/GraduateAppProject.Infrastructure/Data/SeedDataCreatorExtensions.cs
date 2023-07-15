using Bogus;
using GraduateAppProject.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Infrastructure.Data
{
    public static class SeedDataCreatorExtensions
    {
        public static Citizen CreateFakeCitizens(IConfiguration configuration)
        {
            // Create a new Citizen instance
            Citizen citizen = new();

            // Generate a random value to determine the gender of the citizen
            var isMale = new Random().Next(0, 2);

            // Generate a random first name based on the gender
            if (isMale == 0)
            {
                // If the citizen is male, generate a male first name
                citizen.FirstName = new Faker("tr").Name.FirstName(gender: Bogus.DataSets.Name.Gender.Male).ToLowerInvariant();
            }
            else
            {
                // If the citizen is female, generate a female first name
                citizen.FirstName = new Faker("tr").Name.FirstName(gender: Bogus.DataSets.Name.Gender.Female).ToLowerInvariant();
            }

            // Generate a random last name
            citizen.LastName = new Faker("tr").Name.LastName().ToLowerInvariant();

            // Generate a random birth date
            citizen.BirthDate = (new Faker().Person.DateOfBirth).Date;

            // Generate a random citizen number
            var randomCitizenNumber = (new Faker().Random.Long(10000000000, 99999999999)).ToString();
            citizen.CitizenNumber = randomCitizenNumber.EncryptWithHash(configuration);

            // Generate random mother and father names
            citizen.MotherName = new Faker("tr").Name.FirstName(gender: Bogus.DataSets.Name.Gender.Female).ToLowerInvariant();
            citizen.FatherName = new Faker("tr").Name.FirstName(gender: Bogus.DataSets.Name.Gender.Male).ToLowerInvariant();

            // Generate a random birth place
            citizen.BirthPlace = new Faker("tr").Person.Address.City.ToLowerInvariant();

            // Generate fake YdsExam, AlesExam, MasterDegree, BachelorDegree, and DoctorateDegree for the citizen
            citizen.YdsExams.Add(CreateFakeYdsExam());
            citizen.AlesExams.Add(CreateFakeAlesExam());
            citizen.MasterDegrees.Add(CreateFakeMasterDegree());
            citizen.BachelorDegrees.Add(CreateFakeBachelorDegree());
            citizen.DoctorateDegrees.Add(CreateFakeDoctorateDegree());

            // Return the generated citizen
            return citizen;
        }


        private static DoctorateDegree CreateFakeDoctorateDegree()
        {
            var startDate = new Faker().Date.Between(new DateTime(2005, 1, 1), new DateTime(2018, 12, 31));
            var endDate = startDate.AddYears(4);
            var doctorate = new DoctorateDegree()
            {
                GraduateMajorId = new Faker().Random.Int(1, 101),
                IsActive = true,
                StartDate = startDate,
                EndDate = endDate,
                DiplomaUrl = "https://www.harftamircisi.com/wp-content/uploads/2011/12/certificate-autfdiploma.jpg",
                LanguageId = (new Faker().Random.Int(1, 10))
            };
            return doctorate;
        }

        private static BachelorDegree CreateFakeBachelorDegree()
        {
            var startDate = new Faker().Date.Between(new DateTime(1975, 1, 1), new DateTime(2005, 12, 31));
            var endDate = startDate.AddYears(4);
            var gradeType = (new Faker().Random.Bool()) ? 100 : 4;
            var bachelor = new BachelorDegree()
            {
                DepartmentId = new Faker().Random.Int(400, 16867),
                IsActive = true,
                StartDate = startDate,
                EndDate = endDate,
                GradeType = gradeType,
                DegreeGrade = gradeType == 100 ? (new Faker().Random.Decimal(50, 100)) : (new Faker().Random.Decimal(2.5M, 4M)),
                WithThesis = new Faker().Random.Bool(),
                LanguageId = (new Faker().Random.Int(1, 10)),
                DiplomaUrl = "https://www.harftamircisi.com/wp-content/uploads/2011/12/certificate-autfdiploma.jpg",
                TranscriptUrl = "https://www.harftamircisi.com/wp-content/uploads/2011/12/certificate-autfdiploma.jpg"

            };
            return bachelor;
        }

        private static MasterDegree CreateFakeMasterDegree()
        {
            var startDate = new Faker().Date.Between(new DateTime(1975, 1, 1), new DateTime(2005, 12, 31));
            var endDate = startDate.AddYears(4);
            var gradeType = (new Faker().Random.Bool()) ? 100 : 4;
            var master = new MasterDegree()
            {
                DepartmentId = new Faker().Random.Int(400, 16867),
                IsActive = true,
                StartDate = startDate,
                EndDate = endDate,
                GradeType = gradeType,
                DegreeGrade = gradeType == 100 ? (new Faker().Random.Decimal(50, 100)) : (new Faker().Random.Decimal(2.5M, 4M)),
                WithThesis = new Faker().Random.Bool(),
                LanguageId = (new Faker().Random.Int(1, 10)),
                DiplomaUrl = "https://www.harftamircisi.com/wp-content/uploads/2011/12/certificate-autfdiploma.jpg",
                TranscriptUrl = "https://www.harftamircisi.com/wp-content/uploads/2011/12/certificate-autfdiploma.jpg"
            };
            return master;
        }

        private static AlesExam CreateFakeAlesExam()
        {
            var ales = new AlesExam()
            {
                DocumentUrl = "https://www.memurlar.net/common/news/documents/871060/ales2.jpg",
                AlesEsitAgirlikGrade = new Faker().Random.Decimal(50, 100),
                AlesSayisalGrade = new Faker().Random.Decimal(50, 100),
                AlesSozelGrade = new Faker().Random.Decimal(50, 100),
                Year = new Faker().Random.Int(2015, 2022)
            };
            return ales;

        }

        public static YdsExam CreateFakeYdsExam()
        {
            YdsExam yds = new();

            yds.DocumentUrl = "https://www.demethocaydsyokdil.com/wp-content/uploads/2021/05/sonuc-belgesi-SEVILAY-GULERCE.jpg";
            yds.YdsGrade = new Faker().Random.Decimal(50, 100);
            yds.Year = new Faker().Random.Int(2015, 2022);

            return yds;
        }


        public static string EncryptWithHash(this string citizenNumber, IConfiguration configuration)
        {
            var key = configuration["EncryptKey:RandomKey"];
            byte[] data = UTF8Encoding.UTF8.GetBytes(citizenNumber);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (var tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        public static string DecryptWithHash(this string hashedCitizenNumber, IConfiguration configuration)
        {
            var key = configuration["EncryptKey:RandomKey"];

            byte[] data = Convert.FromBase64String(hashedCitizenNumber); // decrypt the incrypted text
            var returnVal = string.Empty;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    returnVal = UTF8Encoding.UTF8.GetString(results);
                }
            }

            return returnVal;
        }
    }
}
