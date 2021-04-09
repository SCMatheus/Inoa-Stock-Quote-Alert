using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teste.Inoa.StockQuoteAlert.Services;

namespace Teste.Inoa.StockQuoteAlert.TestesUnitarios.Persistence
{
    [TestClass]
    public class SettingsServiceTeste
    {
        private readonly string _path;
        public SettingsServiceTeste()
        {
            _path = Directory.GetCurrentDirectory();
        }
        [TestMethod]
        public void TestLoadAllSettingsMailSenderError()
        {
            var settingsServiceError = Assert.ThrowsException<ArgumentException>(() => 
                                                    new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailSenderMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message,"O parâmetro 'address' não pode ser uma cadeia de " +
                                                    "caracteres vazia.\r\nNome do parâmetro: address");
        }

        [TestMethod]
        public void TestLoadAllSettingsMailReciverError()
        {
            var settingsServiceError = Assert.ThrowsException<ArgumentException>(() =>
                                                    new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailReceiverMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "O parâmetro 'address' não pode ser uma cadeia de " +
                                                    "caracteres vazia.\r\nNome do parâmetro: address");
        }

        [TestMethod]
        public void TestLoadAllSettingsMailPortError()
        {
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailPortMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "Mail settings error: Port is invalid.");
        }
        [TestMethod]
        public void TestLoadAllSettingsMailHostError()
        {
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailHostMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "Mail settings error: the value of some parameter is invalid.");
        }
        [TestMethod]
        public void TestLoadAllSettingsMailSenderPasswordError()
        {
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailSenderPasswordMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "Mail settings error: the value of some parameter is invalid.");
        }
        [TestMethod]
        public void TestLoadAllSettingsInvalidPathError()
        {
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidPathMock.ini"));
            Assert.AreEqual(settingsServiceError.Message, "Settings error: settings file not found.");
        }
        [TestMethod]
        public void TestLoadAllSettingsInvalidApiUrlError()
        {
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidApiUrlMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "Api settings error: the value of some parameter is invalid.");
        }
        [TestMethod]
        public void TestLoadAllSettingsInvalidApiKeyError()
        {
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidApiKeyMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "Api settings error: the value of some parameter is invalid.");
        }
        [TestMethod]
        public void TestLoadAllSettingsInvalidApiIntervalToRequestError()
        {
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidApiIntervalToRequestMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "API settings error: IntervalToRequest is invalid.");
        }
        [TestMethod]
        public void TestLoadAllSettingsSuccess()
        {
            var settingsService = new SettingsService($"{_path}\\Resources\\" +
                                                    $"Persistence\\SettingsValidMock.ini");

            var generalSettings = settingsService.LoadAllSettings();

            Assert.AreEqual(generalSettings.Mail.Sender, "teste@gmail.com");
            Assert.AreEqual(generalSettings.Mail.Receiver, "teste2@gmail.com");
            Assert.AreEqual(generalSettings.Mail.Host, "smtp.gmail.com");
            Assert.AreEqual(generalSettings.Mail.Port, 587);
            Assert.AreEqual(generalSettings.Mail.SenderPassword, "senha123");
            Assert.AreEqual(generalSettings.Api.Url, "https://teste.com.br");
            Assert.AreEqual(generalSettings.Api.Key, "123");
            Assert.AreEqual(generalSettings.Api.IntervalToRequest, 5);
        }
    }
}