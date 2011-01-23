using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Reflection;

using Autofac;

using HelloSvc.Install;

namespace HelloSvc
{
	internal class InstallerBootstrapper
	{
		public IContainer Build()
		{
			var builder = new ContainerBuilder();

			builder
				.RegisterType<HelloServiceProcessInstaller>()
				.As<ServiceProcessInstaller>();

			builder
				.RegisterAssemblyTypes(Assembly.GetCallingAssembly())
				.InNamespace("HelloSvc.Services")
				.Where(t => t.BaseType == typeof(ServiceInstaller))
				.As<ServiceInstaller>();

			return builder.Build();
		}
	}
}
