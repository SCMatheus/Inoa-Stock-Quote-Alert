using System.Net.Mail;

namespace Teste.Inoa.StockQuoteAlert.Settings
{
    public class MailSettings
    {
        public MailAddress Sender { get; set; }
        public MailAddress Receiver { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string SenderPassword { get; set; }
        public MailSettings(MailAddress sender, MailAddress receiver, string host, int port, string senderPassword)
        {
            Sender = sender;
            Receiver = receiver;
            Host = host;
            Port = port;
            SenderPassword = senderPassword;
        }
        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Host) || string.IsNullOrWhiteSpace(SenderPassword))
                return false;
            return true;
        }

    }

}
