namespace Hotel.Entities.Concrete
{
    public class CustomHotelRoom
    {
        public int HotelInformationId { get; set; }
        public string HotelName { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public decimal Price { get; set; }
    }
}
