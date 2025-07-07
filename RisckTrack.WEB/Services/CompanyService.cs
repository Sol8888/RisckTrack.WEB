using RisckTrack.WEB.Models;
using System.Net.Http.Json;

namespace RisckTrack.WEB.Services
{
    public class CompanyService
    {
        private readonly HttpClient _http;

        public CompanyService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CompanyDto>?> GetCompaniesAsync()
        {
            return await _http.GetFromJsonAsync<List<CompanyDto>>("api/Companies");
        }

        public async Task<CompanyDto?> GetCompanyByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<CompanyDto>($"api/Companies/{id}");
        }

        public async Task<bool> CreateCompanyAsync(CompanyDto company)
        {
            var response = await _http.PostAsJsonAsync("api/Companies", company);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCompanyAsync(int id, CompanyDto company)
        {
            var response = await _http.PutAsJsonAsync($"api/Companies/{id}", company);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Companies/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
