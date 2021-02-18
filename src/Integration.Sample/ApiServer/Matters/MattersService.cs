using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.Matters.Common;
using Integration.Sample.ApiServer.Matters.Item;
using Integration.Sample.ApiServer.Matters.List;
using Integration.Sample.ApiServer.Matters.Lookup;
using Integration.Sample.Constants;
using Integration.Sample.Models.Common;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Matters
{
	public class MattersService :
		QueryLookupServiceBase
		<
			MatterViewItem,
			MatterListRequest,
			MatterListItem,
			MatterLookupRequest,
			MatterLookupItem
		>,
		IMattersService
	{
		public MattersService(IHttpService httpService)
			: base(httpService, ApiServerConstants.Endpoints.Matters.Uri)
		{ }

		public Task<HttpOperationResult<MatterReference>> CreateMatterAsync(MatterCreateUpdateRequest dto)
			=> HttpService.PostAsync<MatterReference>(ApiServerConstants.Endpoints.Matters.Uri, dto);

		public Task<HttpOperationResult> UpdateMatterAsync(string id, MatterCreateUpdateRequest dto)
			=> HttpService.PatchAsync($"{ApiServerConstants.Endpoints.Matters.Uri}/{id}", dto);
	}
}