using Hotel.Core.Entities;

namespace Hotel.Entities.Concrete
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        public int HotelRoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
