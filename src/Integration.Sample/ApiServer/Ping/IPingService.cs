using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Ping
{
	public interface IPingService
	{
		Task<bool> PingAsync(string apiKey = null);
	}
}