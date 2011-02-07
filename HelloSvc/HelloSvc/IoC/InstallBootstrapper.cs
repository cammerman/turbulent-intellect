using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Configuration.Install;

using Autofac;

namespace HelloSvc
{
	using Install;

	internal class InstallBootstrapper
	{
		public IContainer Build()
		{
			var builder = new ContainerBuilder();

			builder
				.RegisterType<HelloServiceProcessInstaller>()
				.As<Installer>()
				.InstancePerLifetimeScope();

			builder
				.RegisterType<Services.GreetServiceInstaller>()
				.As<Installer>()
				.InstancePerLifetimeScope();

			builder
				.RegisterType<Config.ServiceNameProvider>()
				.As<Config.IServiceNameProvider>()
				.InstancePerLifetimeScope();

			return builder.Build();
		}
	}
}
