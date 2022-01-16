using Hotel.Core.Utilities.Results;
using Hotel.Entities.Concrete;

namespace Hotel.Business.Abstract
{
    public interface IRoomTypeService
    {
        IDataResult<IList<RoomType>> GetListByHotelRoomList(List<HotelRoom> hotelRoomList);
    }
}
