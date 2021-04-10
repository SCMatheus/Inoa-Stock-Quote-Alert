using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Teste.Inoa.StockQuoteAlert.DTO.Api;
using Teste.Inoa.StockQuoteAlert.Interfaces;
using Teste.Inoa.StockQuoteAlert.Mappers;
using Teste.Inoa.StockQuoteAlert.Settings;
using Teste.Inoa.StockQuoteAlert.Stock;

namespace Teste.Inoa.StockQuoteAlert.Services
{
    public class ApiConsumerService : IApiConsumerService
    {
        private readonly ApiSettings _apiSettings;
        public ApiConsumerService(ISettingsService settingsService)
        {
            _apiSettings = settingsService.LoadAllSettings().Api;
        }
        private async Task<CurrentStockDTO> GetCurrentStockDTOAsync(AlertStock alertStock)
        {
            using (var client = new HttpClient())
            {
                var url = _apiSettings.Url.EndsWith("/") ? _apiSettings.Url : _apiSettings.Url + "/";
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"stock_price?key={ _apiSettings.Key }&symbol={alertStock.Name}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Api response error: {response.StatusCode}");
  
                return await response.Content.ReadAsAsync<CurrentStockDTO>();
            }
        }

        public CurrentStock GetCurrentStock(AlertStock alertStock)
        {
            return GetCurrentStockDTOAsync(alertStock).Result.Map();
        }

    }
}
