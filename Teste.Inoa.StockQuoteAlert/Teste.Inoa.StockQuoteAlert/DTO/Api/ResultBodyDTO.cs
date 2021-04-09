using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teste.Inoa.StockQuoteAlert.DTO.Api
{
    public class ResultBodyDTO
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "document")]
        public string Document { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "market_time")]
        public MarketTimeDTO MarketTime { get; set; }

        [JsonProperty(PropertyName = "market_cap")]
        public double MarketCap { get; set; }

        [JsonProperty(PropertyName = "price")]
        public float Price { get; set; }

        [JsonProperty(PropertyName = "change_percent")]
        public double ChangePercent { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }
    }
}
