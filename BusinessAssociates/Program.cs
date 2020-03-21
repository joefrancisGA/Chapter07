using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using static System.Environment;
using static System.Reflection.Assembly;

namespace EGMS.BusinessAssociates.API
{
    public static class Program
    {
        static Program() =>
            // ReSharper disable once PossibleNullReferenceException
            CurrentDirectory = Path.GetDirectoryName(GetEntryAssembly().Location);

        public static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

            var configuration = BuildConfiguration();

            ConfigureWebHost(configuration).Build().Run();
        }

        private static IConfiguration BuildConfiguration()
            => new ConfigurationBuilder()
                .SetBasePath(CurrentDirectory)
                .Build();

        private static IWebHostBuilder ConfigureWebHost(IConfiguration configuration)
            => new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .UseContentRoot(CurrentDirectory)
                .UseKestrel();
    }
}