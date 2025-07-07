using RisckTrack.WEB.Models;
using System.Net.Http.Json;

namespace RisckTrack.WEB.Services
{
    public class UserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UserDto>?> GetUsersAsync()
        {
            return await _http.GetFromJsonAsync<List<UserDto>>("api/Users");
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<UserDto>($"api/Users/{id}");
        }

        public async Task<bool> CreateUserAsync(UserDto user)
        {
            var response = await _http.PostAsJsonAsync("api/Users", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUserAsync(int id, UserDto user)
        {
            var response = await _http.PutAsJsonAsync($"api/Users/{id}", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Users/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
