namespace RisckTrack.WEB.Models
{
    public class RiskAnalysisResult
    {
        public string AssetId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool ContainsPII { get; set; }
        public decimal RevenuePerMinuteUsd { get; set; }
        public decimal CriticalFlowPercentage { get; set; }
        public int TotalPiiRecords { get; set; }
        public decimal AnnualLicenseCostUsd { get; set; }
        public int AnnualSupportHours { get; set; }
        public decimal EngineerHourlyRateUsd { get; set; }
        public int MonthlyDowntimeMin { get; set; }
        public int AnnualCriticalVulnerabilities { get; set; }
        public int DataCorruptionErrors { get; set; }
        public decimal DecidedRiskUsd { get; set; }

        // Valores calculados
        public decimal Vna { get; set; }
        public double Si { get; set; }
        public int Lef { get; set; }
        public decimal Pd { get; set; }
        public decimal Pi { get; set; }
        public decimal Cr { get; set; }
        public decimal Ces { get; set; }
        public decimal Dpf { get; set; }
        public decimal Dirf { get; set; }
        public decimal Lm { get; set; }
        public decimal LM_Tipico { get; set; }
        public decimal Ale { get; set; }
        public decimal UmbralAceptable { get; set; }
        public bool RiesgoAceptado { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
