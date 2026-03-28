namespace OrbinatAPI.Models
{
    public class MissionRequest
    {
        public string MissionType { get; set; }
        public string PlatformSize { get; set; }
        public string BudgetLevel { get; set; }
        public bool RequireThermal { get; set; }
        public bool RequireVibration { get; set; }
    }
}
