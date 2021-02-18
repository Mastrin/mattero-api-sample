using Integration.Sample.Models.Common;
using System;

namespace Integration.Sample.Extensions
{
	public static class SearchModelExtensions
	{
		public static SearchModel Clone(this ISearchModel model)
		{
			if (model is null)
				throw new ArgumentNullException(nameof(model));

			return new SearchModel
			{
				Page = model.Page,
				PageSize = model.PageSize,
				Search = model.Search
			};
		}
	}
}
