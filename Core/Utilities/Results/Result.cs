
namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this demek Result sınıfı demek.
        public Result(bool success, string message):this(success) //this(success) diyerek, Result sınıfında tek parametreli constructorun çalıştırılmasını sağladık. Yani iki parametreli Result managerda çağrıldığında, bu constructor'da sadece Message set edilecek. Success yine aşağıda set edilecektir.
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
