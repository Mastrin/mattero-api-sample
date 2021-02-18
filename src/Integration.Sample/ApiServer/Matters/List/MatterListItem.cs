using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Matters.Common;
using System;
using System.Collections.Generic;

namespace Integration.Sample.ApiServer.Matters.List
{
	/// <summary>
	/// Represents the details of a matter
	/// </summary>
	public class MatterListItem : ListItemBase
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
		/// The last date and time work was done against the matter
		/// </summary>
		public DateTime LastActivity { get; set; }

		/// <summary>
		/// The date and time the matter was opened or created
		/// </summary>
		public DateTime? DateOpen { get; set; }

		/// <summary>
		/// The status of the matter
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// The name of the practice area associated with the matter
		/// </summary>
		public string PracticeAreaName { get; set; }

		/// <summary>
		/// The name of the practice area stage associated with the matter
		/// </summary>
		public string StageName { get; set; }

		/// <summary>
		/// The client connected to the matter
		/// </summary>
		public EntityReference Client { get; set; }

		/// <summary>
		/// The associated Lawyer working on the matter
		/// </summary>
		public EntityReference Lawyer { get; set; }

		/// <summary>
		/// Custom fields associated with the matter
		/// </summary>
		public Dictionary<string, object> CustomFields { get; set; }

		/// <summary>
		/// The last date and time a matter was updated directly from a user
		/// </summary>
		public DateTime? UserChangeTimestamp { get; set; }

		/// <summary>
		/// The estimated fee for the matter
		/// </summary>
		public decimal? EstimatedFee { get; set; }

		/// <summary>
		/// The associated contact that referred the client
		/// </summary>
		public EntityReference ReferredBy { get; set; }

		/// <summary>
		/// The associated trust identifier
		/// </summary>
		public string TrustAccountId { get; set; }

		/// <summary>
		/// The roles for the contacts associated with the matter
		/// </summary>
		public IEnumerable<ContactWithRole> Roles { get; set; }

		/// <summary>
		/// The trust balance of the matter
		/// </summary>
		public decimal MatterTrustBalance { get; set; }

	}
}