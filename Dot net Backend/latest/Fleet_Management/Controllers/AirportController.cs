using Fleet_Management.Models;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management.Controllers
{
    [Route("/api/airports")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AirportMaster>>> GetAllAirportAsync()
        {
            var airports = await _airportService.GetAllAirportAsync();
            if (airports == null || !airports.Any())
            {
                return NoContent();
            }
            return Ok(airports);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<AirportMaster>> GetAirportByIdAsync(long id)
        {
            var airport = await _airportService.GetAirportByIdAsync(id);
            if (airport == null)
            {
                return NotFound($"Airport with ID {id} not found.");
            }
            return Ok(airport);
        }

        [HttpGet("code/{airportCode}")]
        public async Task<ActionResult<AirportMaster>> GetAirportByCodeAsync(string airportCode)
        {
            var airport = await _airportService.GetAirportByCodeAsync(airportCode);
            if (airport == null)
            {
                return NotFound($"Airport with code '{airportCode}' not found.");
            }
            return Ok(airport);
        }
    }
}
