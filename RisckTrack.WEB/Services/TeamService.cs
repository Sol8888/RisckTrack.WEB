using RisckTrack.WEB.Models;

namespace RisckTrack.WEB.Services
{
    public class TeamService
    {
        private readonly HttpClient _http;

        public TeamService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TeamDto>?> GetTeamsAsync()
        {
            return await _http.GetFromJsonAsync<List<TeamDto>>("api/Teams");
        }

        public async Task<bool> CreateTeamAsync(TeamDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/Teams", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Teams/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
