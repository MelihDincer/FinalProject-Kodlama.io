﻿using Castle.DynamicProxy;

namespace Core.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //Priority => öncelik
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
