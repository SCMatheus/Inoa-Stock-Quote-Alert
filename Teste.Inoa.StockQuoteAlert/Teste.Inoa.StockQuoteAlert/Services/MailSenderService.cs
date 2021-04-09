using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Teste.Inoa.StockQuoteAlert.Interfaces;
using Teste.Inoa.StockQuoteAlert.Settings;

namespace Teste.Inoa.StockQuoteAlert.Services
{
    public class MailSenderService : IMailSenderService
    {
        private readonly MailSettings _mailSettings;
        public MailSenderService(ISettingsService settingsService)
        {
            _mailSettings = settingsService.LoadAllSettings().Mail;
        }

        public Task SendEmailAsync(string subject, string message)
        {
            Execute(subject, message).Wait();
            return Task.FromResult(0);
        }
        private async Task Execute(string subject, string message)
        {
            MailMessage mail = new MailMessage(_mailSettings.Sender, _mailSettings.Receiver)
            {
                Subject = subject,
                Body = message
            };

            using (SmtpClient smtp = new SmtpClient(_mailSettings.Host, _mailSettings.Port))
            {
                smtp.Credentials = new NetworkCredential(_mailSettings.Sender.Address, _mailSettings.SenderPassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
