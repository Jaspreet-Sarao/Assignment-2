using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment__2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q5Controller : ControllerBase
    {
        /// <summary>
        /// Identifies the bronze-level score and counts how many participants achieved it.
        /// </summary>
        /// <param name="scores">A list of scores from different participants.</param>
        /// <returns>An object containing the bronze-level score and the number of participants who attained it.</returns>
        /// <example>
        /// Example Input:
        /// [70, 62, 58, 73]
        ///
        /// Calculation Steps:
        /// 1. Arrange the scores in descending order -> [73, 70, 62, 58].
        /// 2. Identify the third unique** score (bronze level) -> 62.
        /// 3. Count how many participants scored 62 -> 1.
        ///
        /// Example Output:  
        /// { "BronzeScore": 62, "Count": 1 }
        /// </example>
        [HttpPost("calculate-bronze")]
        public IActionResult CalculateBronze([FromBody] List<int> scores)
        {
            // Ensure there are at least three unique scores
            if (scores.Distinct().Count() < 3)
            {
                return BadRequest("A minimum of three distinct scores is required.");
            }

            // Arrange scores from highest to lowest
            var sortedScores = scores.OrderByDescending(score => score).ToList();
            // Extract the third unique score (bronze-level score)
            int bronzeScore = sortedScores.Distinct().Skip(2).First();

            // Count participants who achieved this score
            int bronzeCount = scores.Count(score => score == bronzeScore);

            //Return the results as a JSON response
            return Ok(new { BronzeScore = bronzeScore, Count = bronzeCount });
        }
    }
}
