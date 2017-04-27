using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Domain.Models;

namespace Domain.Entities
{
    public class Order
    {
		public Order(OrderModel model)
		{
			Id = model.Id;
			Description = model.Description;
			Status = model.Status;
            LastModification = model.LastModification;
			Price = model.Price;
		}
				
		public int Id { get; set; }

		public string Description { get; set; }
				
		public Status Status { get; set; }
				
		public DateTime LastModification { get; set; }

		public double Price { get; set; }
    } 
}
