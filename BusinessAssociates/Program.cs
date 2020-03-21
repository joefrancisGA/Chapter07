using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace EGMS.BusinessAssociates.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

            IConfiguration configs = configurationBuilder.Build();

            string urls = configs["EGMSSettings:UseUrls"];

            var builder = Host.CreateDefaultBuilder(args);

            return builder.ConfigureWebHostDefaults(webBuilder =>
            {
                if (!string.IsNullOrEmpty(urls))
                {
                    webBuilder.UseUrls(urls);
                }
                webBuilder.UseStartup<Startup>();
            });
        }
        //static Program() =>
        //    // ReSharper disable once PossibleNullReferenceException
        //    CurrentDirectory = Path.GetDirectoryName(GetEntryAssembly().Location);

        //public static void Main()
        //{
        //    Log.Logger = new LoggerConfiguration()
        //        .WriteTo.Console()
        //        .MinimumLevel.Debug()
        //        .CreateLogger();

        //    var configuration = BuildConfiguration();

        //    ConfigureWebHost(configuration).Build().Run();
        //}

        //private static IConfiguration BuildConfiguration()
        //    => new ConfigurationBuilder()
        //        .SetBasePath(CurrentDirectory)
        //        .Build();

        //private static IWebHostBuilder ConfigureWebHost(IConfiguration configuration)
        //    => new WebHostBuilder()
        //        .UseStartup<Startup>()
        //        .UseConfiguration(configuration)
        //        .UseContentRoot(CurrentDirectory)
        //        .UseKestrel();
    }
}