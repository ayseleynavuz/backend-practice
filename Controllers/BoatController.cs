using backend_practice.Dto;
using backend_practice.EntityFramework;
using backend_practice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_practice.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class BoatController : ControllerBase
    {
        private readonly IBoatService _boatService;

        public BoatController(IBoatService boatService)
        {
            _boatService = boatService;
        }

        [HttpGet(Name = "GetBoatsByColorId/{colorId}")]
        public async Task<IEnumerable<BoatDto>> GetBoatsByColorId(int colorId)
        {
            var result = await _boatService.GetBoatsByColor(colorId);
            return result;
        }

    }
}
