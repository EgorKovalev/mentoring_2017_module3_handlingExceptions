using System;
using System.ComponentModel.DataAnnotations;

namespace Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class RequiredAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			return value == null ? new ValidationResult("Value is required.") : ValidationResult.Success;
		}
	}
}
