using Fleet_Management.Models;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management.Controllers
{
    [Route("api/hubs")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private readonly IHubService _hubService;

        public HubController(IHubService hubService)
        {
            _hubService = hubService;
        }
        [HttpGet]
        public async Task<ActionResult<List<HubMaster>>> GetAllHubsAsync()
        {
            var hubs = await _hubService.GetAllHubsAsync();
            return Ok(hubs);
        }

        [HttpGet("airport/{airportCode}")]
        public async Task<ActionResult<HubMaster>> GetHubsByAirportCodeAsync(string airportCode)
        {
            try
            {
                var hub = await _hubService.GetHubsByAirportCodeAsync(airportCode);
                return Ok(hub);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("city/{cityId:long}")]
        public async Task<ActionResult<HubMaster>> GetHubsByCityIdAsync(long cityId)
        {
            try
            {
                var hubs = await _hubService.GetHubsByCityIdAsync(cityId);
                return Ok(hubs);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // [HttpGet("city/{cityName}")]
        // public async Task<ActionResult<HubMaster>> GetHubsByCityNameAsync(string cityName)
        // {
        //     try
        //     {
        //         var hub = await _hubService.GetHubsByCityNameAsync(cityName);
        //         return Ok(hub);
        //     }
        //     catch (KeyNotFoundException ex)
        //     {
        //         return NotFound(new { Message = ex.Message });
        //     }
        // }
    }

}
