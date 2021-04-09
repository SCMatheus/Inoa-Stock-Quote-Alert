using System.Linq;
using Teste.Inoa.StockQuoteAlert.DTO.Api;
using Teste.Inoa.StockQuoteAlert.Stock;

namespace Teste.Inoa.StockQuoteAlert.Mappers
{
    public static class CurrentStockDtoToCurrentStock
    {
        public static CurrentStock Map(this CurrentStockDTO origem)
        {
            var stock = origem.Results.FirstOrDefault().Value;
            return new CurrentStock(stock.Symbol,stock.Price);
        }
    }
}
