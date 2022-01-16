using AutoMapper;
using Hotel.Business.Abstract;
using Hotel.Business.Constants;
using Hotel.Core.Aspects.Autofac.Caching;
using Hotel.Core.Aspects.Autofac.Exception;
using Hotel.Core.Aspects.Autofac.Logging;
using Hotel.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Hotel.Core.Utilities.Results;
using Hotel.DataAccess.Abstract;
using Hotel.Entities.Concrete;

namespace Hotel.Business.Concrete
{
    public class HotelRoomManager : IHotelRoomService
    {
        private readonly IHotelRoomDal _hotelRoomDal;
        private readonly IMapper _mapper;

        public HotelRoomManager(IHotelRoomDal hotelRoomDal, IMapper mapper)
        {
            _hotelRoomDal = hotelRoomDal;
            _mapper = mapper;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<CustomHotelRoom>> AdvancedRoomSearch(List<int> roomTypeIds, List<int>? selectedHotelIds)
        {
            var hotelRoomList = _hotelRoomDal.AdvancedRoomSearch(roomTypeIds, selectedHotelIds).ToList();
            var result = _mapper.Map<List<CustomHotelRoom>>(hotelRoomList);
            return new SuccessDataResult<IList<CustomHotelRoom>>(result);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [CacheAspect()]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<CustomHotelRoom>> GetCheapestRoomPrices()
        {
            try
            {
                var hotelRoomList = _hotelRoomDal.GetCheapestRoomPrices();
                var result = _mapper.Map<List<CustomHotelRoom>>(hotelRoomList);
                return new SuccessDataResult<IList<CustomHotelRoom>>(result.OrderBy(p => p.Price).ThenBy(c => c.HotelName).ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CustomHotelRoom>>(new List<CustomHotelRoom>());
            }
        }


        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public bool RoomAvailabilityCheck(List<int> roomTypeIds, int requestedRoomCount, List<int>? hotelIds)
        {
            var resultCount = _hotelRoomDal.RoomAvailabilityCount(roomTypeIds, hotelIds);
            return resultCount >= requestedRoomCount;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<HotelRoom> GetHotelRoomByHotelAndRoomTypeId(int hotelId, int roomTypeId)
        {
            var result = _hotelRoomDal.Get(p => p.IsDeleted == false && p.HotelInformationId == hotelId && p.RoomTypeId == roomTypeId);
            return new SuccessDataResult<HotelRoom>(result);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        [CacheRemoveAspect("IHotelRoomService.GetCheapestRoomPrices")]
        public IResult Update(HotelRoom hotelRoom)
        {
            _hotelRoomDal.Update(hotelRoom);
            return new SuccessResult(Messages.HotelRoomUpdated);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<HotelRoom> GetHotelRoomById(int hotelRoomId)
        {
            var result = _hotelRoomDal.Get(p => p.IsDeleted == false && p.Id == hotelRoomId);
            return new SuccessDataResult<HotelRoom>(result);
        }

        [CacheRemoveAspect("IHotelRoomService.GetCheapestRoomPrices")]
        public IResult ClearCache()
        {
            return new SuccessResult(Messages.CacheClear);
        }
    }
}
