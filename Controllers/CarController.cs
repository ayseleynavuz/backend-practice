using backend_practice.Dto;
using backend_practice.Entities;
using backend_practice.EntityFramework;
using backend_practice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace backend_practice.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet(Name = "GetCarsByColorId/{colorId}")]
        public async Task<IEnumerable<CarDto>> GetCarsByColorId(int colorId)
        {
            var result = await _carService.GetCarsByColor(colorId);
            return result;
        }

        [HttpDelete(Name = "DeleteCar /{carId}")]
        public async Task<IActionResult> DeleteCar(int carId)
        {
            await _carService.DeleteCar(carId);
            return Ok();
        }
        
        [HttpPost(Name = "activeOrPassiveHeadlight /{carId}")]
        public async Task<IActionResult> activeOrPassiveHeadlight(int carId)
        {
            await _carService.UpdateCarHeadlight(carId);
            return Ok();
        }

    }
}

