using System.Security.Claims;

//Bir kişinin claimlerini ararken kolaylık sağlanması için sağlanmıştır.
//Bir kişinin Jwt'den gelen claimlerine erişmek için ClaimsPrincipal(.nette olan class) kullanıldı.
public static class ClaimsPrincipalExtensions
{
    public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList(); //?=>Null olabileceğini belirtir. Mesela claim oluşmamış, token istenmemiş o durumda null dönebilir.
        return result;
    }

    //Kişinin mevcut rollerini döndürdüğümüz metot. Yukarıda tüm bilgiler dönecektir.
    public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Role);
    }
}
