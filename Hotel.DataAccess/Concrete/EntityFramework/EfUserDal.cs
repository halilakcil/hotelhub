using Hotel.Core.Entities.Concrete;
using Hotel.Core.EntityFramework;
using Hotel.DataAccess.Abstract;
using Hotel.DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, HotelHubDbContext>, IUserDal
    {
    }
}
