using System.Collections.Generic;

namespace Integration.Sample.ApiServer.Common.Models
{
	/// <summary>
	/// Represents the response of a list request
	/// </summary>
	/// <typeparam name="T">The type of results found</typeparam>
	public class ListResponse<T>
	{
		/// <summary>
		/// Total records found for the filters used
		/// </summary>
		public int TotalRecords { get; set; }

		/// <summary>
		/// The index of the page returned (this is zero based, the first page is page 0)
		/// </summary>
		public int PageIndex { get; set; }

		/// <summary>
		/// A list of records found within the page
		/// </summary>
		public IList<T> Records { get; set; }
	}
}