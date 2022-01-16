using Castle.DynamicProxy;
using FluentValidation;
using Hotel.Core.CrossCuttingConcern.Validations.FluentValidation;
using Hotel.Core.Utilities.Interceptors.Autofac;
using Hotel.Core.Utilities.Messages;

namespace Hotel.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validationType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validationType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validationType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(p => p.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
