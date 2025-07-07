namespace RisckTrack.WEB.Models
{
    public class RiskTreatmentRequest
    {
        public string AssetId { get; set; } = string.Empty;
        public double ControlCost { get; set; }
        public double EstimatedReductionFactor { get; set; }
    }

    public class RiskTreatmentResponse
    {
        public string AssetId { get; set; } = string.Empty;
        public double Ale_Inicial { get; set; }
        public double Ale_Residual { get; set; }
        public double ControlCost { get; set; }
        public double GananciaNeta { get; set; }
        public double Rosi { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
