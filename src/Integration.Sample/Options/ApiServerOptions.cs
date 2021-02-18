using Integration.Sample.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Security;

namespace Integration.Sample.Options
{
	public class ApiServerOptions : IApiServerOptions
	{
		private const string Name = "ApiServer";

		public ApiServerOptions(IConfiguration configuration)
		{
			this.RootUrl = configuration
				.GetValue<string>($"{Name}:{nameof(RootUrl)}");

			if (string.IsNullOrWhiteSpace(this.RootUrl))
				throw new InvalidOperationException("RootUrl in appsettings.json must have a value, that value must be pointing towards the Api Server you wish to connect to");

			string apiKey = configuration
				.GetValue<string>($"{Name}:{nameof(ApiKey)}");

			if (string.IsNullOrWhiteSpace(apiKey))
				throw new InvalidOperationException("ApiKey in appsettings.json must have a value, that value must be a valid and current API key for the Api Server");

			this.ApiKey = apiKey
				.ToSecureString();

		}

		public string RootUrl { get; }

		public SecureString ApiKey { get; }
	}
}