using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using automapper_autofac.Common.AutoMap;
using automapper_autofac.Controllers;
using automapper_autofac.Services.Classes;
using automapper_autofac.Services.Interfaces;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;

namespace automapper_autofac.Common.IOC
{
    public class AutofacSetup
    {
        private static IContainer Container { get; set; }
        public static void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DbLog>()
                .As<IDbLogger>()
                .SingleInstance();

            builder.RegisterType<TextLog>()
                .As<ITextLogger>()
                .SingleInstance();

            builder.RegisterInstance(AutoMapperConfig.Mapper)
                .As<IMapper>()
                .SingleInstance();

            builder.RegisterControllers(typeof (TextController).Assembly);
            //builder.RegisterAssemblyTypes(typeof (TextController).Assembly);
            Container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}