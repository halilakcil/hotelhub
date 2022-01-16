using Hotel.Core.DataAccess;
using Hotel.Entities.Concrete;

namespace Hotel.DataAccess.Abstract
{
    public interface IReservationDal : IEntityRepository<Reservation>
    {
    }
}
