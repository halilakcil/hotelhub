using Hotel.Core.DataAccess;
using Hotel.Entities.Concrete;

namespace Hotel.DataAccess.Abstract
{
    public interface IHotelInformationDal : IEntityRepository<HotelInformation>
    {
    }
}
