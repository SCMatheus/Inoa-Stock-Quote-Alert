using System.Net.Mail;

namespace Teste.Inoa.StockQuoteAlert.Settings
{
    public class MailSettings
    {
        public MailSettings(MailAddress sender, MailAddress receiver, string host, int port, string senderPassword)
        {
            Sender = sender;
            Receiver = receiver;
            Host = host;
            Port = port;
            SenderPassword = senderPassword;
        }
        public MailAddress Sender { get; set; }
        public MailAddress Receiver { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string SenderPassword { get; set; }
    }
}
