using Autofac;
using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces;
using Schedule.Database;
using System;
using System.Linq;

namespace Schedule.Business
{

    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var services = GetServices();
            builder.RegisterTypes(services)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterModule(new DatabaseModule());
        }

        private Type[] GetServices()
        {
            return ThisAssembly.GetTypes().Where(i => !i.IsAbstract && i.IsClass && i.IsAssignableTo<IService>()).ToArray();
        }
    }
}
