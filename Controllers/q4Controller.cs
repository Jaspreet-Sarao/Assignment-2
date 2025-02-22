using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment__2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q4Controller : ControllerBase
    {
        /// <summary>
        /// Determines how many players have a performance rating exceeding 40.
        /// The rating is computed using the formula: (2 × Points per game) + Rebounds per game.
        /// </summary>
        /// <param name="players">A list containing statistics for each player, including their Points (P) and Rebounds (R) per game.</param>
        /// <returns>The total count of players whose rating surpasses 40.</returns>
        /// <example>
        /// Example Input:
        /// [
        ///   { "P": 20, "R": 15 },
        ///   { "P": 18, "R": 10 },
        ///   { "P": 25, "R": 10 }
        /// ]
        /// Calculation Process:
        ///  Compute the rating for each player:
        ///    Player 1: (2 × 20) + 15 = 55 -> Above 40 
        ///    Player 2: (2 × 18) + 10 = 46 -> Above 40   
        ///    Player 3: (2 × 25) + 10 = 60 --> Above 40 
        /// All three players exceed 40, resulting in a final count of 3.
        /// Example Output:
        /// { "starPlayers": 3 }
        /// </example>
        [HttpPost("count-stars")]
        public IActionResult CountStarPlayers([FromBody] List<PlayerStats> players)
        {
            int count = 0;

            foreach (var player in players)
            {
                double starRating = (2 * player.P) + player.R;
                if (starRating > 40)
                {
                    count++;
                }
            }
            return Ok(new { starPlayers = count });
        }
    }

    public class PlayerStats
    {
        public int P { get; set; }  // Points scored per game
        public int R { get; set; }  // Rebounds per game
    }
    }
