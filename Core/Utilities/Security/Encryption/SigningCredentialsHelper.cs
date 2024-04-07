using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //Credential => kullanıcı giriş bilgilerini tuttuğumuz yapıya verilen ad.
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
