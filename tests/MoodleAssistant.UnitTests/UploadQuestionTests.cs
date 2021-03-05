using System;
using MoodleAssistant.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace MoodleAssistant.UnitTests
{
    public class UploadQuestionTests : TestsBase
    {
        public UploadQuestionTests() : base("Xml/Upload")
        {
        }

        [Fact]
        public void MoodleAssistant_UploadXML_NonXMLFile_ReturnToUpload()
        {
            UploadXmlFile("txtFile.txt");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_NonXMLFile_DisplaysAlert()
        {
            UploadXmlFile("txtFile.txt");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.NonXmlFile.ToString())).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadXML_EmptyXML_ReturnToUpload()
        {
            UploadXmlFile("EmptyXmlFile.xml");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_EmptyXML_DisplaysAlert()
        {
            UploadXmlFile("EmptyXmlFile.xml");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.EmptyFile.ToString())).Displayed);
        }

        [Theory]
        [InlineData("MalFormatted.xml")]
        [InlineData("MalFormatted-1.xml")]
        [InlineData("MalFormatted-2.xml")]
        public void MoodleAssistant_UploadXML_MalFormattedXml_ReturnToUpload(string fileName)
        {
            UploadXmlFile(fileName);
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Theory]
        [InlineData("MalFormatted.xml")]
        [InlineData("MalFormatted-1.xml")]
        [InlineData("MalFormatted-2.xml")]
        public void MoodleAssistant_UploadXML_MalFormattedXml_DisplaysAlert(string fileName)
        {
            UploadXmlFile(fileName);
            Assert.True(WebDriver.FindElement(By.ClassName(Error.MalFormatted.ToString())).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutQuestions_ReturnToUpload()
        {
            UploadXmlFile("MoodleXMLWithoutQuestions.xml");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutQuestions_DisplaysAlert()
        {
            UploadXmlFile("MoodleXMLWithoutQuestions.xml");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.ZeroOrMoreQuestions.ToString())).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithMoreThanOneQuestion_DisplaysAlert()
        {
            UploadXmlFile("MoodleXMLWithMoreThanOneQuestion.xml");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.ZeroOrMoreQuestions.ToString())).Displayed);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithMoreThanOneQuestion_ReturnToUpload()
        {
            UploadXmlFile("MoodleXMLWithMoreThanOneQuestion.xml");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutAnswer_ReturnToUpload()
        {
            UploadXmlFile("MoodleQuestionWithoutAnswer.xml");
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithoutAnswer_DisplaysAlert()
        {
            UploadXmlFile("MoodleQuestionWithoutAnswer.xml");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.ZeroAnswers.ToString())).Displayed);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_XMLWithRandomizableParametersButNotInAnswer_Ok()
        {
            UploadXmlFile("MoodleQuestionWithParametersInQuestionButNotInAnswer.xml");
            Assert.Equal(SummaryPagePageTitle, WebDriver.Title);
        }

        [Theory]
        [InlineData("MoodleQuestionOk.xml")]
        [InlineData("MoodleQuestionOk_2Params.xml")]
        public void MoodleAssistant_UploadXML_CorrectXMLFile_Ok(string filename)
        {
            UploadXmlFile(filename);
            Assert.Equal(SummaryPagePageTitle, WebDriver.Title);
        }

    }
}