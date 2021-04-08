using System.Net.Mail;

namespace Teste.Inoa.StockQuoteAlert.Configuracoes
{
    public class MailSettings
    {
        public MailAddress Sender { get; set; }
        public MailAddress Receiver { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string SenderPassword { get; set; }
    }
}
