using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain.Entities
{
    public class Order
    {
		public Order()
		{
			Status = Status.New;
		}
				
		public int Id { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public Status Status { get; set; }

		[Required]
		public DateTime LastModification { get; set; }

		[Required]
		public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Description: {1}, Status: {2}, Last modification: {3}, Price: {4}",
                Id, Description, Status, LastModification, Price);
        }
    }

	public enum Status
	{
		New,
		InProgress,
		Paid,
		Completed
	}

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
            return (j == 0) ? arr.Last() : arr[j-1];
        }
    }
}
