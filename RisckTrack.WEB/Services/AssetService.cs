using RisckTrack.WEB.Models;

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

        public async Task<AssetDto?> GetAssetByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<AssetDto>($"api/Assets/{id}");
        }

        public async Task<bool> CreateAssetAsync(AssetDto asset)
        {
            var response = await _http.PostAsJsonAsync("api/Assets", asset);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAssetAsync(string id, AssetDto asset)
        {
            var response = await _http.PutAsJsonAsync($"api/Assets/{id}", asset);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAssetAsync(string id)
        {
            var response = await _http.DeleteAsync($"api/Assets/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<RiskAnalysisResult?> GetRiskAnalysisAsync(string assetId)
        {
            return await _http.GetFromJsonAsync<RiskAnalysisResult>($"api/RiskAnalysis/full/{assetId}");
        }
    }
}
