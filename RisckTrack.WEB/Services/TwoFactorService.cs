using RisckTrack.WEB.Models;
namespace RisckTrack.WEB.Services
{
    public class TwoFactorService
    {
        private readonly HttpClient _client;

        public TwoFactorService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserLoginResponse?> VerifyCodeAsync(string email, string code)
        {
            var dto = new User2FAVerifyDto
            {
                Email = email,
                Code = code
            };

            var response = await _client.PostAsJsonAsync("api/Auth/verify-2fa", dto);
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<UserLoginResponse>();
        }
    }
}
