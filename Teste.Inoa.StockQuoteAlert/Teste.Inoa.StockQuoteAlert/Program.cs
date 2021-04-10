using System;
using Microsoft.Extensions.Hosting;
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
                DependencyInjectionService.CreateHostBuilder(alertStock).Build().Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
