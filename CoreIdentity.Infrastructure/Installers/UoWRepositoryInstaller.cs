using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreIdentity.Core.Data;
using CoreIdentity.Core.Data.Imp;
using CoreIdentity.Data;

namespace CoreIdentity.Infrastructure.Installers
{
    public class UoWRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IUnitOfWork))
                .ImplementedBy(typeof(UnitOfWork)));
            container.Register(
                Component.For(typeof(IEntitiesContext))
                .ImplementedBy(typeof(BloggingContext)));
        }
    }
}
