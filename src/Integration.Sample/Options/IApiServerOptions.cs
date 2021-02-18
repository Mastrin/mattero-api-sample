using System.Security;

namespace Integration.Sample.Options
{
	public interface IApiServerOptions
	{
		string RootUrl { get; }

		SecureString ApiKey { get; }
	}
}