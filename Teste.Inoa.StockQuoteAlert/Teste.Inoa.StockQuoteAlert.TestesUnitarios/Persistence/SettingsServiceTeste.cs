using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teste.Inoa.StockQuoteAlert.Services;

namespace Teste.Inoa.StockQuoteAlert.TestesUnitarios.Persistence
{
    [TestClass]
    public class SettingsServiceTeste
    {
        [TestMethod]
        public void TestLoadAllSettingsMailSenderError()
        {
            var path = Directory.GetCurrentDirectory();
            var settingsServiceError = Assert.ThrowsException<ArgumentException>(() => 
                                                    new SettingsService($"{path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailSenderMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message,"O parâmetro 'address' não pode ser uma cadeia de " +
                                                    "caracteres vazia.\r\nNome do parâmetro: address");
        }

        [TestMethod]
        public void TestLoadAllSettingsMailReciverError()
        {
            var path = Directory.GetCurrentDirectory();
            var settingsServiceError = Assert.ThrowsException<ArgumentException>(() =>
                                                    new SettingsService($"{path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailReceiverMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "O parâmetro 'address' não pode ser uma cadeia de " +
                                                    "caracteres vazia.\r\nNome do parâmetro: address");
        }

        [TestMethod]
        public void TestLoadAllSettingsMailPortError()
        {
            var path = Directory.GetCurrentDirectory();
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailPortMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "Mail settings error: Port is invalid.");
        }
        [TestMethod]
        public void TestLoadAllSettingsMailHostError()
        {
            var path = Directory.GetCurrentDirectory();
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailHostMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "Mail settings error: the value of some parameter is invalid.");
        }
        [TestMethod]
        public void TestLoadAllSettingsMailSenderPasswordError()
        {
            var path = Directory.GetCurrentDirectory();
            var settingsServiceError = Assert.ThrowsException<Exception>(() =>
                                                    new SettingsService($"{path}\\Resources\\" +
                                                    $"Persistence\\SettingsInvalidMailSenderPasswordMock.ini")
                                                    .LoadAllSettings());
            Assert.AreEqual(settingsServiceError.Message, "Mail settings error: the value of some parameter is invalid.");
        }
        [TestMethod]
        public void TestLoadAllSettingsSuccess()
        {
            var path = Directory.GetCurrentDirectory();
            var settingsService = new SettingsService($"{path}\\Resources\\" +
                                                    $"Persistence\\SettingsValidMock.ini");

            var generalSettings = settingsService.LoadAllSettings();

            Assert.AreEqual(generalSettings.Mail.Sender, "teste@gmail.com");
            Assert.AreEqual(generalSettings.Mail.Receiver, "teste2@gmail.com");
            Assert.AreEqual(generalSettings.Mail.Host, "smtp.gmail.com");
            Assert.AreEqual(generalSettings.Mail.Port, 587);
            Assert.AreEqual(generalSettings.Mail.SenderPassword, "senha123");
        }
    }
}