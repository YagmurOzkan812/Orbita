using System.Collections.Generic;

namespace OrbinatAPI.Models
{
    public static class Database
    {
        public static List<CompanyProfile> GetAllCompanies()
        {
            return new List<CompanyProfile>
            {
                new CompanyProfile { Name = "Orbital Dynamics", HasOBC = true, HasEPS = true, HasADCS = true, HasCOMMS = true, HasPayload = true, HasThermalTest = true, HasVibrationTest = true, ExperienceLevel = "High", BudgetLevel = "High", MissionFit = "Earth Observation" },
                new CompanyProfile { Name = "NovaSpace Systems", HasOBC = true, HasEPS = true, HasADCS = false, HasCOMMS = true, HasPayload = false, HasThermalTest = false, HasVibrationTest = false, ExperienceLevel = "Medium", BudgetLevel = "Medium", MissionFit = "Communication" },
                new CompanyProfile { Name = "AstroLink Technologies", HasOBC = true, HasEPS = false, HasADCS = true, HasCOMMS = true, HasPayload = false, HasThermalTest = false, HasVibrationTest = false, ExperienceLevel = "Medium", BudgetLevel = "Low", MissionFit = "Communication" },
                new CompanyProfile { Name = "Celestial Labs", HasOBC = false, HasEPS = true, HasADCS = true, HasCOMMS = false, HasPayload = true, HasThermalTest = true, HasVibrationTest = true, ExperienceLevel = "Medium", BudgetLevel = "Medium", MissionFit = "Earth Observation" },
                new CompanyProfile { Name = "SkyForge Aerospace", HasOBC = true, HasEPS = true, HasADCS = true, HasCOMMS = false, HasPayload = false, HasThermalTest = false, HasVibrationTest = false, ExperienceLevel = "Medium", BudgetLevel = "Low", MissionFit = "Tech Demo" },
                new CompanyProfile { Name = "StellarCore Engineering", HasOBC = true, HasEPS = true, HasADCS = true, HasCOMMS = true, HasPayload = false, HasThermalTest = true, HasVibrationTest = true, ExperienceLevel = "High", BudgetLevel = "High", MissionFit = "Earth Observation" },
                new CompanyProfile { Name = "CosmoWorks", HasOBC = false, HasEPS = true, HasADCS = false, HasCOMMS = true, HasPayload = true, HasThermalTest = false, HasVibrationTest = false, ExperienceLevel = "Low", BudgetLevel = "Low", MissionFit = "Research" },
                new CompanyProfile { Name = "AetherSpace", HasOBC = true, HasEPS = false, HasADCS = true, HasCOMMS = false, HasPayload = false, HasThermalTest = false, HasVibrationTest = false, ExperienceLevel = "Low", BudgetLevel = "Low", MissionFit = "Tech Demo" },
                new CompanyProfile { Name = "Orbitronix", HasOBC = true, HasEPS = true, HasADCS = true, HasCOMMS = true, HasPayload = true, HasThermalTest = false, HasVibrationTest = false, ExperienceLevel = "High", BudgetLevel = "Medium", MissionFit = "Earth Observation" },
                new CompanyProfile { Name = "Zenith Space Solutions", HasOBC = false, HasEPS = false, HasADCS = true, HasCOMMS = true, HasPayload = false, HasThermalTest = true, HasVibrationTest = true, ExperienceLevel = "Medium", BudgetLevel = "Medium", MissionFit = "Communication" },
                new CompanyProfile { Name = "HyperNova Systems", HasOBC = true, HasEPS = true, HasADCS = false, HasCOMMS = true, HasPayload = true, HasThermalTest = true, HasVibrationTest = false, ExperienceLevel = "Medium", BudgetLevel = "High", MissionFit = "Earth Observation" },
                new CompanyProfile { Name = "LunaTech Industries", HasOBC = true, HasEPS = false, HasADCS = false, HasCOMMS = true, HasPayload = true, HasThermalTest = false, HasVibrationTest = false, ExperienceLevel = "Low", BudgetLevel = "Low", MissionFit = "Tech Demo" },
                new CompanyProfile { Name = "VectorSpace Labs", HasOBC = false, HasEPS = true, HasADCS = true, HasCOMMS = false, HasPayload = false, HasThermalTest = true, HasVibrationTest = true, ExperienceLevel = "Medium", BudgetLevel = "Medium", MissionFit = "Research" },
                new CompanyProfile { Name = "AstroBridge", HasOBC = true, HasEPS = true, HasADCS = true, HasCOMMS = true, HasPayload = false, HasThermalTest = false, HasVibrationTest = true, ExperienceLevel = "High", BudgetLevel = "High", MissionFit = "Earth Observation" },
                new CompanyProfile { Name = "Kepler Innovations", HasOBC = true, HasEPS = true, HasADCS = false, HasCOMMS = false, HasPayload = true, HasThermalTest = false, HasVibrationTest = false, ExperienceLevel = "Medium", BudgetLevel = "Medium", MissionFit = "Research" }
            };
        }
    }
}