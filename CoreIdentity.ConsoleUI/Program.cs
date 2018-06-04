using Castle.Windsor;
using CoreIdentity.Infrastructure.Installers;
using CoreIdentity.Infrastructure.Logging;
using CoreIdentity.Services;
using System;

namespace CoreIdentity.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            WindsorContainer container = new WindsorContainer();
            /*container.Register(
                Component.For<IEmailSender>().ImplementedBy<EmailSender>().Interceptors<LoggingInterceptor>(),
                Component.For<LoggingInterceptor>().LifeStyle.Transient);*/

            container.Install(new ServiceInstaller());
            container.Install(new InterceptorInstaller());
            

            IEmailSender sender = container.Resolve<IEmailSender>();

            sender.SendEmailAsync("", "", "qweqwe");

            NLogLogger.Instance.Log("console ui");
        }
    }
}
