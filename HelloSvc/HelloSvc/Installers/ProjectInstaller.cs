using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;

using Autofac;

namespace HelloSvc.Install
{
	[RunInstaller(true)]
	public class ProjectInstaller : Installer
	{
		public ProjectInstaller()
		{
			var bootstrapper = new InstallerBootstrapper();
			var container = bootstrapper.Build();

			var processInstaller = container.Resolve<ServiceProcessInstaller>();
			var serviceInstallers = container.Resolve<IEnumerable<ServiceInstaller>>().ToList();

			Console.WriteLine("Found {0} services", serviceInstallers.Count);

			this.Installers.AddRange(
				new Installer[] { processInstaller }
					.Concat(serviceInstallers)
					.ToArray()
				);
		}
	}
}