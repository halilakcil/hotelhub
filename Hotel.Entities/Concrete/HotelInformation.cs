using Hotel.Core.Entities;

namespace Hotel.Entities.Concrete
{
    public class HotelInformation : IEntity
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<HotelRoom> HotelRoomList { get; set; }
    }
}
