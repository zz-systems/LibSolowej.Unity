using System;
using System.Collections.Generic;
using System.Linq;

namespace LibSolowej
{
	public static class Utils
	{
		#region Constants
		internal const int OctavesMaximum = 30;
		#endregion

		public static IEnumerable<T> Flatten<T>(
			this IEnumerable<T> e,
			Func<T,IEnumerable<T>> f) 
		{
			return e.SelectMany(c => f(c).Flatten(f)).Concat(e);
		}
	}
}

