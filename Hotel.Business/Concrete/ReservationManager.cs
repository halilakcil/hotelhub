using Hotel.Business.Abstract;
using Hotel.Business.Constants;
using Hotel.Core.Aspects.Autofac.Exception;
using Hotel.Core.Aspects.Autofac.Logging;
using Hotel.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Hotel.Core.Utilities.Results;
using Hotel.DataAccess.Abstract;
using Hotel.Entities.Concrete;

namespace Hotel.Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;
        private readonly IHotelRoomService _hotelRoomService;

        public ReservationManager(IReservationDal reservationDal, IHotelRoomService hotelRoomService)
        {
            _reservationDal = reservationDal;
            _hotelRoomService = hotelRoomService;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<CustomReservation> CreateReservation(int hotelId, int roomTypeId, int requestedRoomCount, DateTime bookingDateStart, DateTime bookingDateEnd)
        {

            if (bookingDateStart > bookingDateEnd)
            {
                return new ErrorDataResult<CustomReservation>(Messages.IsStartDateBiggerThanEndDate);
            }

            var difference = Convert.ToInt32((bookingDateStart - DateTime.Now).TotalDays);
            if (difference < 0)
            {
                return new ErrorDataResult<CustomReservation>(Messages.WhenCreateReservationByPastDate);
            }

            var hotelRoom = _hotelRoomService.GetHotelRoomByHotelAndRoomTypeId(hotelId, roomTypeId);
            var notSoldAllotment = (hotelRoom.Data.MaxAllotment - hotelRoom.Data.SoldAllotment);

            if (notSoldAllotment < requestedRoomCount)
            {
                return new ErrorDataResult<CustomReservation>(Messages.NotSoldAllotmentsRangeOfOut);
            }

            

            #region Rezervasyon süresi dolan odaların otomatik cancelled edilmesi gerekmektedir. Manuel olarak veya job ile bu işlem yapılabilir.
            //var hasToBeCancelReservationList = _reservationDal.GetList(p => p.IsDeleted == false && p.EndDate < DateTime.Now).ToList();
            //foreach (var reservation in hasToBeCancelReservationList)
            //{
            //    CancelReservation(reservation.Id);
            //} 
            #endregion

            hotelRoom.Data.SoldAllotment += requestedRoomCount;
            _hotelRoomService.Update(hotelRoom.Data);

            var reservationModel = new Reservation
            {
                HotelRoomId = hotelId,
                StartDate = bookingDateStart,
                EndDate = bookingDateEnd,
                IsDeleted = false,
                RoomCount = requestedRoomCount,
                CreatedAt = DateTime.Now
            };

            _reservationDal.Add(reservationModel);
            return new SuccessDataResult<CustomReservation>(Messages.ReservationAdded);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public IResult CancelReservation(int reservationId)
        {
            var reservation = _reservationDal.Get(p => p.Id == reservationId && p.IsDeleted == false);
            if (reservation == null)
            {
                return new ErrorResult(Messages.ReservationNotFound);
            }
            var hotelRoom = _hotelRoomService.GetHotelRoomById(reservation.HotelRoomId);

            hotelRoom.Data.SoldAllotment -= reservation.RoomCount;
            _hotelRoomService.Update(hotelRoom.Data);

            reservation.IsDeleted = true;
            _reservationDal.Update(reservation);
            return new SuccessResult(Messages.ReservationCancelled);
        }
    }
}
