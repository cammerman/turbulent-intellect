using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ServiceProcess;

namespace HelloSvc.Services
{
	internal class GreetServiceInstaller : ServiceInstaller
	{
		public GreetServiceInstaller()
			: base()
		{
			ServiceName = "Greeter";
			DisplayName = "Greeter";
			Description = "Windows Services Hello World";
			StartType = ServiceStartMode.Manual;
		}
	}
}
