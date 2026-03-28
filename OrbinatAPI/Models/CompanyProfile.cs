namespace OrbinatAPI.Models
{
    // veritabanımızdaki tek bir şirketin özelliklerini tutan şablon
    public class CompanyProfile
    {
        public string Name { get; set; }

        // Kapasiteler (Var-Yok)
        public bool HasOBC { get; set; }
        public bool HasEPS { get; set; }
        public bool HasADCS { get; set; }
        public bool HasCOMMS { get; set; }
        public bool HasPayload { get; set; }

        // Test Altyapıları
        public bool HasThermalTest { get; set; }
        public bool HasVibrationTest { get; set; }

        // Deneyim ve Bütçe
        public string ExperienceLevel { get; set; } // "low", "medium","high"
        public string BudgetLevel { get; set; } // "Low", "Medium", "High"
        public string MissionFit { get; set; }
    }
}