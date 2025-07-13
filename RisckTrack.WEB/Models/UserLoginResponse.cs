namespace RisckTrack.WEB.Models
{
    public class UserLoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int? CompanyId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
