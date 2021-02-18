using Integration.Sample.Common;
using Integration.Sample.Constants;
using Integration.Sample.Extensions;
using Integration.Sample.Models.Common;
using Integration.Sample.Options;
using Integration.Sample.Serializers.Json;
using Integration.Sample.Serializers.QueryString;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Common.Services
{
	public class HttpService : Disposable, IHttpService
	{
		private readonly IApiServerOptions _apiServerOptions;
		private readonly IJsonSerializer _jsonSerializer;
		private readonly IQueryStringSerializer _queryStringSerializer;

		private HttpClient _httpClient;

		public HttpService
		(
			IApiServerOptions appServerOptions,
			IJsonSerializer jsonSerializer,
			IQueryStringSerializer queryStringSerializer
		)
		{
			_apiServerOptions = appServerOptions;
			_jsonSerializer = jsonSerializer;
			_queryStringSerializer = queryStringSerializer;
		}

		public async Task<HttpOperationResult> GetAsync(string uri, object payload = null, string apiKey = null)
		{
			CheckDisposed();

			var requestUri = await CreateRequestUriAsync(uri, payload);

			var httpClient = GetHttpClient(apiKey);

			try
			{
				using (var message = await httpClient.GetAsync(requestUri))
					return new HttpOperationResult(message.StatusCode);
			}
			finally
			{
				if (apiKey != null)
					httpClient.Dispose();
			}
		}

		public async Task<HttpOperationResult<TResponse>> GetAsync<TResponse>(string uri, object payload = null, string apiKey = null, Func<string, Task<TResponse>> deserializer = null)
		{
			CheckDisposed();

			var requestUri = await CreateRequestUriAsync(uri, payload);

			var httpClient = GetHttpClient(apiKey);

			try
			{
				using (var message = await httpClient.GetAsync(requestUri))
				{
					var responseJson = await message.Content.ReadAsStringAsync();

					try
					{
						var response = deserializer == null
							? await _jsonSerializer.DeserializeAsync<TResponse>(responseJson)
							: await deserializer.Invoke(responseJson);

						return new HttpOperationResult<TResponse>(message.StatusCode, response);
					}
					catch
					{
						return new HttpOperationResult<TResponse>(HttpStatusCode.NotFound, default);
					}
				}
			}
			finally
			{
				if (apiKey != null)
					httpClient.Dispose();
			}
		}

		public async Task<HttpOperationResult> PostAsync(string uri, object payload, string apiKey = null)
		{
			CheckDisposed();

			var requestContent = await CreateContentPayloadAsync(payload);

			var httpClient = GetHttpClient(apiKey);

			try
			{
				using (var message = await httpClient.PostAsync(uri, requestContent))
					return new HttpOperationResult(message.StatusCode);
			}
			finally
			{
				if (apiKey != null)
					httpClient.Dispose();
			}
		}

		public async Task<HttpOperationResult<TResponse>> PostAsync<TResponse>(string uri, object payload, string apiKey = null, Func<string, Task<TResponse>> deserializer = null)
		{
			CheckDisposed();

			var requestContent = await CreateContentPayloadAsync(payload);

			var httpClient = GetHttpClient(apiKey);

			try
			{
				using (var message = await httpClient.PostAsync(uri, requestContent))
				{
					var responseJson = await message.Content.ReadAsStringAsync();

					try
					{
						var response = deserializer == null
							? await _jsonSerializer.DeserializeAsync<TResponse>(responseJson)
							: await deserializer.Invoke(responseJson);

						return new HttpOperationResult<TResponse>(message.StatusCode, response);
					}
					catch
					{
						return new HttpOperationResult<TResponse>(HttpStatusCode.NotFound, default);
					}
				}
			}
			finally
			{
				if (apiKey != null)
					httpClient.Dispose();
			}
		}

		public async Task<HttpOperationResult> PutAsync(string uri, object payload, string apiKey = null)
		{
			CheckDisposed();

			var requestContent = await CreateContentPayloadAsync(payload);

			var httpClient = GetHttpClient(apiKey);

			try
			{
				using (var message = await httpClient.PutAsync(uri, requestContent))
					return new HttpOperationResult(message.StatusCode);
			}
			finally
			{
				if (apiKey != null)
					httpClient.Dispose();
			}
		}

		public async Task<HttpOperationResult> PatchAsync(string uri, object payload, string apiKey = null)
		{
			CheckDisposed();

			var requestContent = await CreateContentPayloadAsync(payload);

			var httpClient = GetHttpClient(apiKey);

			try
			{
				using (var message = await httpClient.PatchAsync(uri, requestContent))
					return new HttpOperationResult(message.StatusCode);
			}
			finally
			{
				if (apiKey != null)
					httpClient.Dispose();
			}
		}

		public async Task<HttpOperationResult> DeleteAsync(string uri, object payload = null, string apiKey = null)
		{
			CheckDisposed();

			var requestUri = await CreateRequestUriAsync(uri, payload);

			var httpClient = GetHttpClient(apiKey);

			try
			{
				using (var message = await httpClient.DeleteAsync(requestUri))
					return new HttpOperationResult(message.StatusCode);
			}
			finally
			{
				if (apiKey != null)
					httpClient.Dispose();
			}
		}

		private HttpClient GetHttpClient(string apiKey)
		{
			if (apiKey == null)
			{
				if (_httpClient == null)
				{
					_httpClient = new HttpClient { BaseAddress = new Uri(_apiServerOptions.RootUrl), Timeout = TimeSpan.FromSeconds(30) };

					apiKey = _apiServerOptions.ApiKey.ToUnsecureString();
					_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiServerConstants.AuthenticationScheme, apiKey);
				}

				return _httpClient;
			}
			else
			{
				var httpClient = new HttpClient { BaseAddress = new Uri(_apiServerOptions.RootUrl), Timeout = TimeSpan.FromSeconds(30) };
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiServerConstants.AuthenticationScheme, apiKey);

				return httpClient;
			}
		}

		private async Task<StringContent> CreateContentPayloadAsync(object payload)
		{
			var requestJson = await _jsonSerializer.SerializeAsync(payload);
			return new StringContent(requestJson, Encoding.UTF8, "application/json");
		}

		private async Task<string> CreateRequestUriAsync(string uri, object payload = null)
		{
			if (payload != null)
			{
				var queryString = await _queryStringSerializer.SerializeAsync(payload);
				if (!string.IsNullOrWhiteSpace(queryString))
					uri = $"{uri}?{queryString}";
			}

			return uri;
		}

		public override void DisposeManaged()
		{
			if (this._httpClient != null)
			{
				this._httpClient.Dispose();
				this._httpClient = null;
			}
		}
	}
}