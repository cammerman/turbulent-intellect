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
				.WithMetadata("CacheType", ECacheType.Thumb)
				.As<ICache>()
				.InstancePerLifetimeScope();
			
			builder
				.RegisterType<Cache>()
				.WithMetadata("CacheType", ECacheType.Image)
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

