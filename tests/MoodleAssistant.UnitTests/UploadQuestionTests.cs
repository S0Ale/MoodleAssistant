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
            UploadFile("EmptyXmlFile.xml");
            Assert.Equal(RandomQuestionPageTitle, _webDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_EmptyXML_DisplaysAlert()
        {
            UploadFile("EmptyXmlFile.xml");
            Assert.True(_webDriver.FindElement(By.Id(AlertError)).Displayed);
        }

        [Theory]
        [InlineData("MalFormatted.xml")]
        [InlineData("MalFormatted-1.xml")]
        [InlineData("MalFormatted-2.xml")]
        public void MoodleAssistant_UploadXML_MalFormattedXml_ReturnToUpload(string fileName)
        {
            UploadFile(fileName);
            Assert.Equal(RandomQuestionPageTitle, _webDriver.Title);
        }

        [Theory]
        [InlineData("MalFormatted.xml")]
        [InlineData("MalFormatted-1.xml")]
        [InlineData("MalFormatted-2.xml")]
        public void MoodleAssistant_UploadXML_MalFormattedXml_DisplaysAlert(string fileName)
        {
            UploadFile(fileName);
            Assert.True(_webDriver.FindElement(By.Id(AlertError)).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadXML_NonMoodleXMLFormat_ReturnToUpload()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutQuestions_ReturnToUpload()
        {
            UploadFile("MoodleXMLWithoutQuestions.xml");
            Assert.Equal(RandomQuestionPageTitle, _webDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutQuestions_DisplaysAlert()
        {
            UploadFile("MoodleXMLWithoutQuestions.xml");
            Assert.True(_webDriver.FindElement(By.Id(AlertError)).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithMoreThanOneQuestion_DisplaysAlert()
        {
            UploadFile("MoodleXMLWithMoreThanOneQuestion.xml");
            Assert.True(_webDriver.FindElement(By.Id(AlertError)).Displayed);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithMoreThanOneQuestion_ReturnToUpload()
        {
            UploadFile("MoodleXMLWithMoreThanOneQuestion.xml");
            Assert.Equal(RandomQuestionPageTitle, _webDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutRandomizableParameters_ReturnToUpload()
        {
            UploadFile("MoodleQuestionWithoutParameters.xml");
            Assert.Equal(RandomQuestionPageTitle, _webDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutRandomizableParameters_DisplaysAlert()
        {
            UploadFile("MoodleQuestionWithoutParameters.xml");
            Assert.True(_webDriver.FindElement(By.Id(AlertError)).Displayed);
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