namespace RisckTrack.WEB.Services
{
    public class UserSessionService
    {
        public int? UserId { get; private set; }
        public int? CompanyId { get; private set; }
        public string Role { get; private set; } = string.Empty;
        public bool IsLoggedIn => UserId.HasValue;

        public void SetSession(int userId, int? companyId, string role)
        {
            UserId = userId;
            CompanyId = companyId;
            Role = role;
        }

        public void ClearSession()
        {
            UserId = null;
            CompanyId = null;
            Role = string.Empty;
        }
    }
}

