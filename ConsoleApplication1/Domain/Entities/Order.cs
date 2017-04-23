using System;
using System.ComponentModel.DataAnnotations;

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
    }

	/// <summary>
	/// TODO: add logic for switching status
	/// </summary>
	public enum Status
	{
		New,
		InProgress,
		Paid,
		Completed
	}
}
