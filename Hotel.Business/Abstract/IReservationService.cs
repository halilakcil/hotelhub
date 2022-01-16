using Hotel.Core.Utilities.Results;
using Hotel.Entities.Concrete;

namespace Hotel.Business.Abstract
{
    public interface IReservationService
    {
        IDataResult<CustomReservation> CreateReservation(int hotelId, int roomTypeId, int requestedRoomCount, DateTime bookingDateStart, DateTime bookingDateEnd);
        IResult CancelReservation(int reservationId);
    }
}
