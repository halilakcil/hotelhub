using Hotel.Business.Abstract;
using Hotel.Core.Aspects.Autofac.Exception;
using Hotel.Core.Aspects.Autofac.Logging;
using Hotel.Core.Utilities.Results;
using Hotel.DataAccess.Abstract;
using Hotel.Entities.Concrete;
using System.Data.Entity.Infrastructure.Interception;

namespace Hotel.Business.Concrete
{
    public class HotelInformationManager : IHotelInformationService
    {
        private readonly IHotelInformationDal _hotelInformationDal;

        public HotelInformationManager(IHotelInformationDal hotelInformationDal)
        {
            _hotelInformationDal = hotelInformationDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<HotelInformation>> GetListByHotelRoomList(List<HotelRoom> hotelRoomList)
        {
            var result = _hotelInformationDal.GetList(p => p.IsDeleted == false && hotelRoomList.Select(c => c.HotelInformationId).Contains(p.Id)).ToList();
            return new SuccessDataResult<List<HotelInformation>>(result);
        }
    }
}
