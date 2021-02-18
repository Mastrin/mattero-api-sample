using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Matters.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.ApiServer.Matters.Item
{
	/// <summary>
	/// Used to create or update a matter
	/// </summary>
	public class MatterCreateUpdateRequest : CreateUpdateRequestBase
	{
		/// <summary>
		/// The chosen title or name of the matter
		/// </summary>
		[Required]
		public string Title { get; set; }

		/// <summary>
		/// Matter summary
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The method used to calucate costs associated with the matter
		/// </summary>
		[Required]
		public CostingMethod CostingMethod { get; set; }

		/// <summary>
		/// The last date and time work was done against the matter
		/// </summary>
		public DateTime DateOpen { get; set; }

		/// <summary>
		/// The estimated date and time this matter will be completed
		/// </summary>
		public DateTime? DateEstimatedCompletion { get; set; }

		/// <summary>
		/// Estimated fee on the matter
		/// </summary>
		public decimal? EstimatedFee { get; set; }

		/// <summary>
		/// The identifier of the practice area associated with the matter
		/// </summary>
		[Required]
		public string PracticeAreaId { get; set; }

		/// <summary>
		/// The identifier of the practice area stage associated with the matter
		/// </summary>
		[Required]
		public int StageId { get; set; }

		/// <summary>
		/// The identifier for the template used to calucate costs associated with the matter
		/// </summary>
		public string CostTemplateId { get; set; }

		/// <summary>
		/// Client (company or person)
		/// </summary>
		[Required]
		public string ClientId { get; set; }

		/// <summary>
		/// Lawyer (user)
		/// </summary>
		[Required]
		public string LawyerId { get; set; }

		/// <summary>
		/// A contact who referred the client
		/// </summary>
		public string ReferredById { get; set; }

		/// <summary>
		/// Custom fields associated with the matter
		/// </summary>
		public Dictionary<string, object> CustomFields { get; set; }
	}
}
