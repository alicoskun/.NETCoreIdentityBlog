using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreIdentity.Infrastructure.Interceptors;

namespace CoreIdentity.Infrastructure.Installers
{
    public class InterceptorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<LoggingInterceptor>().LifeStyle.Transient);
        }
    }
}
