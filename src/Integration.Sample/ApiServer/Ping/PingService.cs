using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.Constants;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Ping
{
	public class PingService : IPingService
	{
		private readonly IHttpService _httpService;

		public PingService(IHttpService httpService)
			=> _httpService = httpService;

		public async Task<bool> PingAsync(string apiKey = null)
			=> (await _httpService.GetAsync(ApiServerConstants.Endpoints.Ping.Uri, apiKey: apiKey)).IsSuccessful;
	}
}