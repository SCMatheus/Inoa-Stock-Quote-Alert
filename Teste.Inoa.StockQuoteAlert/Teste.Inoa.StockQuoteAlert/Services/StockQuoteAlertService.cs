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
            try
            {
                var currentStock = GetCurrentStock();

                if (currentStock.Price <= _alertStock.BuyPrice)
                {
                    SendMailForPurchase(_alertStock, currentStock).GetAwaiter();
                }
                else if (currentStock.Price >= _alertStock.SellPrice)
                {
                    SendMailForSale(_alertStock, currentStock).GetAwaiter();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private CurrentStock GetCurrentStock()
        {
            _logger.LogInformation($"Getting stock value from the API at {DateTimeOffset.Now.DateTime}");

            var currentStock = _apiConsumerService.GetCurrentStock(_alertStock);

            _logger.LogInformation($"The stock value was obtained from the API at {DateTimeOffset.Now.DateTime}");

            return currentStock;
        }
        private async Task SendMailForSale(AlertStock alertStock, CurrentStock currentStock)
        {
            try
            {
                _logger.LogInformation($"Sending sales email at {DateTimeOffset.Now.DateTime}");

                var message = $"It is a good time to sell your stocks of {alertStock.Name} " +
                          $"the value of the stocks is R$ {currentStock.Price}";
                await _mailSenderService.SendEmailAsync($"Recommendation for the sale of stocks", message);

                _logger.LogInformation($"Sales email sent at {DateTimeOffset.Now.DateTime}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                Console.ReadKey();
            }
        }
        private async Task SendMailForPurchase(AlertStock alertStock, CurrentStock currentStock)
        {
            try
            {
                _logger.LogInformation($"Sending purchase email at {DateTimeOffset.Now.DateTime}");

                var message = $"It is a good time to buy stocks of {alertStock.Name} " +
                              $"the value of the stocks is R$ {currentStock.Price}";
                await _mailSenderService.SendEmailAsync($"Recommendation for the purchase of stocks", message);

                _logger.LogInformation($"Purchase email sent at {DateTimeOffset.Now.DateTime}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                Console.ReadKey();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(TimeSpan.FromMinutes(0.1), stoppingToken);
            _logger.LogInformation($"Service running at: {DateTimeOffset.Now.DateTime}");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    StockQuoteAlert();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                await Task.Delay(TimeSpan.FromMinutes(_intervalToRequest), stoppingToken);
            }
        }

    }
}

