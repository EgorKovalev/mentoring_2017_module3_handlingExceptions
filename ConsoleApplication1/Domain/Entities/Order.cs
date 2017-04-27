﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain.Entities
{
    public class Order
    {
		public Order()
		{
			Status = Status.New;
            LastModification = DateTime.Now;
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
}
