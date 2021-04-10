using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Teste.Inoa.StockQuoteAlert.Interfaces;
using Teste.Inoa.StockQuoteAlert.Services;
using Teste.Inoa.StockQuoteAlert.Stock;

namespace Teste.Inoa.StockQuoteAlert.DependencyInjection
{
    public static class DependencyInjectionService
    {
        private static readonly string _settingsFile = "Settings.ini";
        public static IHostBuilder CreateHostBuilder(AlertStock alertStock)
        {
            return Host.CreateDefaultBuilder()
                       .ConfigureServices((hostContext, services) =>
                       {
                       services.AddTransient<ISettingsService>((x) =>
                                            new SettingsService($"{Directory.GetCurrentDirectory()}\\{_settingsFile}"));
                       services.AddTransient<IMailSenderService, MailSenderService>();
                       services.AddTransient<IApiConsumerService, ApiConsumerService>();
                       services.AddTransient<IStockQuoteAlertService>((x) => 
                                            new StockQuoteAlertService(x.GetRequiredService<IMailSenderService>(),
                                                                        x.GetRequiredService<IApiConsumerService>(),
                                                                        x.GetRequiredService<ISettingsService>(),
                                                                        x.GetRequiredService<ILogger<StockQuoteAlertService>>(),
                                                                        alertStock
                                                                        ));
                       services.AddHostedService((x) => new StockQuoteAlertService(x.GetRequiredService<IMailSenderService>(),
                                                        x.GetRequiredService<IApiConsumerService>(),
                                                        x.GetRequiredService<ISettingsService>(),
                                                        x.GetRequiredService<ILogger<StockQuoteAlertService>>(),
                                                        alertStock
                                                        ));
                       });
        }
    }
}
