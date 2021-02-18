using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.Models.Common;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Common.Services
{
	public interface IListService<TListRequest, TListItem>
		where TListRequest : ListRequestBase
		where TListItem : ListItemBase
	{
		public Task<HttpOperationResult<ListResponse<TListItem>>> GetListAsync(TListRequest request);
	}
}