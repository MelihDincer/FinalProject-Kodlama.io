using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //Burası verdiğimiz passwordun hashini oluşturmaya yarıyor.
        //Biz bir password vereceğiz. Dışarıya passwordHash ve passwordSalt değerlerini çıkarak yapıyı yazıyor olacağız bu metotta.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //Disposible pattern
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key; //Buradaki key, ilgili kullandığımız algoritmanın(HMACSHA512) o an oluşturduğu key değeridir ve dolayısıyla her kullanıcı için başka bir key oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //Burası ise sonradan sisteme girmek isteyen kişinin verdiği passwordun, bizim veri kaynağımızdaki hashle ilgili salta göre eşleşip eşleşmediğini verdiğimiz yer.
        //Password Hashini Doğrulama Metodu
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
