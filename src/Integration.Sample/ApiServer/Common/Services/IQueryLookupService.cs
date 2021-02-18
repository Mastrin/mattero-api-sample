using Integration.Sample.ApiServer.Common.Models.Base;

namespace Integration.Sample.ApiServer.Common.Services
{
	public interface IQueryLookupService<TView, TListRequest, TListItem, TLookupRequest, TLookupItem> :
		ILookupService<TLookupRequest, TLookupItem>,
		IQueryService<TView, TListRequest, TListItem>
		where TView : ViewItemBase
		where TListRequest : ListRequestBase
		where TListItem : ListItemBase
		where TLookupRequest : LookupRequestBase
		where TLookupItem : LookupItemBase
	{ }
}