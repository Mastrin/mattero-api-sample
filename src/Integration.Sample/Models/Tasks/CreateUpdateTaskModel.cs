using Integration.Sample.ApiServer.Tasks.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.Models.Tasks
{
	public class CreateUpdateTaskModel : IValidatableObject
	{
		[Required]
		public string Description { get; set; }

		[Required]
		public TaskStatus Status { get; set; }

		[Required]
		[Display(Name = "Date Due")]
		public DateTime? DueDate { get; set; }

		[Display(Name = "Associated Contact")]
		public string AssociatedContactId { get; set; }

		[Display(Name = "Associated Matter")]
		public string AssociatedMatterId { get; set; }

		[Required]
		[Display(Name = "Assigned To")]
		public string AssignedToId { get; set; }

		[Required]
		[Display(Name = "Contact Type")]
		public bool? IsContact { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (string.IsNullOrWhiteSpace(AssociatedContactId) && string.IsNullOrWhiteSpace(AssociatedMatterId))
			{
				yield return new ValidationResult
				(
					"Associated Contact cannot have a value when Associated Matter also has a value",
					new[] { nameof(AssociatedContactId) }
				);

				yield return new ValidationResult
				(
					"Associated Matter cannot have a value when Associated Contact also has a value",
					new[] { nameof(AssociatedMatterId) }
				);
			}
			else if (!string.IsNullOrWhiteSpace(AssociatedContactId) && !string.IsNullOrWhiteSpace(AssociatedMatterId))
			{
				yield return new ValidationResult
				(
					"Associated Contact cannot have no value when Associated Matter also has no value",
					new[] { nameof(AssociatedContactId) }
				);

				yield return new ValidationResult
				(
					"Associated Matter cannot have no value when Associated Contact also has no value",
					new[] { nameof(AssociatedMatterId) }
				);
			}
		}
	}
}