using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Common.Services
{
	public class QueryLookupServiceBase<TView, TListRequest, TListItem, TLookupRequest, TLookupItem> :
		QueryServiceBase<TView, TListRequest, TListItem>,
		IQueryLookupService<TView, TListRequest, TListItem, TLookupRequest, TLookupItem>
		where TView : ViewItemBase
		where TListRequest : ListRequestBase
		where TListItem : ListItemBase
		where TLookupRequest : LookupRequestBase
		where TLookupItem : LookupItemBase
	{
		private readonly string _uri;

		public QueryLookupServiceBase(IHttpService httpService, string uri)
			: base(httpService, uri)
			=> _uri = uri;

		public virtual Task<HttpOperationResult<List<TLookupItem>>> LookupListAsync(TLookupRequest request)
			=> HttpService.GetAsync<List<TLookupItem>>($"{_uri}/lookup", request);
	}
}