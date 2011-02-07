using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloSvc
{
	internal static class StringExtensions
	{
		public static String ThrowIfNullOrEmpty(this String src, String argName)
		{
			if (src == null || src.Length == 0)
				throw new ArgumentException(
					String.Format("String argument cannot be null or empty."),
					argName);

			return src;
		}
	}
}
