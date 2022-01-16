using Hotel.Core.Entities;

namespace Hotel.Entities.Concrete
{
    public class HotelRoom : IEntity
    {
        public int Id { get; set; }
        public int HotelInformationId { get; set; }
        public int RoomTypeId { get; set; }
        public decimal Price { get; set; }
        public int MaxAllotment { get; set; }
        public int SoldAllotment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }


        public virtual HotelInformation HotelInformation { get; set; }
        public virtual RoomType RoomType { get; set; }
        //public virtual List<Reservations> ReservationsList { get; set; }
    }
}
