using Hotel.Core.Entities.Concrete;
using Hotel.Core.Utilities.Results;
using Hotel.Core.Utilities.Security.JWT;
using Hotel.Entities.Dtos;

namespace Hotel.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
