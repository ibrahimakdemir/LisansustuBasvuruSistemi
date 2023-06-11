namespace GraduateAppProject.MVC.Extensions
{
    public static class GetCitizenInformationsExtensions
    {
        public static async Task<dynamic> GetCitizenInformations(this HttpClient httpClient, int citizenId)
        {
            string apiUrl = $"https://localhost:7084/api/Citizen/{citizenId}";

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            else
            {
                throw new HttpRequestException($"API request failed with status code: {response.StatusCode}");
            }
        }
    }
}
