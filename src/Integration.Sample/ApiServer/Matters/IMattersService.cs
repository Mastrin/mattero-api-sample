using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.Matters.Common;
using Integration.Sample.ApiServer.Matters.Item;
using Integration.Sample.ApiServer.Matters.List;
using Integration.Sample.ApiServer.Matters.Lookup;
using Integration.Sample.Models.Common;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Matters
{
	public interface IMattersService :
		IQueryLookupService
		<
			MatterViewItem,
			MatterListRequest,
			MatterListItem,
			MatterLookupRequest,
			MatterLookupItem
		>
	{
		Task<HttpOperationResult<MatterReference>> CreateMatterAsync(MatterCreateUpdateRequest dto);
		Task<HttpOperationResult> UpdateMatterAsync(string id, MatterCreateUpdateRequest dto);
	}
}