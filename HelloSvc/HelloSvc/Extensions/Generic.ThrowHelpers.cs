using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloSvc
{
	internal static class Generic
	{
		public static T ThrowIfNull<T>(this T paramValue, String paramName)
			where T : class
		{
			if (paramValue == null)
				throw new ArgumentException(
					String.Format(
						"Value of {0} must not be null.",
						paramName),
					paramName);

			return paramValue;
		}
	}
}
