using CarparkBookingApi.Business.Interface.DTO.Request;
using CarparkBookingApi.Business.Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarparkBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityService availabilityService;

        public AvailabilityController(IAvailabilityService availabilityService)
        {
            this.availabilityService = availabilityService;
        }   

        [HttpPost]
        public async Task<IActionResult> GetAvailability(AvailabilityRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await this.availabilityService.GetAvailability(request));
        }
    }
}
