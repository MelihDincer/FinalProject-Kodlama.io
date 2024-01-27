using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    //Classlara veya metotlara ekleyebilirsin, birden fazla ekleyebilirsin ve inherite edilen bir noktada da bu metot çalışabilsin.
    //Neden birden fazla kullanabilirim? Loglama işleminde hem bir veritabanına loglasın, hem de bir dosyaya loglasın diyebiliriz.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //Priority => öncelik
        public int Priority { get; set; } //Hangi attribute önce çalışsın. Önce validation sonra loglama gibi..

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
