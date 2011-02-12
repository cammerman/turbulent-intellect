using System;

using Autofac.Features.Indexed;

namespace HowILearnedToLoveKeyedDependencies
{
	public class ImageBrowser
	{
		public virtual ICache ThumbCache
		{
			get;
			private set;
		}
		
		public virtual ICache ImageCache
		{
			get;
			private set;
		}
		
		public ImageBrowser(IIndex<ECacheType, ICache> caches)
		{
			ThumbCache = caches[ECacheType.Thumb];
			ImageCache = caches[ECacheType.Image];
		}
	}
}

