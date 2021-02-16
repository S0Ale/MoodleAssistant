using System;
using MoodleAssistant.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace MoodleAssistant.UnitTests
{
    public abstract class TestsBase : IDisposable
    {
        protected readonly IWebDriver WebDriver;
        protected const string SiteUrl = "https://localhost:44379/Home/RandomQuestions";
        
        protected TestsBase()
        {
            WebDriver = new ChromeDriver { Url = SiteUrl };
        }

        public void Dispose()
        {
            WebDriver.Close();
            WebDriver.Dispose();
        }
    }

    public class UploadQuestionTests : TestsBase
    {
       
        private const string AssetsDir = @"C:\Users\andre\source\repos\MoodleAssistant\tests\assets\xmlFiles\";
        private const string RandomQuestionPageTitle = "Random Questions - MoodleAssistant";
        private const string SummaryPagePageTitle = "Summary Page - MoodleAssistant";
        private const string UploadXmlButtonId = "upload-xml-question";
        private const string AlertError = "alert-error-xml";


        [Fact]
        public void MoodleAssistant_UploadXML_NonXMLFile_ReturnToUpload()
        {
            UploadFile("txtFile.txt");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_NonXMLFile_DisplaysAlert()
        {
            UploadFile("txtFile.txt");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.NonXmlFile.ToString())).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadXML_EmptyXML_ReturnToUpload()
        {
            UploadFile("EmptyXmlFile.xml");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_EmptyXML_DisplaysAlert()
        {
            UploadFile("EmptyXmlFile.xml");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.EmptyFile.ToString())).Displayed);
        }

        [Theory]
        [InlineData("MalFormatted.xml")]
        [InlineData("MalFormatted-1.xml")]
        [InlineData("MalFormatted-2.xml")]
        public void MoodleAssistant_UploadXML_MalFormattedXml_ReturnToUpload(string fileName)
        {
            UploadFile(fileName);
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Theory]
        [InlineData("MalFormatted.xml")]
        [InlineData("MalFormatted-1.xml")]
        [InlineData("MalFormatted-2.xml")]
        public void MoodleAssistant_UploadXML_MalFormattedXml_DisplaysAlert(string fileName)
        {
            UploadFile(fileName);
            Assert.True(WebDriver.FindElement(By.ClassName(Error.MalFormatted.ToString())).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutQuestions_ReturnToUpload()
        {
            UploadFile("MoodleXMLWithoutQuestions.xml");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutQuestions_DisplaysAlert()
        {
            UploadFile("MoodleXMLWithoutQuestions.xml");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.ZeroOrMoreQuestions.ToString())).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithMoreThanOneQuestion_DisplaysAlert()
        {
            UploadFile("MoodleXMLWithMoreThanOneQuestion.xml");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.ZeroOrMoreQuestions.ToString())).Displayed);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithMoreThanOneQuestion_ReturnToUpload()
        {
            UploadFile("MoodleXMLWithMoreThanOneQuestion.xml");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutRandomizableParameters_ReturnToUpload()
        {
            UploadFile("MoodleQuestionWithoutParameters.xml");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutRandomizableParameters_DisplaysAlert()
        {
            UploadFile("MoodleQuestionWithoutParameters.xml");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.NoParameters.ToString())).Displayed);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutAnswer_ReturnToUpload()
        {
            UploadFile("MoodleQuestionWithoutAnswer.xml");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutAnswer_DisplaysAlert()
        {
            UploadFile("MoodleQuestionWithoutAnswer.xml");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.ZeroAnswers.ToString())).Displayed);
        }

        /*[Fact]
        public void MoodleAssistant_UploadXML_XMLWithRandomizableParametersButNotInAnswer_ReturnToUpload()
        {
            UploadFile("MoodleQuestionWithParametersInQuestionButNotInAnswer.xml");
            Assert.Equal(RandomQuestionPageTitle, _webDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithRandomizableParametersButNotInAnswer_DisplaysAlert()
        {
            UploadFile("MoodleQuestionWithParametersInQuestionButNotInAnswer.xml");
            Assert.True(_webDriver.FindElement(By.Id(AlertError)).Displayed);
        }*/


        [Fact]
        public void MoodleAssistant_UploadXML_CorrectXMLFile_Ok()
        {
            UploadFile("MoodleQuestionOk.xml");
            Assert.Equal(SummaryPagePageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_CorrectXMLFile_TakeParameters()
        {
            throw new NotImplementedException();
        }
        
        private void UploadFile(string fileName)
        {
            var element = WebDriver.FindElement(By.Id(UploadXmlButtonId));
            element.SendKeys(AssetsDir + fileName);
        }
    }
}