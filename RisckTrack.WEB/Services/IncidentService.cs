using RisckTrack.WEB.Models;

namespace RisckTrack.WEB.Services
{
    public class IncidentService
    {
        private readonly HttpClient _http;

        public IncidentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<IncidentDto>?> GetIncidentsAsync()
        {
            return await _http.GetFromJsonAsync<List<IncidentDto>>("api/Incidents");
        }

        public async Task<bool> CreateIncidentAsync(IncidentDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/Incidents", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteIncidentAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Incidents/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
