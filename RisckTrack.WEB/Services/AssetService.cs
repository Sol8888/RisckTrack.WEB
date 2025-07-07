using RisckTrack.WEB.Models;
using System.Net.Http.Json;

namespace RisckTrack.WEB.Services
{
    public class AssetService
    {
        private readonly HttpClient _http;

        public AssetService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AssetDto>?> GetAssetsAsync()
        {
            return await _http.GetFromJsonAsync<List<AssetDto>>("api/Assets");
        }

        public async Task<AssetDto?> GetAssetByIdAsync(string assetId)
        {
            return await _http.GetFromJsonAsync<AssetDto>($"api/Assets/{assetId}");
        }

        public async Task<bool> CreateAssetAsync(AssetDto asset)
        {
            var response = await _http.PostAsJsonAsync("api/Assets", asset);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAssetAsync(int id, AssetDto asset)
        {
            var response = await _http.PutAsJsonAsync($"api/Assets/{id}", asset);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAssetAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Assets/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
