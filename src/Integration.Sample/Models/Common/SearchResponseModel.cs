using System.Collections.Generic;

namespace Integration.Sample.Models.Common
{
	public class SearchResponseModel<TModel> : SearchModel, ISearchResponseModel<TModel>
	{
		public int TotalRecords { get; set; }
		public IEnumerable<TModel> Items { get; set; }
	}
}