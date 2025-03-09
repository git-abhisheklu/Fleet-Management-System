using Fleet_Management.Models;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet("state/{stateId:long}")]
        public async Task<ActionResult<List<CityDTO>>> GetCitiesByStateAsync(long stateId)
        {
            var cities = await _cityService.GetCitiesByStateAsync(stateId);
            if (cities == null || cities.Count == 0)
            {
                return NotFound();
            }
            return Ok(cities);
        }

        // [HttpGet("state/{stateName}")]
        // public async Task<ActionResult<List<CityMaster>>> GetCitiesByStateNameAsync(string stateName)
        // {
        //     return await _cityService.GetCitiesByStateNameAsync(stateName);
        // }

    }
}
