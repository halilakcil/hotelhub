namespace HotelHubAPI.ViewModels.Requests
{
    public class RoomAvailabilityCheckViewModel
    {
        public List<int>? HotelIds { get; set; }
        public List<int> RoomTypeIds { get; set; }
        public int RequestedRoomCount { get; set; }
    }
}
