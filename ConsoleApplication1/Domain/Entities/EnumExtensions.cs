using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public static class EnumExtensions
	{
		public static T Next<T>(this T src) where T : struct
		{
			if (!typeof(T).IsEnum) throw new ArgumentException(string.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

			T[] arr = (T[])Enum.GetValues(src.GetType());
			int j = Array.IndexOf<T>(arr, src) + 1;
			return (arr.Length == j) ? arr[0] : arr[j];
		}

		public static T Prev<T>(this T src) where T : struct
		{
			if (!typeof(T).IsEnum) throw new ArgumentException(string.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

			T[] arr = (T[])Enum.GetValues(src.GetType());
			int j = Array.IndexOf<T>(arr, src);
			return (j == 0) ? arr.Last() : arr[j - 1];
		}
	}
}
