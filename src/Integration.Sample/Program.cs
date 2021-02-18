using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Integration.Sample
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			using var host = BuildWebHost(args);
			await host.RunAsync();
		}

		private static IHost BuildWebHost(string[] args)
			=> Host
				.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>())
				.Build();
	}
}