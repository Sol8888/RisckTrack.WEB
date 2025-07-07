namespace RisckTrack.WEB.Models
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Leader { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
    }
}
