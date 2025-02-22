using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment__2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q2Controller : ControllerBase
    {
        /// <summary>
        /// Computes the number of leftover cupcakes after baking and selling.
        /// Each batch of cupcakes baked (regularBoxes) contains 8 cupcakes, and each batch sold (smallBoxes) contains 3 cupcakes.
        /// The final count is determined by subtracting 28 from the total cupcakes.
        /// </summary>
        /// <param name="regularBoxes">The number of batches baked, where each batch contains 8 cupcakes.</param>
        /// <param name="smallBoxes">The number of batches sold, where each batch contains 3 cupcakes.</param>
        /// <returns>The number of leftover cupcakes after accounting for 28 cupcakes.</returns>
        /// <example>
        /// GET /api/q2/cupcakes?regularBoxes=3&smallBoxes=4
        /// Returns: 8
        /// </example>
        [HttpGet("Cupcakes")]
        public IActionResult Cupcakes(int regularBoxes, int smallBoxes)
        {
            // Validate input
            if (regularBoxes < 0 || smallBoxes < 0)
            {
                return BadRequest("Input values must be non-negative integers.");
            }

            // Determine the total number of cupcakes produced
            int totalCupcakes = (regularBoxes * 8) + (smallBoxes * 3);

            // Calculate the excess cupcakes after subtracting 28
            int remainingCupcakes = totalCupcakes - 28;

            // Return the remaining cupcakes as a JSON response
            return Ok(new { RemainingCupcakes = remainingCupcakes });
        }
    }
}
