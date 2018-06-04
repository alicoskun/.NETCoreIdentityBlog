using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreIdentity.Infrastructure.Interceptors;
using CoreIdentity.Services;

namespace CoreIdentity.Infrastructure.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IEmailSender>()
                 .ImplementedBy<EmailSender>()
                 .Interceptors<LoggingInterceptor>());
        }
    }
}
