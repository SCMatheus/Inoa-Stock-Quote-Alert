using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Inoa.StockQuoteAlert.Interfaces
{
    public interface IMailSenderService
    {
        Task SendEmailAsync(string subject, string message);
    }
}
