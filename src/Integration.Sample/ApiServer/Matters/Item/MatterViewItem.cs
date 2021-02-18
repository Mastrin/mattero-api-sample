using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Contacts.Common;
using Integration.Sample.ApiServer.Matters.Common;
using System;
using System.Collections.Generic;

namespace Integration.Sample.ApiServer.Matters.Item
{
	/// <summary>
	/// A Detailed view of the matter
	/// </summary>
	public class MatterViewItem : ViewItemBase
	{
		/// <summary>
		/// The number associated with the matter
		/// </summary>
		public string Number { get; set; }

		/// <summary>
		/// The chosen title or name of the matter
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Matter summary
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The status of the matter
		/// </summary>
		public MatterStatus Status { get; set; }

		/// <summary>
		/// The date and time the matter was opened or created
		/// </summary>
		public DateTime? DateOpen { get; set; }

		/// <summary>
		/// The estimated date and time this matter will be completed
		/// </summary>
		public DateTime? DateEstimatedCompletion { get; set; }

		/// <summary>
		/// The last date and time work was done against the matter
		/// </summary>
		public DateTime LastActivity { get; set; }

		/// <summary>
		/// The estimated fee for the matter
		/// </summary>
		public decimal? EstimatedFee { get; set; }

		/// <summary>
		/// Fee amount for work have been done (aka WIP Fee)
		/// </summary>
		public decimal ProvidedServicesFee { get; set; }

		/// <summary>
		/// The amount of work has been billed to the matter
		/// </summary>
		public decimal BilledAmount { get; set; }

		/// <summary>
		/// Current Trust Balance on the matter
		/// </summary>
		public decimal MatterTrustBalance { get; set; }

		/// <summary>
		/// The method used to calucate costs associated with the matter
		/// </summary>
		public CostingMethod? CostingMethod { get; set; }

		/// <summary>
		/// The template used to calucate costs associated with the matter
		/// </summary>
		public string CostTemplate { get; set; }

		/// <summary>
		/// The name of the practice area associated with the matter
		/// </summary>
		public string PracticeArea { get; set; }

		/// <summary>
		/// The identifier of the practice area associated with the matter
		/// </summary>
		public string PracticeAreaId { get; set; }

		/// <summary>
		/// The name of the practice area stage associated with the matter
		/// </summary>
		public string PracticeAreaStage { get; set; }

		/// <summary>
		/// The identifier of the practice area stage associated with the matter
		/// </summary>
		public int? PracticeAreaStageId { get; set; }

		/// <summary>
		/// The associated trust
		/// </summary>
		public string TrustAccount { get; set; }

		/// <summary>
		/// Client (company or person)
		/// </summary>
		public ContactReference Client { get; set; }

		/// <summary>
		/// Lawyer (user)
		/// </summary>
		public EntityReference Lawyer { get; set; }

		/// <summary>
		/// A contact who referred the client
		/// </summary>
		public EntityReference ReferredBy { get; set; }

		/// <summary>
		/// The roles for the contacts associated with the matter
		/// </summary>
		public IEnumerable<ContactWithRole> ContactFields { get; set; }

		/// <summary>
		/// Custom fields associated with the matter
		/// </summary>
		public Dictionary<string, object> CustomFields { get; set; } = new Dictionary<string, object>();
	}
}
