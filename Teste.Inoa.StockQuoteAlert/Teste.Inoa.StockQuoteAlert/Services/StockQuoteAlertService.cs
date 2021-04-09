using System.Threading.Tasks;
using Teste.Inoa.StockQuoteAlert.Interfaces;
using Teste.Inoa.StockQuoteAlert.Stock;

namespace Teste.Inoa.StockQuoteAlert.Services
{
    public class StockQuoteAlertService : IStockQuoteAlertService
    {
        private readonly IMailSenderService _mailSenderService;
        public StockQuoteAlertService(IMailSenderService mailSenderService)
        {
            _mailSenderService = mailSenderService;
        }
        public void StockQuoteAlert(AlertStock stock)
        {
            SendMailForSale(stock, 26).GetAwaiter();
            SendMailForPurchase(stock, 26).GetAwaiter();
        }
        private async Task SendMailForSale(AlertStock stock, float price)
        {
            var message = $"It is a good time to sell your shares of {stock.Name} " +
                          $"the value of the shares is R$ {price}";
            await _mailSenderService.SendEmailAsync($"Recommendation for the sale of shares", message);
        }
        private async Task SendMailForPurchase(AlertStock stock, float price)
        {
            var message = $"It is a good time to buy shares of {stock.Name} " +
                          $"the value of the shares is R$ {price}";
            await _mailSenderService.SendEmailAsync($"Recommendation for the purchase of shares", message);
        }
    }
}
