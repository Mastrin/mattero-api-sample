using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.CostTemplates.Lookup;
using Integration.Sample.Constants;
using Integration.Sample.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.CostTemplates
{
	public class CostTemplatesService : ICostTemplatesService
	{
		private readonly IHttpService _httpService;

		public CostTemplatesService(IHttpService httpService)
			=> _httpService = httpService;

		public Task<HttpOperationResult<List<CostTemplateLookupItem>>> LookupListAsync(CostTemplateLookupRequest request)
			=> _httpService.GetAsync<List<CostTemplateLookupItem>>($"{ApiServerConstants.Endpoints.CostTemplates.Uri}/lookup", request);
	}
}