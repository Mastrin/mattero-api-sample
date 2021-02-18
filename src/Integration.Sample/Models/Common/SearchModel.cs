using System;
using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.Models.Common
{
	public class SearchModel : ISearchModel
	{
		public string Search { get; set; }
		public int Page { get; set; } = 1;
		public int PageSize { get; set; } = 25;
	}
}