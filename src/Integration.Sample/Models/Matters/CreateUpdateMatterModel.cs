using Integration.Sample.ApiServer.Matters.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.Models.Matters
{
	public class CreateUpdateMatterModel : IValidatableObject
	{
		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

		[Required]
		[Display(Name = "Costing Method")]
		public CostingMethod CostingMethod { get; set; }

		[Required]
		[Display(Name = "Open Date")]
		public DateTime? DateOpen { get; set; }

		[Display(Name = "Estimated Completion Date")]
		public DateTime? DateEstimatedCompletion { get; set; }

		[Display(Name = "Estimated Fee")]
		public decimal? EstimatedFee { get; set; }

		[Required]
		[Display(Name = "Practice Area")]
		public string PracticeAreaId { get; set; }

		[Required]
		[Display(Name = "Stage")]
		public int? StageId { get; set; }

		[Display(Name = "Cost Template")]
		public string CostTemplateId { get; set; }

		[Required]
		[Display(Name = "Client")]
		public string ClientId { get; set; }

		[Required]
		[Display(Name = "Lawyer")]
		public string LawyerId { get; set; }

		[Display(Name = "Referred By")]
		public string ReferredById { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (LawyerId == ClientId)
			{
				yield return new ValidationResult
				(
					"Lawyer cannot be the same as the Client",
					new[] { nameof(LawyerId) }
				);

				yield return new ValidationResult
				(
					"Client cannot be the same as the Lawyer",
					new[] { nameof(ClientId) }
				);
			}
		}
	}
}