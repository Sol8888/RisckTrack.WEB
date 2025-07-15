using RisckTrack.WEB.Models;

namespace RisckTrack.WEB.Services
{
    public class ChatbotService
    {
        //private readonly HttpClient _httpClient;
        //// Esta es la URL que configuraste en Kong
        //private readonly string _chatbotApiUrl = "http://localhost:8000/riskTrackerChatBot/ask";

        //public ChatbotService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //public async Task<string> GetAnswer(string question)
        //{
        //    try
        //    {
        //        var request = new ChatbotRequest { Text = question };
        //        var response = await _httpClient.PostAsJsonAsync(_chatbotApiUrl, request);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var apiResponse = await response.Content.ReadFromJsonAsync<ChatbotResponse>();
        //            return apiResponse?.Answer ?? "No he podido obtener una respuesta.";
        //        }
        //        else
        //        {
        //            return $"Error: No se pudo conectar con el servidor ({response.StatusCode}).";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Puedes registrar el error ex para depuración
        //        return "Lo siento, hay un problema de conexión con nuestro asistente.";
        //    }
        //}
    }
}
