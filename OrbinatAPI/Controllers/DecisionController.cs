using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using OrbinatAPI.Models;

namespace OrbinatAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecisionController : ControllerBase
    {
        [HttpPost("evaluate")]
        public ActionResult<MissionResponse> EvaluateMission([FromBody] MissionRequest request)
        {
            var allCompanies = Database.GetAllCompanies();
            var scoredCompanies = new List<CompanyRecommendation>();
            var globalRisks = new List<string>();

            foreach (var comp in allCompanies)
            {
                int currentScore = 0;
                var matched = new List<string>();
                var missing = new List<string>();

                // 1. CAPABILITY (Maks 15 Puan - Her biri 3)
                if (comp.HasOBC) { currentScore += 3; matched.Add("OBC"); } else { missing.Add("OBC"); }
                if (comp.HasEPS) { currentScore += 3; matched.Add("EPS"); } else { missing.Add("EPS"); }
                if (comp.HasADCS) { currentScore += 3; matched.Add("ADCS"); } else { missing.Add("ADCS"); }
                if (comp.HasCOMMS) { currentScore += 3; matched.Add("COMMS"); } else { missing.Add("COMMS"); }
                if (comp.HasPayload) { currentScore += 3; matched.Add("Payload"); } else { missing.Add("Payload"); }

                // 2. TESTLER (Maks 20 Puan - İsteniyorsa 10'ar puan)
                if (request.RequireThermal)
                {
                    if (comp.HasThermalTest) { currentScore += 10; matched.Add("Thermal Test"); }
                    else { currentScore -= 5; missing.Add("Thermal Test"); globalRisks.Add($"{comp.Name}: İstenen Termal Test eksik."); }
                }
                else if (comp.HasThermalTest) { currentScore += 2; matched.Add("Thermal (Bonus)"); }

                if (request.RequireVibration)
                {
                    if (comp.HasVibrationTest) { currentScore += 10; matched.Add("Vibration Test"); }
                    else { currentScore -= 5; missing.Add("Vibration Test"); globalRisks.Add($"{comp.Name}: İstenen Titreşim Testi eksik."); }
                }
                else if (comp.HasVibrationTest) { currentScore += 2; matched.Add("Vibration (Bonus)"); }

                // 3. EXPERIENCE & BUDGET (Maks 20 Puan)
                if (comp.ExperienceLevel == "High") currentScore += 10;
                else if (comp.ExperienceLevel == "Medium") currentScore += 5;

                if (comp.BudgetLevel == request.BudgetLevel) currentScore += 10;
                else if (request.BudgetLevel == "High") currentScore += 5;

                // 4. MISSION FIT (Maks 15 Puan)
                if (comp.MissionFit == request.MissionType)
                {
                    currentScore += 15;
                    matched.Add("Mission Alignment");
                }
                else
                {
                    currentScore -= 5;
                    globalRisks.Add($"{comp.Name} uzmanlığı ({comp.MissionFit}) görevinizle uyuşmuyor.");
                }

                // 5. FLIGHT HERITAGE (Maks 10 Puan)
                if (comp.SuccessRate >= 90) { currentScore += 10; matched.Add($"Yüksek Başarı (%{comp.SuccessRate})"); }
                else if (comp.SuccessRate >= 75) { currentScore += 5; }
                else if (comp.TotalMissions > 0)
                {
                    currentScore -= 10;
                    missing.Add($"Düşük Başarı (%{comp.SuccessRate})");
                    globalRisks.Add($"{comp.Name}: Tarihsel başarı oranı tehlikeli (%{comp.SuccessRate}).");
                }

                if (comp.TotalMissions >= 20) matched.Add("Sektör Lideri");
                else if (comp.TotalMissions == 0) globalRisks.Add($"{comp.Name}: Sıfır Uçuş Geçmişi!");

                // 6. SWaP ANALİZİ (Maks 10 Puan)
                if (request.PlatformSize == "1U" && comp.MassKg > 1.3)
                {
                    currentScore -= 15;
                    missing.Add("SWaP İhlali (Ağır)");
                    globalRisks.Add($"{comp.Name}: 1U platform için kütle limiti aşıldı ({comp.MassKg}kg).");
                }
                else
                {
                    currentScore += 10;
                    matched.Add($"Kütle Uygun ({comp.MassKg}kg)");
                }

                // 7. TESLİMAT SÜRESİ (Maks 5 Puan)
                if (comp.DeliveryTime == "Fast") { currentScore += 5; matched.Add("Hızlı Teslimat"); }
                else if (comp.DeliveryTime == "Medium") { currentScore += 2; }
                else if (comp.DeliveryTime == "Slow")
                {
                    missing.Add("Yavaş Teslimat");
                    globalRisks.Add($"{comp.Name}: Teslimat süresi yavaş. Gecikme riski.");
                }

                // 8. GÜVENİLİRLİK (Maks 5 Puan)
                if (comp.Reliability == "High") { currentScore += 5; matched.Add("Yüksek Güvenilirlik"); }
                else if (comp.Reliability == "Medium") { currentScore += 2; }
                else if (comp.Reliability == "Low")
                {
                    currentScore -= 10;
                    missing.Add("Düşük Güvenilirlik");
                    globalRisks.Add($"{comp.Name}: Donanım güvenilirliği düşük.");
                }

                // Skor 0 ile 100 arasında
                if (currentScore > 100) currentScore = 100;
                if (currentScore < 0) currentScore = 0;

                // Değerlendirilen şirketi listeye ekle
                scoredCompanies.Add(new CompanyRecommendation
                {
                    CompanyName = comp.Name,
                    Score = currentScore,
                    Explanation = $"{currentScore} Puanlık Eşleşme Oranı.",
                    MatchedFeatures = matched,
                    MissingFeatures = missing,
                    TotalMissions = comp.TotalMissions,
                    SuccessRate = comp.SuccessRate,
                    DeliveryTime = comp.DeliveryTime,
                    MassKg = comp.MassKg,
                    Reliability = comp.Reliability,
                    ImageUrl = comp.ImageUrl // fotoğraf
                });
            }

            // Puanı en yüksek 3 şirketi seç
            var top3 = scoredCompanies.OrderByDescending(x => x.Score).Take(3).ToList();

            return Ok(new MissionResponse
            {
                MissionType = request.MissionType,
                PlatformSize = request.PlatformSize,
                Recommendations = top3,
                Risks = globalRisks.Distinct().ToList()
            });
        }
    }
}