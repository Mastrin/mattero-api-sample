using Integration.Sample.Models.Common;
using System;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Common.Services
{
	public interface IHttpService : IDisposable
	{
		Task<HttpOperationResult> GetAsync(string uri, object payload = null, string apiKey = null);
		Task<HttpOperationResult<TResponse>> GetAsync<TResponse>(string uri, object payload = null, string apiKey = null, Func<string, Task<TResponse>> deserializer = null);

		Task<HttpOperationResult> PostAsync(string uri, object payload, string apiKey = null);
		Task<HttpOperationResult<TResponse>> PostAsync<TResponse>(string uri, object payload, string apiKey = null, Func<string, Task<TResponse>> deserializer = null);

		Task<HttpOperationResult> PutAsync(string uri, object payloa, string apiKey = null);

		Task<HttpOperationResult> PatchAsync(string uri, object payloa, string apiKey = null);

		Task<HttpOperationResult> DeleteAsync(string uri, object payload = null, string apiKey = null);
	}
}