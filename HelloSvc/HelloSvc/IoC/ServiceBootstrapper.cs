using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Reflection;

using Autofac;

namespace HelloSvc
{
	internal class ServiceBootstrapper
	{
		public IContainer Build()
		{
			var builder = new ContainerBuilder();

			builder
				.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
				.InNamespace("HelloSvc.Greeting")
				.AsImplementedInterfaces();

			builder
				.RegisterAssemblyTypes(Assembly.GetCallingAssembly())
				.InNamespace("HelloSvc.Services")
				.Where(t => t.BaseType == typeof(ServiceBase))
				.As<ServiceBase>();

			return builder.Build();
		}
	}
}
