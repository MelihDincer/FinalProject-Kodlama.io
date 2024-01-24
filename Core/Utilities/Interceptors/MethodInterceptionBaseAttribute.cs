using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
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
