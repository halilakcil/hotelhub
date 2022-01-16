using Hotel.Core.Entities.Concrete;

namespace Hotel.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
}
