using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Formatters;
using CityInfo.DAL.Repositories;
using NLog.Web;
using NLog.Extensions.Logging;

namespace CityInfo.Api
{
	public class Startup
	{

		private readonly ILogger _logger;


		public Startup(IHostingEnvironment environment, ILoggerFactory loggerFactory)
		{

			var builder = new ConfigurationBuilder()
				.SetBasePath(environment.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();


			Configuration = builder.Build();

			_logger = loggerFactory.CreateLogger("");
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

			var connectionString = Configuration["ConnectionStrings:DBConnection"];


			_logger.LogInformation("Connection string: " + connectionString);

			
			services.AddScoped<IDataStorage, DataStorage>(_ => new  DataStorage(connectionString, _logger));

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{

			env.ConfigureNLog("nlog.config");

			loggerFactory.AddConsole().AddNLog().AddDebug();


			if (true || env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();

			Start.AutoMapperBootstrap.Configure();
		}

	}
}
