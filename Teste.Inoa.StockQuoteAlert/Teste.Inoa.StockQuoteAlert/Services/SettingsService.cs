using Teste.Inoa.StockQuoteAlert.Settings;
using Teste.Inoa.StockQuoteAlert.Interfaces;
using Teste.Inoa.StockQuoteAlert.Persistence;
using System.IO;
using System.Net.Mail;
using System;

namespace Teste.Inoa.StockQuoteAlert.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly string _sectionApi = "Api";
        private readonly string _sectionMail = "Mail";
        private readonly string _mailSenderKey = "Sender";
        private readonly string _mailReceiverKey = "Receiver";
        private readonly string _mailHostKey = "Host";
        private readonly string _mailPortKey = "Port";
        private readonly string _mailSenderPasswordKey = "SenderPassword";
        private readonly string _apiUrlKey = "Url";
        private readonly string _apiApiKey = "ApiKey";
        private readonly string _apiIntervalToRequestKey = "IntervalToRequest";
        private readonly string _fileSettingsPath;
        public SettingsService(string fileSettingsPath)
        {
            _fileSettingsPath = fileSettingsPath;
        }
        public GeneralSettings LoadAllSettings()
        {
            var settingsFile = new IniFile(_fileSettingsPath);

            var mailSettings = LoadMailSettings(settingsFile);
            var apiSettings = LoadApiSettings(settingsFile);

            return new GeneralSettings(apiSettings, mailSettings);
        }
        private MailSettings LoadMailSettings(IniFile file)
        {
            int mailPortValue = 0;

            var mailSenderValue = new MailAddress(file.IniReadValue(_sectionMail, _mailSenderKey));
            var mailReciverValue = new MailAddress(file.IniReadValue(_sectionMail, _mailReceiverKey));
            var mailHostValue = file.IniReadValue(_sectionMail, _mailHostKey);
            if (!int.TryParse(file.IniReadValue(_sectionMail, _mailPortKey), out mailPortValue))
                throw new Exception("Mail settings error: Port is invalid.");
            var mailSenderPasswordValue = file.IniReadValue(_sectionMail, _mailSenderPasswordKey);

            var mailSettings = new MailSettings(mailSenderValue, mailReciverValue, mailHostValue,
                                    mailPortValue, mailSenderPasswordValue);

            if(!mailSettings.IsValid())
                throw new Exception("Mail settings error: the value of some parameter is invalid.");

            return mailSettings;
        }
        private ApiSettings LoadApiSettings(IniFile file)
        {
            int apiIntervalToRequest = 0;

            var apiUrlValue = file.IniReadValue(_sectionApi, _apiUrlKey);
            var apiKeyValue = file.IniReadValue(_sectionApi, _apiApiKey);
            if (!int.TryParse(file.IniReadValue(_sectionApi, _apiIntervalToRequestKey), out apiIntervalToRequest))
                throw new Exception("API settings error: IntervalToRequest is invalid.");

            return new ApiSettings(apiUrlValue, apiKeyValue, apiIntervalToRequest);
        }
    }
}
