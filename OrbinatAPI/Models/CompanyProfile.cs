namespace OrbinatAPI.Models
{
    public class CompanyProfile
    {
        public string Name { get; set; }
        public bool HasOBC { get; set; }
        public bool HasEPS { get; set; }
        public bool HasADCS { get; set; }
        public bool HasCOMMS { get; set; }
        public bool HasPayload { get; set; }
        public bool HasThermalTest { get; set; }
        public bool HasVibrationTest { get; set; }
        public string ExperienceLevel { get; set; }
        public string BudgetLevel { get; set; }
        public string MissionFit { get; set; }
        public int TotalMissions { get; set; }
        public double SuccessRate { get; set; }
        public string DeliveryTime { get; set; }
        public double MassKg { get; set; }
        public string Reliability { get; set; }
        public string ImageUrl { get; set; }
    }
}