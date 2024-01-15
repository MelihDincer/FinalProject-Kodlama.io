
namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message) //base(success, message) diyerek, Result sınıfındaki ilgili constructor a ilgili parametreleri gönderdik. Burada aynı işlemi yapmak yerine base classına(Result) yaptırmış olduk.
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success) //base(success) diyerek, Result sınıfındaki ilgili constructor a ilgili parametreleri gönderdik. Burada aynı işlemi yapmak yerine base classına(Result) yaptırmış olduk.
        {
            Data = data;
        }
        public T Data { get; }
    }
}
