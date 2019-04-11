using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Template.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = CreateConfiguration(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                .CreateLogger();

            CreateWebHostBuilder(args, config).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args, IConfiguration configuration) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(configuration);

        private static IConfiguration CreateConfiguration(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            foreach (var argument in args)
            {
                configBuilder.AddJsonFile($"appsettings.{argument}.json", true, true);
            }

            configBuilder.AddEnvironmentVariables();
            return configBuilder.Build();
        }
    }
}
