using RisckTrack.WEB.Models;
using System.Net.Http.Json; 

namespace RisckTrack.WEB.Services
{
    public class ChatbotService
    {
        private readonly HttpClient _httpClient;
        private readonly string _chatbotApiUrl = "https://localhost:8443/riskTrackerChatbot/ask";

        public ChatbotService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAnswer(string question)
        {
            try
            {
                var request = new ChatbotRequest { Text = question };
                var response = await _httpClient.PostAsJsonAsync(_chatbotApiUrl, request);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<ChatBotResponse>();
                    return apiResponse?.Answer ?? "No he podido obtener una respuesta.";
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error del API: {response.StatusCode} - {errorContent}");
                    return $"Error: No se pudo conectar con el servidor ({response.StatusCode}).";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción en el servicio del Chatbot: {ex.Message}");
                return "Lo siento, hay un problema de conexión con nuestro asistente.";
            }
        }
    }
}