using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.CostRecords.Common.Types;
using Integration.Sample.ApiServer.Matters.Common;
using System;
using System.Collections.Generic;

namespace Integration.Sample.ApiServer.Matters.List
{
	/// <summary>
	/// Represent a request for a list of contacts
	/// </summary>
	public class MatterListRequest : ListRequestBase
	{
		/// <summary>
		/// The id of the lawyer associated with the matter
		/// </summary>
		public string LawyerId { get; set; }

		/// <summary>
		/// The id of the client associated with the matter
		/// </summary>
		public string ClientId { get; set; }

		/// <summary>
		/// The id of the referrer associated with the matter
		/// </summary>
		public string ReferredById { get; set; }

		/// <summary>
		/// The practice area id's to filter matters by
		/// </summary>
		public string[] PracticeAreaIds { get; set; }

		/// <summary>
		/// The status associated with the matter
		/// </summary>
		public MatterStatus? Status { get; set; }

		/// <summary>
		/// The cost type  associated with the matter
		/// </summary>
		public CostType? CostType { get; set; }

		/// <summary>
		/// The start of the range that matters were open/created in
		/// </summary>
		public DateTime? OpenDateStart { get; set; }

		/// <summary>
		/// The end of the range that matters were open/created in
		/// </summary>
		public DateTime? OpenDateEnd { get; set; }

		/// <summary>
		/// The start of the range that matters were modified in
		/// </summary>
		public DateTime? ModifiedDateStart { get; set; }

		/// <summary>
		/// The end of the range that matters were modified in
		/// </summary>
		public DateTime? ModifiedDateEnd { get; set; }

		/// <summary>
		/// Custom fields associated with the matter
		/// </summary>
		public Dictionary<string, string> CustomFields { get; set; }

		/// <summary>
		/// Contact Id related to the filtered matters
		/// </summary>
		public string RelatedMattersFilterUser { get; set; }

		/// <summary>
		/// The method used to calucate costs associated with the matter
		/// </summary>
		public CostingMethod? CostingMethod { get; set; }

		/// <summary>
		/// The trust id's to filter matters by
		/// </summary>
		public string[] TrustAccountIds { get; set; }

		/// <summary>
		/// Is a statutory matter
		/// </summary>
		public bool? IsStatutory { get; set; }
	}
}