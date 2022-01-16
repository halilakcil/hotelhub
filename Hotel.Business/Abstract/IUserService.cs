using Hotel.Core.Entities.Concrete;

namespace Hotel.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User GetByMail(string email);
    }
}
