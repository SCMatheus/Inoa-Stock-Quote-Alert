using System.Collections.Generic;
using Newtonsoft.Json;

namespace Teste.Inoa.StockQuoteAlert.DTO.Api
{
    public class CurrentStockDTO
    {
        [JsonProperty(PropertyName = "by")]
        public string By { get; set; }
        [JsonProperty(PropertyName = "valid_key")]
        public bool ValidKey { get; set; }
        [JsonProperty(PropertyName = "results")]
        public Dictionary<string, ResultBodyDTO> Results { get; set; }
        [JsonProperty(PropertyName = "execution_time")]
        public double ExecutionTime { get; set; }
        [JsonProperty(PropertyName = "from_cache")]
        public bool FromCache { get; set; }
    }
}
