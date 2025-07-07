using System.Net.Http.Json;
using RisckTrack.WEB.Models;

namespace RisckTrack.WEB.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserLoginResponse?> LoginAsync(UserLoginDto request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Users/login", request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<UserLoginResponse>();
                return result;
            }

            return null;
        }
    }
}
