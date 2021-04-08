namespace Teste.Inoa.StockQuoteAlert.Settings
{
    public class ApiSettings
    {
        public ApiSettings(string url, string apiKey, int intervalToRequest)
        {
            Url = url;
            ApiKey = apiKey;
            IntervalToRequest = intervalToRequest;
        }
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public int IntervalToRequest { get; set; }
    }
}
