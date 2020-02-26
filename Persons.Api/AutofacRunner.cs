using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using MediatR;

namespace Persons.Api
{
    public static class AutofacRunner
    {

        public static IMediator BuildMediator()
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            var container = builder.Build();
            var mediator = container.Resolve<IMediator>();

            return mediator;
        }
    }
}