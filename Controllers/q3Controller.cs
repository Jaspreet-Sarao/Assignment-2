using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment__2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q3Controller : ControllerBase
    {
        private static readonly Dictionary<string, int> pepperSHU = new Dictionary<string, int>
        {
            { "Poblano", 1500 },
            { "Mirasol", 6000 },
            { "Serrano", 15500 },
            { "Cayenne", 40000 },
            { "Thai", 75000 },
            { "Habanero", 125000 }
        };
        /// <summary>
        /// Computes the overall spiciness level of a chili dish using the provided ingredients.
        /// </summary>
        /// <param name="ingredients">A list of pepper names separated by commas.</param>
        /// <returns>The total spiciness measured in Scoville Heat Units (SHU).</returns>
        /// <example>
        /// GET /api/J2/ChiliPeppers?ingredients=Poblano,Cayenne,Thai,Poblano
        /// Response: 118000
        /// </example>
        [HttpGet]
        public int Chillipepper([FromQuery] string ingredients)
        {
            int totalSHU = 0;
            string[] peppers = ingredients.Split(',');

            foreach (var pepper in peppers)
            {
                if (pepperSHU.ContainsKey(pepper.Trim()))
                {
                    totalSHU += pepperSHU[pepper.Trim()];
                }
            }

            return totalSHU;
        }
    }
}

