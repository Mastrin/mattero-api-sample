namespace Integration.Sample.Models.Common
{
	public interface ISearchModel
	{
		string Search { get; }
		int Page { get; }
		int PageSize { get; }
	}
}