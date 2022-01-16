using Hotel.Core.DataAccess;
using Hotel.Core.Entities.Concrete;

namespace Hotel.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
