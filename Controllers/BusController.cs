using backend_practice.Dto;
using backend_practice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_practice.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpGet(Name = "GetBusesByColorId/{colorId}")]
        public async Task<IEnumerable<BusDto>> GetBusesByColorId(int colorId)
        {
            var result = await _busService.GetBusesByColor(colorId);
            return result;
        }
        [HttpDelete(Name = "DeleteBus /{busId}")]
        public async Task<IActionResult> DeleteBus(int busId)
        {
            await _busService.DeleteBus(busId);
            return Ok();
        }
    }
}
