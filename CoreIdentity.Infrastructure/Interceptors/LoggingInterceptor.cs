using Castle.DynamicProxy;
using CoreIdentity.Infrastructure.Logging;
using Newtonsoft.Json;

namespace CoreIdentity.Infrastructure.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var parametersJson = JsonConvert.SerializeObject(invocation.Arguments);
            System.Diagnostics.Debug.WriteLine("Request of " + invocation.Method.Name + " is " + parametersJson);
            NLogLogger.Instance.Log("Request of " + invocation.Method.Name + " is " + parametersJson);

            invocation.Proceed();

            var returnValueJson = JsonConvert.SerializeObject(invocation.ReturnValue);
            System.Diagnostics.Debug.WriteLine("Response of " + invocation.Method.Name + " is: " + returnValueJson);
            NLogLogger.Instance.Log("Response of " + invocation.Method.Name + " is: " + returnValueJson);
        }
    }
}
