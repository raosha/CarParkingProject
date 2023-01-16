using CarparkBookingApi.Business.Interface.DTO.Request;
using CarparkBookingApi.Business.Interface.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarparkBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> CancelReservation(int bookingId) 
        {
            if (bookingId == 0)
                return BadRequest("Please provide booking ID");

            return Ok(await this.reservationService.CancelBooking(bookingId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingRequest bookingRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await this.reservationService.CreateBooking(bookingRequest));
        }
    }
}
