using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //CreateToken metodu, ilgili kullanıcı için, ilgili kullanıcının claimlerini(rollerini) içerecek bir token üretecektir.
        AccessToken CreateToken(User user, List<OperationClaim> claims);
    }
}
