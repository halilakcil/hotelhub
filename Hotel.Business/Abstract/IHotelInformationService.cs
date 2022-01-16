using Hotel.Core.Utilities.Results;
using Hotel.Entities.Concrete;

namespace Hotel.Business.Abstract
{
    public interface IHotelInformationService
    {
        IDataResult<IList<HotelInformation>> GetListByHotelRoomList(List<HotelRoom> hotelRoomList);
    }
}
