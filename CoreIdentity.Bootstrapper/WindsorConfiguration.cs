﻿using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using CoreIdentity.Infrastructure.Installers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoreIdentity.Bootstrapper
{
    public static class WindsorConfiguration
    {
        public static IServiceProvider Configure(IServiceCollection services)
        {
            var container = new WindsorContainer();

            container.Install(new UoWRepositoryInstaller());
            container.Install(new ServiceInstaller());
            container.Install(new ControllerInstaller());
            container.Install(new InterceptorInstaller());            

            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }
    }
}
