using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Inoa.StockQuoteAlert.DependencyInjection;
using Teste.Inoa.StockQuoteAlert.Mappers;
using Teste.Inoa.StockQuoteAlert.Stock;

namespace Teste.Inoa.StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var alertStock = args.Map();
                var alertStock = new AlertStock("PETR4",22.67, 22.59);
                DependencyInjectionService.CreateHostBuilder(alertStock).Build().StartAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
