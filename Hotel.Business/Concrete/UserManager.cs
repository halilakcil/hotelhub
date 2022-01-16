using Hotel.Business.Abstract;
using Hotel.Core.Aspects.Autofac.Exception;
using Hotel.Core.Aspects.Autofac.Logging;
using Hotel.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Hotel.Core.Entities.Concrete;
using Hotel.DataAccess.Abstract;

namespace Hotel.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public User GetByMail(string email)
        {
            return _userDal.Get(p => p.Email == email);
        }
    }
}
