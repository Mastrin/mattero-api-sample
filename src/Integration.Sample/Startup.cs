using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.Contacts;
using Integration.Sample.ApiServer.CostTemplates;
using Integration.Sample.ApiServer.Matters;
using Integration.Sample.ApiServer.Ping;
using Integration.Sample.ApiServer.PracticeAreas;
using Integration.Sample.ApiServer.Tasks;
using Integration.Sample.Options;
using Integration.Sample.Serializers.Json;
using Integration.Sample.Serializers.QueryString;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Integration.Sample
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			// Config Options
			services
				.AddSingleton<IApiServerOptions, ApiServerOptions>();

			// Mattero API Services
			services
				.AddScoped<IHttpService, HttpService>()
				.AddScoped<IPingService, PingService>()
				.AddScoped<IContactsService, ContactsService>()
				.AddScoped<IMattersService, MattersService>()
				.AddScoped<ITasksService, TasksService>()
				.AddScoped<IPracticeAreasService, PracticeAreasService>()
				.AddScoped<ICostTemplatesService, CostTemplatesService>();

			// Serializers
			services
				.AddSingleton<IJsonSerializer, JsonSerializer>()
				.AddSingleton<IQueryStringSerializer, QueryStringSerializer>();

			// ASP.NET
			services
				.AddSession()
				.AddDistributedMemoryCache()
				.AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
				.AddRouting(options => options.LowercaseUrls = true)
				.AddMvc()
				.AddNewtonsoftJson();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			//app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseSession();

			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
