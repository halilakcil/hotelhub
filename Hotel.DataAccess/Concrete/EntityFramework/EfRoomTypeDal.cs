using Hotel.Core.EntityFramework;
using Hotel.DataAccess.Abstract;
using Hotel.DataAccess.Concrete.EntityFramework.Contexts;
using Hotel.Entities.Concrete;

namespace Hotel.DataAccess.Concrete.EntityFramework
{
    public class EfRoomTypeDal : EfEntityRepositoryBase<RoomType, HotelHubDbContext>, IRoomTypeDal
    {
    }
}
