using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Contacts.Common;
using Integration.Sample.ApiServer.Matters.Common;

namespace Integration.Sample.ApiServer.Matters.Lookup
{
	/// <summary>
	/// Represents the details of a matter
	/// </summary>
	public class MatterLookupItem : LookupItemBase
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
		/// The current status of the matter
		/// </summary>
		public MatterStatus Status { get; set; }

		/// <summary>
		/// The method used to calucate costs associated with the matter
		/// </summary>
		public CostingMethod? CostingMethod { get; set; }

		/// <summary>
		/// The template used to calucate costs associated with the matter
		/// </summary>
		public string CostTemplate { get; set; }

		/// <summary>
		/// The associated Lawyer working on the matter
		/// </summary>
		public EntityReference Lawyer { get; set; }

		/// <summary>
		/// The client connected to the matter
		/// </summary>
		public ContactReference Client { get; set; }

		/// <summary>
		/// The trust balance of the matter
		/// </summary>
		public decimal MatterTrustBalance { get; set; }

		/// <summary>
		/// The associated trust identifier
		/// </summary>
		public string TrustAccountId { get; set; }

		/// <summary>
		/// The name of the practice area associated with the matter
		/// </summary>
		public string PracticeArea { get; set; }

		/// <summary>
		/// The name of the practice area stage associated with the matter
		/// </summary>
		public string PracticeAreaStage { get; set; }
	}
}