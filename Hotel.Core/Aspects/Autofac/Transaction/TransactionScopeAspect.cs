using Castle.DynamicProxy;
using Hotel.Core.Utilities.Interceptors.Autofac;
using System.Transactions;

namespace Hotel.Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using var transactionScope = new TransactionScope();
            try
            {
                invocation.Proceed();
                transactionScope.Complete();
            }
            catch (System.Exception e)
            {
                transactionScope.Dispose();
                throw;
            }
        }
    }
}
