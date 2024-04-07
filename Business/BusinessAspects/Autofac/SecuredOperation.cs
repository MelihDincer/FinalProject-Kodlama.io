using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    //JWT için.
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); //ServiceTool, bizim injection altyapımızı aynı okuyabilmemize yarayan araç.

        }

        protected override void OnBefore(IInvocation invocation)
        {
            //O anki kullanıcının rollerini bul.
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles) //rollerini gez
            {
                if (roleClaims.Contains(role)) //Claimlerinin içerisinde ilgili rol varsa
                {
                    return; //metodu çalıştırmaya devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //Yetkin yok hatası ver.
        }
    }
}
