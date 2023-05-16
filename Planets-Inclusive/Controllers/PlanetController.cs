using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planets_Inclusive.Services;

namespace Planets_Inclusive.Controllers
{
    [Route("api/planet")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            this._planetService = planetService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetPlanetNames()
        {
            var res = await this._planetService.GetAllNames();
            return Ok(res);

        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPlanetByName(string name)
        {
            var res = await this._planetService.GetByName(name);
            return Ok(res);
        }
    }
}
