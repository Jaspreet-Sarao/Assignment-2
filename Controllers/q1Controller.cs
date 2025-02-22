using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment__2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q1Controller : ControllerBase
    {
        /// <summary>
        /// Computes the final score for a delivery robot based on its deliveries and collisions.
        /// The formula used is: (Deliveries × 50) - (Collisions × 10).
        /// If the robot completes more deliveries than collisions, a bonus of 500 points is awarded.
        /// </summary>
        /// <param name="collisions">The total number of obstacles the robot collided with.</param>
        /// <param name="deliveries">The total number of successful deliveries made by the robot.</param>
        /// <returns>The final score reflecting the robot's overall performance.</returns>
        /// <example>
        /// Example Input:
        /// collisions = 3
        /// deliveries = 8
        ///
        /// Calculation Steps:
        /// 1. Compute the base score: (8 × 50) - (3 × 10) = 400 - 30 = 370.
        /// 2. Since deliveries exceed collisions (8 > 3), add a 500-point bonus: 370 + 500 = 870.
        /// 
        /// Example Output:
        /// 870
        /// </example>
        [HttpPost("Delivedroid")]
        public IActionResult CalculateScore([FromForm] int collisions, [FromForm] int deliveries)
        {
            int total = (deliveries * 50) - (collisions * 10);
            if (deliveries > collisions)
            {
                total += 500; // Cleaner way of writing total = total + 500
            }
            return Ok(total);
        }
    }
}
