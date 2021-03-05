using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace MoodleAssistant.IntegrationTests
{
    public class BasicTests : IDisposable
    {
        protected readonly IWebDriver WebDriver;
        protected const string SiteUrl = "https://localhost:44379/";
        protected const string AssetsDir = @"C:\Users\andre\source\repos\MoodleAssistant\tests\assets\xmlFiles\";
        protected const string DownloadPageTitle = "Download - MoodleAssistant";
        private const string UploadXmlButtonId = "upload-xml-question";
        private const string UploadCsvButtonId = "upload-csv-answers";
        private const string UploadCsvSummaryButton = "upload-csv";

        public BasicTests()
        {
            WebDriver = new ChromeDriver { Url = SiteUrl + "Xml/Upload" };
        }

        [Fact]
        public void MoodleAssistant_TestAllFunctionality_WithMultiChoiceQuestion_Ok()
        {
            UseApplication("multichoice");
            Assert.Equal(DownloadPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_TestAllFunctionality_WithTrueFalseQuestion_Ok()
        {
            UseApplication("trueFalse");
            Assert.Equal(DownloadPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_TestAllFunctionality_WithMatchingQuestion_Ok()
        {
            UseApplication("matching");
            Assert.Equal(DownloadPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_TestAllFunctionality_WithShortAnswerQuestion_Ok()
        {
            UseApplication("shortAnswer");
            Assert.Equal(DownloadPageTitle, WebDriver.Title);
        }

        private void UseApplication(string filename)
        {
            var element = WebDriver.FindElement(By.Id(UploadXmlButtonId));
            element.SendKeys(AssetsDir + filename +".xml");
            WebDriver.FindElement(By.Id(UploadCsvSummaryButton)).Click();
            element = WebDriver.FindElement(By.Id(UploadCsvButtonId));
            element.SendKeys(AssetsDir + filename + ".csv");
        }

        
        public void Dispose()
        {
            WebDriver.Close();
            WebDriver.Dispose();
        }
    }
}