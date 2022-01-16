using Hotel.Core.Entities;

namespace Hotel.Entities.Concrete
{
    public class RoomType : IEntity
    {
        public int Id { get; set; }
        public string RoomTypeName { get; set; }

        public virtual List<HotelRoom> HotelRoomList { get; set; }
    }
}
