namespace HotelHubAPI.ViewModels.Requests
{
    public class CreateReservationViewModel
    {
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int RequestedRoomCount { get; set; }
        public DateTime BookingDateStart { get; set; }
        public DateTime BookingDateEnd { get; set; }
    }
}
