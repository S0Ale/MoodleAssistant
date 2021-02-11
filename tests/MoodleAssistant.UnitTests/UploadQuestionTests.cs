using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace MoodleAssistant.UnitTests
{
    public abstract class TestsBase : IDisposable
    {
        protected readonly IWebDriver _webDriver;
        protected const string SiteUrl = "https://localhost:44379/Home/RandomQuestions";

        protected TestsBase()
        {
            _webDriver = new ChromeDriver { Url = SiteUrl };
        }

        public void Dispose()
        {
            _webDriver.Close();
            _webDriver.Dispose();
        }
    }

    public class UploadQuestionTests : TestsBase
    {
       
        private const string AssetsDir = @"C:\Users\andre\source\repos\MoodleAssistant\tests\assets\xmlFiles\";
        private const string RandomQuestionPageTitle = "Random Questions - MoodleAssistant";
        private const string UploadXmlButtonId = "upload-xml-question";
        private const string AlertError = "alert-error-xml";


        [Fact]
        public void MoodleAssistant_UploadXML_NonXMLFile_ReturnToUpload()
        {
            UploadFile("txtFile.txt");
            Assert.Equal(RandomQuestionPageTitle, _webDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_NonXMLFile_DisplaysAlert()
        {
            UploadFile("txtFile.txt");
            Assert.True(_webDriver.FindElement(By.Id(AlertError)).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadXML_EmptyXML_ReturnToUpload()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public void MoodleAssistant_UploadXML_NonMoodleXMLFormat_ReturnToUpload()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutRandomizableParameters_ReturnToUpload()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void MoodleAssistant_UploadXML_CorrectXMLFile_Ok()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void MoodleAssistant_UploadXML_CorrectXMLFile_TakeParameters()
        {
            throw new NotImplementedException();
        }
        private void UploadFile(string fileName)
        {
            var element = _webDriver.FindElement(By.Id(UploadXmlButtonId));
            element.SendKeys(AssetsDir + fileName);
        }
    }
}