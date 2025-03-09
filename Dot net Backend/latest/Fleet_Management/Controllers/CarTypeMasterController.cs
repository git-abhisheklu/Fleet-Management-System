using Fleet_Management.Models.DTO;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management.Controllers
{
    [Route("api/cartype")]
    [ApiController]
    public class CarTypeMasterController : ControllerBase
    {
        private readonly ICarTypeMasterService _carTypeMasterService;

        public CarTypeMasterController(ICarTypeMasterService carTypeMasterService)
        {
            _carTypeMasterService = carTypeMasterService;
        }

        [HttpGet("{carTypeId}")]
        public async Task<ActionResult<CarTypeMasterDTO>> GetTypeByTypeId(long carTypeId)
        {
            var carType = await _carTypeMasterService.GetTypeByTypeIdAsync(carTypeId);

            if (carType == null)
            {
                return NotFound("No matching CarTypeId found!");
            }

            return Ok(carType);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CarTypeMasterDTO>>> GetAllTypes()
        {
            var carTypes = await _carTypeMasterService.GetAllTypesAsync();
            return Ok(carTypes);
        }
    }
}
