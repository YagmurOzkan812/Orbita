using System.Collections.Generic;

namespace OrbinatAPI.Models
{
    public class MissionResponse
    {
        public string MissionType { get; set; }
        public string PlatformSize { get; set; }
        public List<CompanyRecommendation> Recommendations { get; set; }
        public List<string> Risks { get; set; }
    }

    public class CompanyRecommendation
    {
        public string CompanyName { get; set; }
        public int Score { get; set; }
        public string Explanation { get; set; }

        public List<string> MatchedFeatures { get; set; }
        public List<string> MissingFeatures { get; set; }
        public int TotalMissions { get; set; }
        public double SuccessRate { get; set; }
        public string DeliveryTime { get; set; }
        public double MassKg { get; set; }
        public string Reliability { get; set; }
        public string ImageUrl { get; set; }
    }
}