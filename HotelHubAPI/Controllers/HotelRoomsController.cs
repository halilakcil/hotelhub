using Hotel.Business.Abstract;
using HotelHubAPI.ViewModels.Requests;
using HotelHubAPI.ViewModels.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoomService _hotelRoomService;

        public HotelRoomsController(IHotelRoomService hotelRoomService)
        {
            _hotelRoomService = hotelRoomService;
        }

        [Authorize()]
        [HttpGet("GetCheapestRoomPrices")]
        public IActionResult GetCheapestRoomPrices()
        {
            var result = _hotelRoomService.GetCheapestRoomPrices();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize()]
        [HttpPost("AdvancedRoomSearch")]
        public IActionResult AdvancedRoomSearch(AdvancedRoomSearchViewModel payload)
        {
            var result = _hotelRoomService.AdvancedRoomSearch(payload.RoomTypeIds, payload.SelectedHotelIds);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize()]
        [HttpPost("RoomAvailabilityCheck")]
        public IActionResult RoomAvailabilityCheck(RoomAvailabilityCheckViewModel payload)
        {
            var result = _hotelRoomService.RoomAvailabilityCheck(payload.RoomTypeIds, payload.RequestedRoomCount, payload.HotelIds);
            var model = new RoomAvailabilityCheckResponse { Available = result };
            return BadRequest(model);
        }

        [Authorize()]
        [HttpGet("ClearCache")]
        public IActionResult ClearCache()
        {
            var result = _hotelRoomService.ClearCache();
            return BadRequest(result);
        }


    }
}
