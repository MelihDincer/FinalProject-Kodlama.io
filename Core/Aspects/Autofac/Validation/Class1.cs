using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Interceptors;
using FluentValidation;


namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //attribute larda Type geçmek zorundayız
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //gönderilen validatorType bir IValidator değilse
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil!");
            }
            _validatorType = validatorType;
        }

        //Core->Interceptors içerisindeki MethodInterception abstract classında virtual ile boş tanımlanan metodu aşağıda override ettik.
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
