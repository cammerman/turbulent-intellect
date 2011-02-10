using System;

using Autofac;
using Autofac.Core;

namespace HowILearnedToLoveKeyedDependencies
{
	public class BootstrapIoC
	{
		public BootstrapIoC ()
		{
		}
		
		protected virtual void OnPreparingImageBrowser(PreparingEventArgs e)
		{
			e.Parameters = new[] {
				new NamedParameter(
					"thumbCache",
				    e.Context
						.ResolveKeyed<ICache>(ECacheType.Thumb)),
				new NamedParameter(
				    "imageCache",
				    e.Context
						.ResolveKeyed<ICache>(ECacheType.Image))
				};
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
				.OnPreparing(OnPreparingImageBrowser)
				.AsSelf()
				.InstancePerLifetimeScope();
				
			return builder.Build();
		}
	}
}

