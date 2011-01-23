using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autofac;

namespace HelloSvc
{
    public static class Program
    {
			public static void Main(String[] args)
			{
				var iocBootstrap = new IocBootstrapper();
				var container = iocBootstrap.Build();

				var greeter = container.Resolve<Greeting.IGreeter>();

				greeter.SayHello();
			}
    }
}
