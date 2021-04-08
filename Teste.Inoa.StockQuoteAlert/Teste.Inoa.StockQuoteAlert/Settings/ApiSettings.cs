using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Inoa.StockQuoteAlert.Configuracoes
{
    public class ApiSettings
    {
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public int IntervalToRequest { get; set; }
    }
}
