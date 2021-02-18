using Integration.Sample.ApiServer.Common.Models.Base;

namespace Integration.Sample.ApiServer.Common.Services
{
	public interface IQueryService<TView, TListRequest, TListItem> :
		IViewService<TView>,
		IListService<TListRequest, TListItem>
		where TView : ViewItemBase
		where TListRequest : ListRequestBase
		where TListItem : ListItemBase
	{ }
}