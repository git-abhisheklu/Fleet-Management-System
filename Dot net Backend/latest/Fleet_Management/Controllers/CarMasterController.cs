using Fleet_Management.Models;
using Fleet_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management.Controllers
{
    [Route("/cars")]
    [ApiController]
    public class CarMasterController : ControllerBase
    {
        private readonly ICarMasterService _carService;

        public CarMasterController(ICarMasterService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public async Task<ActionResult<CarMaster>> SaveCar(CarMaster car)
        {
            var savedCar = await _carService.SaveCarAsync(car);
            return CreatedAtAction(nameof(GetCarById), new { id = savedCar.CarId }, savedCar);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<CarMaster>> GetCarById(long id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                return NotFound($"No car found with ID: {id}");
            }

            return Ok(car);
        }

        [HttpGet]
        public async Task<ActionResult<List<CarMaster>>> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<CarMaster>> UpdateCar(long id, CarMaster carDetails)
        {
            var updatedCar = await _carService.UpdateCarAsync(id, carDetails);

            if (updatedCar == null)
            {
                return NotFound($"No car found with ID: {id}");
            }

            return Ok(updatedCar);
        }

        // [HttpDelete("{id:long}")]
        // public async Task<ActionResult> DeleteCar(long id)
        // {
        //     var deleted = await _carService.DeleteCarAsync(id);
        //     if (!deleted) return NotFound();
        //     return NoContent();
        // }

    }
}
