using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Matters.Common;
using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.ApiServer.Matters.Lookup
{
	/// <summary>
	/// Represent a request for looking up matters
	/// </summary>
	public class MatterLookupRequest : LookupRequestBase
	{
		/// <summary>
		/// A term associated with the matter. This checks multiple properties including the title and number properties.
		/// </summary>
		[Required]
		public string Term { get; set; }

		/// <summary>
		/// The status of the matter being searched
		/// </summary>
		public MatterStatus? Status { get; set; }
	}
}