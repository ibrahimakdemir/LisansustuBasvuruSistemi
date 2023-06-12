using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Services.Extensions
{
    public static class ApiExtensions
    {
        private const string baseApiUrl = "https://localhost:7084/api/Citizen/";
        public static async Task<T> GetApiResponse<T>(this HttpClient httpClient, string endpoint)
        {
            string apiUrl = baseApiUrl + endpoint;
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(jsonResponse);
                return result;
            }
            else
            {
                throw new Exception($"API hatası: {response.StatusCode}");
            }
        }
    }
}
