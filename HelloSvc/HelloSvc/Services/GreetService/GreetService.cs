using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace HelloSvc.Services
{
	using Config;

	internal class GreetService : ServiceBase
	{
		public GreetService(IServiceNameProvider serviceNameProvider)
		{
			serviceNameProvider.ThrowIfNull("serviceNameProvider");
			
			ServiceName =
				serviceNameProvider.ServiceName
					.ThrowIfNullOrEmpty("serviceNameProvider.ServiceName");

			CanStop = true;
			AutoLog = false;
		}

		protected override void OnStart(String[] args)
		{
		}

		protected override void OnStop()
		{
		}
	}
}
