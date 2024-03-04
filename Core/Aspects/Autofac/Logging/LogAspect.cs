using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;

namespace Core.Aspects.Autofac.Logging;

public class LogAspect : MethodInterception
{
    private LoggerServiceBase _loggerServiceBase;
    private IHttpContextAccessor _contextAccessor;

    public LogAspect(Type loggerServiceBase)
    {
        if (loggerServiceBase.BaseType != typeof(LoggerServiceBase))
        {
            throw new Exception(AspectMessages.WrongLoggerType);
        }

        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerServiceBase);
        _contextAccessor = (IHttpContextAccessor)Activator.CreateInstance(typeof(HttpContextAccessor));
        //_contextAccessor = httpContextAccessor;
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var logDetail = GetLogDetail(invocation);
        foreach (var parameter in logDetail.LogParameters)
        {
            _loggerServiceBase.Info($"MethodName: {logDetail.MethodName}, User: {logDetail.User},Parameter Name: {parameter.Name}, Value: {parameter.Value}, Type: {parameter.Type}");
        }
    }

    private LogDetail GetLogDetail(IInvocation invocation)
    {
        var logParameters = new List<LogParameter>();
        for (int i = 0; i < invocation.Arguments.Length; i++)
        {
            logParameters.Add(new LogParameter()
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i].GetType().Name
            });
        }

        var logDetail = new LogDetail()
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters,
            User = _contextAccessor.HttpContext == null || _contextAccessor.HttpContext.User.Identity.Name == null ? "?" : _contextAccessor.HttpContext.User.Identity.Name
        };
        return logDetail;
    }
}
