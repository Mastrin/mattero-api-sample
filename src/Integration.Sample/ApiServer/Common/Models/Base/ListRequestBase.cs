using Integration.Sample.ApiServer.Common.Types;
using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.ApiServer.Common.Models.Base
{
	/// <summary>
	/// Represent a request for a list of results
	/// </summary>
	public class ListRequestBase : RequestBase
	{
		/// <summary>
		/// A generic parameter used to filter for best matches, usually associated with a name of an entity
		/// </summary>
		public string Search { get; set; }

		/// <summary>
		/// The property used to sort the results
		/// </summary>
		public string SortBy { get; set; }

		/// <summary>
		/// The direction to sort the result by. Either Ascending or Descending
		/// </summary>
		public EnumSortDirection? SortDirection { get; set; }

		/// <summary>
		/// The page number request (this is zero based, the first page is page 0)
		/// </summary>
		public int? PageIndex { get; set; }

		/// <summary>
		/// The size of the page or the maximum number of results to return.
		/// This value must be between 1 and 250.
		/// </summary>
		[Range(1, 250)]
		public int? PageSize { get; set; }

		/// <summary>
		/// If set this property override the PageIndex property. This property picks the page number based on the identifier of the entity
		/// </summary>
		public string PageIndexForId { get; set; }
	}
}