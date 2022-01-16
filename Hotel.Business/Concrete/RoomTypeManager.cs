using Hotel.Business.Abstract;
using Hotel.Core.Aspects.Autofac.Exception;
using Hotel.Core.Aspects.Autofac.Logging;
using Hotel.Core.Utilities.Results;
using Hotel.DataAccess.Abstract;
using Hotel.Entities.Concrete;
using System.Data.Entity.Infrastructure.Interception;

namespace Hotel.Business.Concrete
{
    public class RoomTypeManager : IRoomTypeService
    {
        private readonly IRoomTypeDal _roomTypeDal;

        public RoomTypeManager(IRoomTypeDal roomTypeDal)
        {
            _roomTypeDal = roomTypeDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<RoomType>> GetListByHotelRoomList(List<HotelRoom> hotelRoomList)
        {
            var result = _roomTypeDal.GetList(p => hotelRoomList.Select(c => c.HotelInformationId).Contains(p.Id)).ToList();
            return new SuccessDataResult<List<RoomType>>(result);
        }
    }
}
