using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace HelloSvc.Services
{
	internal class GreetService : ServiceBase
	{
		protected Greeting.IGreeter Greeter
		{
			get;
			private set;
		}

		public GreetService(Greeting.IGreeter greeter)
		{
			Greeter = greeter.ThrowIfNull("greeter");

			ServiceName = "Greeter";
			CanStop = true;
			CanPauseAndContinue = true;
			AutoLog = false;
		}

		protected override void OnStart(String[] args)
		{
			Greeter.SayHello();
		}
	}
}
