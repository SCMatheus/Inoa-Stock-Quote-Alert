using Newtonsoft.Json;

namespace Teste.Inoa.StockQuoteAlert.DTO.Api
{
    public class MarketTimeDTO
    {
        [JsonProperty(PropertyName = "open")]
        public string Open { get; set; }

        [JsonProperty(PropertyName = "close")]
        public string Close { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public int Timezone { get; set; }
    }
}
