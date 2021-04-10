using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Teste.Inoa.StockQuoteAlert.Interfaces;
using Teste.Inoa.StockQuoteAlert.Stock;

namespace Teste.Inoa.StockQuoteAlert.Services
{
    public class StockQuoteAlertService : BackgroundService, IStockQuoteAlertService
    {
        private readonly IMailSenderService _mailSenderService;
        private readonly IApiConsumerService _apiConsumerService;
        private readonly int _intervalToRequest;
        private readonly ILogger<StockQuoteAlertService> _logger;
        private readonly AlertStock _alertStock;
        public StockQuoteAlertService(IMailSenderService mailSenderService,
                                      IApiConsumerService apiConsumerService,
                                      ISettingsService settingsService,
                                      ILogger<StockQuoteAlertService> logger,
                                      AlertStock alertStock)
        {
            _mailSenderService = mailSenderService;
            _apiConsumerService = apiConsumerService;
            _intervalToRequest = settingsService.LoadAllSettings().Api.IntervalToRequest;
            _logger = logger;
            _alertStock = alertStock;
        }
        public void StockQuoteAlert()
        {
            _logger.LogInformation($"Getting stock value from the API at {DateTimeOffset.Now:dd/MM/yy:hh:MM}");
            var currentStock = _apiConsumerService.GetCurrentStock(_alertStock);
            _logger.LogInformation($"The stock value was obtained from the API at {DateTimeOffset.Now:dd/MM/yy:hh:MM}");

            if (currentStock.Price <= _alertStock.BuyPrice)
            {
                _logger.LogInformation($"Sending purchase email at {DateTimeOffset.Now:dd/MM/yy:hh:MM}");
                SendMailForPurchase(_alertStock, currentStock).GetAwaiter();
                _logger.LogInformation($"Sending purchase email at {DateTimeOffset.Now:dd/MM/yy:hh:MM}");
            }
            else if(currentStock.Price >= _alertStock.SellPrice)
            {
                _logger.LogInformation($"Sending sales email at {DateTimeOffset.Now:dd/MM/yy:hh:MM}");
                SendMailForSale(_alertStock, currentStock).GetAwaiter();
                _logger.LogInformation($"Sales email sent at {DateTimeOffset.Now:dd/MM/yy:hh:MM}");
            }
        }
        private async Task SendMailForSale(AlertStock alertStock, CurrentStock currentStock)
        {
            var message = $"It is a good time to sell your shares of {alertStock.Name} " +
                          $"the value of the shares is R$ {currentStock.Price}";
            await _mailSenderService.SendEmailAsync($"Recommendation for the sale of shares", message);
        }
        private async Task SendMailForPurchase(AlertStock alertStock, CurrentStock currentStock)
        {
            var message = $"It is a good time to buy shares of {alertStock.Name} " +
                          $"the value of the shares is R$ {currentStock.Price}";
            await _mailSenderService.SendEmailAsync($"Recommendation for the purchase of shares", message);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Service running at: {DateTimeOffset.Now:dd/MM/yy:hh:MM}");
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    StockQuoteAlert();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            await Task.Delay(TimeSpan.FromMinutes(_intervalToRequest), stoppingToken);
        }
    }
}
