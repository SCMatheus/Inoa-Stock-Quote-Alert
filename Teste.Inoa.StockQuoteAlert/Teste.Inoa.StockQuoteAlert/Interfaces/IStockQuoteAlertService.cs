using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Inoa.StockQuoteAlert.Stocks;

namespace Teste.Inoa.StockQuoteAlert.Interfaces
{
    public interface IStockQuoteAlertService
    {
        void StockQuoteAlert(Stock stock);
    }
}
