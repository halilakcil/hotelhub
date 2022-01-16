using Hotel.Business.Abstract;
using HotelHubAPI.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HotelHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [Authorize()]
        [HttpPost("CreateReservation")]
        public IActionResult CreateReservation(CreateReservationViewModel payload)
        {
            var result = _reservationService.CreateReservation(payload.HotelId, payload.RoomTypeId, payload.RequestedRoomCount, payload.BookingDateStart, payload.BookingDateEnd);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [Authorize()]
        [HttpPost("CancelReservation")]
        public IActionResult CancelReservation(CancelReservationViewModel payload)
        {
            var result = _reservationService.CancelReservation(payload.ReservationId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
