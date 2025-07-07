namespace RisckTrack.WEB.Models
{
    public class IncidentDto
    {
        public int IncidentId { get; set; }
        public string AssetId { get; set; } = string.Empty;
        public DateTime IncidentDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public int? ResolutionDurationHours { get; set; }
        public int? ImpactDurationMinutes { get; set; }
    }
}
