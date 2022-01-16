﻿using Castle.DynamicProxy;
using Hotel.Core.CrossCuttingConcerns.Logging;
using Hotel.Core.CrossCuttingConcerns.Logging.Log4Net;
using Hotel.Core.Utilities.Interceptors.Autofac;
using Hotel.Core.Utilities.Messages;

namespace Hotel.Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerServiceBase)
        {
            if (loggerServiceBase.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerServiceBase);
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            var logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (var i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter()
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Type = invocation.Arguments[i].GetType().Name,
                    Value = invocation.Arguments[i]
                });
            }

            var logDetailWithException = new LogDetailWithException()
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetailWithException;
        }
    }
}
