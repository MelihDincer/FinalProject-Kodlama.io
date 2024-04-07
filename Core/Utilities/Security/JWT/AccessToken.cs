namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //JWT değerimizin kendisi.
        public DateTime Expiration { get; set; } //Token bitiş zamanı
    }
}
