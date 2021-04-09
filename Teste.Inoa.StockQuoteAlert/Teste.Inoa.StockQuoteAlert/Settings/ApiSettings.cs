namespace Teste.Inoa.StockQuoteAlert.Settings
{
    public class ApiSettings
    {
        public string Url { get; set; }
        public string Key { get; set; }
        public int IntervalToRequest { get; set; }
        public ApiSettings(string url, string key, int intervalToRequest)
        {
            Url = url;
            Key = key;
            IntervalToRequest = intervalToRequest;
        }
        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Url) || string.IsNullOrWhiteSpace(Key))
                return false;
            return true;
        }
    }
}
