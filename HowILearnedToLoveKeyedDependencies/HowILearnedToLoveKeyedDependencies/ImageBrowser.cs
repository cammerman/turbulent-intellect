using System;
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
		
		public ImageBrowser(ICache thumbCache, ICache imageCache)
		{
			ThumbCache = thumbCache;
			ImageCache = imageCache;
		}
	}
}

