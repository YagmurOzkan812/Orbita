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

                // 1. CAPABILITY (%25)
                if (comp.HasOBC) { currentScore += 5; matched.Add("OBC"); } else { missing.Add("OBC"); }
                if (comp.HasEPS) { currentScore += 5; matched.Add("EPS"); } else { missing.Add("EPS"); }
                if (comp.HasADCS) { currentScore += 5; matched.Add("ADCS"); } else { missing.Add("ADCS"); }
                if (comp.HasCOMMS) { currentScore += 5; matched.Add("COMMS"); } else { missing.Add("COMMS"); }
                if (comp.HasPayload) { currentScore += 5; matched.Add("Payload"); } else { missing.Add("Payload"); }

                // 2 & 3. TESTLER (%30)
                if (request.RequireThermal)
                {
                    if (comp.HasThermalTest) { currentScore += 15; matched.Add("Thermal Test"); }
                    else { missing.Add("Thermal Test"); globalRisks.Add($"{comp.Name}: Termal Test eksik."); }
                }
                else if (comp.HasThermalTest) { currentScore += 5; matched.Add("Thermal (Bonus)"); }

                if (request.RequireVibration)
                {
                    if (comp.HasVibrationTest) { currentScore += 15; matched.Add("Vibration Test"); }
                    else { missing.Add("Vibration Test"); globalRisks.Add($"{comp.Name}: Titreşim Testi eksik."); }
                }
                else if (comp.HasVibrationTest) { currentScore += 5; matched.Add("Vibration (Bonus)"); }

                // 4. EXPERIENCE (%15)
                if (comp.ExperienceLevel == "High") currentScore += 15;
                else if (comp.ExperienceLevel == "Medium") currentScore += 10;
                else currentScore += 5;

                // 5. BUDGET (%15)
                if (comp.BudgetLevel == request.BudgetLevel) currentScore += 15;
                else currentScore += 10;

                // 6. MISSION FIT (%15)
                if (comp.MissionFit == request.MissionType)
                {
                    currentScore += 15;
                    matched.Add("Mission Alignment");
                }
                else
                {
                    globalRisks.Add($"{comp.Name} uzmanlığı: {comp.MissionFit}.");
                }

                scoredCompanies.Add(new CompanyRecommendation
                {
                    CompanyName = comp.Name,
                    Score = currentScore,
                    Explanation = $"{currentScore} puan. Görev analizi tamamlandı.",
                    MatchedFeatures = matched,
                    MissingFeatures = missing
                });
            }

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