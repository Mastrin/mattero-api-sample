using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.Models.Common;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Common.Services
{
	public class QueryServiceBase<TView, TListRequest, TListItem> :
		IQueryService<TView, TListRequest, TListItem>
		where TView : ViewItemBase
		where TListRequest : ListRequestBase
		where TListItem : ListItemBase
	{
		protected IHttpService HttpService { get; }
		private readonly string _uri;

		public QueryServiceBase(IHttpService httpService, string uri)
		{
			HttpService = httpService;
			_uri = uri;
		}

		public virtual Task<HttpOperationResult<TView>> GetItemAsync(string id)
			=> HttpService.GetAsync<TView>($"{_uri}/{id}");

		public virtual Task<HttpOperationResult<ListResponse<TListItem>>> GetListAsync(TListRequest request)
			=> HttpService.GetAsync<ListResponse<TListItem>>(_uri, request);
	}
}
