using System;
using Teste.Inoa.StockQuoteAlert.Stock;

namespace Teste.Inoa.StockQuoteAlert.Mappers
{
    public static class ArgsToAlertStock
    {
        public static AlertStock Map(this string[] origem)
        {
            if (!(IsValid(origem) && 
                  float.TryParse(origem[1], out float sellPrice) && 
                  float.TryParse(origem[2], out float buyPrice)))
                throw new Exception("Input arguments are invalid");
            var name = origem[0];
            
            return new AlertStock(name,sellPrice,buyPrice);
        }
        private static bool IsValid(string[] origem)
        {
            if (origem.Length != 3)
                return false;
            return true;
        }
    }
}
