using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace Worlds.Travel.Web.Infrastructures
{
    public static class AutofacConfig
    {
        public static void Initialize()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Assembly[] assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().Where(assembly => assembly.FullName.StartsWith("Worlds") || assembly.FullName.StartsWith("IndividualWorlds")).ToArray();
            builder.RegisterAssemblyModules(assemblies);
            builder.RegisterControllers(assemblies);
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}