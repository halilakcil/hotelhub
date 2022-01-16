using Hotel.Core.DataAccess;
using Hotel.Entities.Concrete;

namespace Hotel.DataAccess.Abstract
{
    public interface IHotelRoomDal : IEntityRepository<HotelRoom>
    {
        IList<HotelRoom> GetCheapestRoomPrices();
        int RoomAvailabilityCount(List<int> roomTypeIds, List<int>? hotelIds);
        IList<HotelRoom> AdvancedRoomSearch(List<int> roomTypeIds, List<int>? selectedHotelIds);
    }
}
