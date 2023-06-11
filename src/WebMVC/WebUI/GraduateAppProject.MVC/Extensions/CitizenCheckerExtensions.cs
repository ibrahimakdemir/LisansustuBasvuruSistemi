using GraduateAppProject.MVC.Models;
using System.Text.RegularExpressions;

namespace GraduateAppProject.MVC.Extensions
{
    public static class CitizenCheckerExtensions
    {
        private const string checkerApiURL = "https://localhost:7084/api/Citizen/CheckCitizen";

        public static int CheckAndGetCitizenId(this CitizenCheckerModel checkerModel, IConfiguration configuration)
        {
            

            //checkerModel.FirstName = "recep";
            //checkerModel.LastName = "tuğlu";
            //checkerModel.CitizenNumber = "VhwrcVkRa+41v3otU1vUFg==";
            //checkerModel.BirthYear = 2002;
            checkerModel.CitizenNumber = checkerModel.CitizenNumber.EncryptWithHash(configuration);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync(checkerApiURL, checkerModel).Result;

            if (response.Headers.Location != null)
            {
                string location = response.Headers.Location.ToString();
                Match match = Regex.Match(location, @"/(\d+)$");

                if (match.Success && int.TryParse(match.Groups[1].Value, out int id))
                {
                    return id;
                }
            }

            return 0;
        }
    }
}
