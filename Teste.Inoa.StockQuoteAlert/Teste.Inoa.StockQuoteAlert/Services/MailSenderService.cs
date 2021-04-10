using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Teste.Inoa.StockQuoteAlert.Interfaces;
using Teste.Inoa.StockQuoteAlert.Settings;

namespace Teste.Inoa.StockQuoteAlert.Services
{
    public class MailSenderService : IMailSenderService
    {
        private readonly MailSettings _mailSettings;
        private readonly ILogger<MailSenderService> _logger;
        public MailSenderService(ISettingsService settingsService,
                                 ILogger<MailSenderService> logger)
        {
            _mailSettings = settingsService.LoadAllSettings().Mail;
            _logger = logger;
        }

        public async Task SendEmailAsync(string subject, string message)
        {
            try
            {
                await Execute(subject, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task Execute(string subject, string message)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
