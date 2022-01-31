using Autofac;
using Microsoft.EntityFrameworkCore;
using Schedule.Core.Entities.Base;
using Schedule.database;
using Schedule.Database.Repository.Implementations;
using Schedule.Database.Repository.Implementations.Base;
using System;
using System.Linq;

namespace Schedule.Database
{
    public class DatabaseModule : Module
    {
        public DatabaseModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SqlDatabase>()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.
                RegisterType<UnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterTypes(GetRepositories())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

        private Type[] GetRepositories()
        {
            var entities = typeof(ISqlEntity).Assembly.GetTypes().Where(i => i.IsClass && !i.IsAbstract && i.IsAssignableTo<ISqlEntity>());
            return entities.Select(i => typeof(SqlRepository<>).MakeGenericType(i)).ToArray();
        }
    }
}
