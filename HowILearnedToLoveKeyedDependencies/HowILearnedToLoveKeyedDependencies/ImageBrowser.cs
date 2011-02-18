using System;
using System.Linq;
using System.Collections.Generic;

using Autofac.Features.Metadata;

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
		
		protected virtual Func<Meta<ICache>, Boolean> CacheTypeChecker(ECacheType cacheType)
		{
			return
				cache =>
					cache.Metadata["CacheType"]
						.Equals(cacheType);
		}
		
		public ImageBrowser(IEnumerable<Meta<ICache>> caches)
		{
			ThumbCache =
				caches
					.First(CacheTypeChecker(ECacheType.Thumb))
					.Value;
			
			ImageCache =
				caches
					.First(CacheTypeChecker(ECacheType.Image))
					.Value;
		}
	}
}

