using System.Collections.Generic;

namespace OrbinatAPI.Models
{
    // 1 Tek Bir Şirket Kartı Şablonu
    public class CompanyRecommendation
    {
        public string CompanyName { get; set; }
        public int Score { get; set; }
        public string Explanation { get; set; }
        public List<string> MatchedFeatures { get; set; }
        public List<string> MissingFeatures { get; set; }
    }

    // 2 Melike'ye Gidecek Olan Ana Şablon
    public class MissionResponse
    {
        public string MissionType { get; set; }
        public string PlatformSize { get; set; }

        // Şirketlerin Listesi
        public List<CompanyRecommendation> Recommendations { get; set; }

        //  Risklerin Listeleri
        public List<string> Risks { get; set; }
        
    }
} 