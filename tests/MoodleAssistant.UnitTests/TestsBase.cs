using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MoodleAssistant.UnitTests
{
    public abstract class TestsBase : IDisposable
    {
        protected readonly IWebDriver WebDriver;
        protected const string SiteUrl = "https://localhost:44379/";
        protected const string AssetsDir = @"C:\Users\andre\source\repos\MoodleAssistant\tests\assets\xmlFiles\";
        protected const string RandomQuestionPageTitle = "Random Questions - MoodleAssistant";
        protected const string SummaryPagePageTitle = "Summary Page - MoodleAssistant";
        protected const string UploadCsvPageTitle = "Upload CSV - MoodleAssistant";
        private const string UploadXmlButtonId = "upload-xml-question";
        private const string UploadCsvButtonId = "upload-csv-answers";

        protected TestsBase(string webPage)
        {
            WebDriver = new ChromeDriver { Url = SiteUrl + webPage };
        }

        public void Dispose()
        {
            WebDriver.Close();
            WebDriver.Dispose();
        }

        public void UploadXmlFile(string fileName)
        {
            var element = WebDriver.FindElement(By.Id(UploadXmlButtonId));
            element.SendKeys(AssetsDir + fileName);
        }

        public void UploadCsvFile(string fileName)
        {
            var element = WebDriver.FindElement(By.Id(UploadCsvButtonId));
            element.SendKeys(AssetsDir + fileName);
        }
    }
}