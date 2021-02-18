using System.Collections.Generic;

namespace Integration.Sample.Models.Common
{
	public interface ISearchResponseModel<out TModel> : ISearchResponseModel
	{
		IEnumerable<TModel> Items { get; }
	}

	public interface ISearchResponseModel : ISearchModel
	{
		int TotalRecords { get; }
	}
}