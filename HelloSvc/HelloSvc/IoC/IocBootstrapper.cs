using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Autofac;

namespace HelloSvc
{
	internal class IocBootstrapper
	{
		public IContainer Build()
		{
			var builder = new ContainerBuilder();

			builder
				.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
				.InNamespace("HelloSvc.Greeting")
				.AsImplementedInterfaces();

			return builder.Build();
		}
	}
}
