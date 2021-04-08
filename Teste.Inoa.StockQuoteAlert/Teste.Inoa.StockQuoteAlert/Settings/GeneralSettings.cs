namespace Teste.Inoa.StockQuoteAlert.Settings
{
    public class GeneralSettings
    {
        public GeneralSettings(ApiSettings api, MailSettings mail)
        {
            Api = api;
            Mail = mail;
        }
        public ApiSettings Api { get; set; }
        public MailSettings Mail { get; set; }
    }
}
