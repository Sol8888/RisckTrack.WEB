using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RisckTrack.WEB.Models
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [JsonPropertyName("Email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [JsonPropertyName("Password")]
        public string Password { get; set; } = string.Empty;
    }
}
