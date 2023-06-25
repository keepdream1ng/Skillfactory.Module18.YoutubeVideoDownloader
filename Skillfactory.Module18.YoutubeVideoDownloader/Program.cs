using YoutubeExplode;
using YoutubeExplode.Converter;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Skillfactory.Module18.YoutubeVideoDownloader.Services;
using Microsoft.Extensions.Configuration;
using Serilog;
using Microsoft.Extensions.Hosting;
using Skillfactory.Module18.YoutubeVideoDownloader.Commands;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder().Build();
            host.Services.GetRequiredService<IUI>().Run();
        }

        private static IHostBuilder CreateHostBuilder()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            // Below this object will be registered in two DI interfaces.
            var vidCommandsList = new VidCommands();

            return  Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IUI, UI>();
                    services.AddSingleton<IVideoInfoService, MyYoutubeClient>();
                    services.AddSingleton<IVideoDownloader, MyYoutubeClient>();
                    services.AddSingleton<ICommandStorage>(vidCommandsList);
                    services.AddSingleton<ICommandCanceller>(vidCommandsList);
                    services.AddSingleton<ICommandFactory, CommandFactory>();
                })
                .UseSerilog();
        }
    }
}