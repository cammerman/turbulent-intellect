using System;

using Autofac;

namespace HowILearnedToLoveKeyedDependencies
{
	public class BootstrapIoC
	{
		public BootstrapIoC ()
		{
		}
		
		public IContainer Build()
		{
			var builder = new ContainerBuilder();
			
			builder
				.RegisterType<Cache>()
				.Keyed<ECacheType>(ECacheType.Thumb)
				.As<ICache>()
				.InstancePerLifetimeScope();
			
			builder
				.RegisterType<Cache>()
				.Keyed<ECacheType>(ECacheType.Image)
				.As<ICache>()
				.InstancePerLifetimeScope();
			
			builder
				.RegisterType<ImageBrowser>()
				.AsSelf()
				.InstancePerLifetimeScope();
				
			return builder.Build();
		}
	}
}

