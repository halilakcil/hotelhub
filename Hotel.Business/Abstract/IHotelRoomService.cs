using Hotel.Core.Utilities.Results;
using Hotel.Entities.Concrete;

namespace Hotel.Business.Abstract
{
    public interface IHotelRoomService
    {
        IDataResult<IList<CustomHotelRoom>> GetCheapestRoomPrices();
        IDataResult<IList<CustomHotelRoom>> AdvancedRoomSearch(List<int> roomTypeIds, List<int>? selectedHotelIds);
        bool RoomAvailabilityCheck(List<int> roomTypeIds, int requestedRoomCount, List<int>? hotelIds);
        IDataResult<HotelRoom> GetHotelRoomByHotelAndRoomTypeId(int hotelId, int roomTypeId);
        IResult Update(HotelRoom hotelRoom);
        IResult ClearCache();
        IDataResult<HotelRoom> GetHotelRoomById(int hotelRoomId);


    }
}
