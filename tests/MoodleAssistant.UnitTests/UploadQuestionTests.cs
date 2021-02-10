using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace MoodleAssistant.UnitTests
{
    public class UploadQuestionTests
    {
        private readonly IWebDriver _webDriver;
        private const string SiteUrl = "to-be-defined";
        private const string AssetsDir = @"..\assets\xmlFiles\";
        private const string UploadXmlButtonId = "upload-xml-question";
        private const string AlertNotXml = "alert-not-xml-file";

        public UploadQuestionTests()
        {
            _webDriver = new ChromeDriver {Url = SiteUrl + @"\randomQuestions" };
        }

        [Fact]
        public void MoodleAssistant_UploadXML_NonXMLFile_ReturnToUpload()
        {
            UploadFile("txtFile.txt");
            Assert.Equal(_webDriver.Url, SiteUrl);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_NonXMLFile_DisplaysAlert()
        {
            UploadFile("txtFile.txt");
            Assert.True(_webDriver.FindElement(By.Id(AlertNotXml)).Displayed);
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