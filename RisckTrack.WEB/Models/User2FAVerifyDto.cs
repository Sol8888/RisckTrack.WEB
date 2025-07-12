using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RisckTrack.WEB.Models
{
    public class User2FAVerifyDto
    {

        public string Email { get; set; }

        [Required(ErrorMessage = "El campo codigo es obligatorio.")]
        [JsonPropertyName("Code")]
        public string Code { get; set; }

    }
}
