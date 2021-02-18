using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.PracticeAreas.Item;
using Integration.Sample.ApiServer.PracticeAreas.Lookup;
using Integration.Sample.Constants;
using Integration.Sample.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.PracticeAreas
{
	public class PracticeAreasService : IPracticeAreasService
	{
		private readonly IHttpService _httpService;

		public PracticeAreasService(IHttpService httpService)
			=> _httpService = httpService;

		public virtual Task<HttpOperationResult<PracticeAreaViewItem>> GetItemAsync(string id)
			=> _httpService.GetAsync<PracticeAreaViewItem>($"{ApiServerConstants.Endpoints.PracticeAreas.Uri}/{id}");

		public Task<HttpOperationResult<List<PracticeAreaLookupItem>>> LookupListAsync(PracticeAreaLookupRequest request)
			=> _httpService.GetAsync<List<PracticeAreaLookupItem>>($"{ApiServerConstants.Endpoints.PracticeAreas.Uri}/lookup", request);
	}
}