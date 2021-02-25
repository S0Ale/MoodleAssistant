using System;
using System.Threading;
using MoodleAssistant.Controllers;
using MoodleAssistant.Utils;
using OpenQA.Selenium;
using Xunit;

namespace MoodleAssistant.UnitTests
{
    public class UploadCsvTests : TestsBase
    {
        public UploadCsvTests() : base("Csv/Upload")
        {
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_NonCSVFile_ReturnToUpload()
        {
            UploadCorrectXMlFile();
            UploadCsvFile("txtFile.txt");
            Assert.Equal(UploadCsvPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_NonCSVFile_DisplaysAlert()
        {
            UploadCorrectXMlFile();
            UploadCsvFile("txtFile.txt");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.NonCsvFile.ToString())).Displayed);
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_EmptyCSV_ReturnToUpload()
        {
            UploadCorrectXMlFile();
            UploadCsvFile("EmptyCsv.csv");
            Assert.Equal(UploadCsvPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_EmptyCSV_DisplaysAlert()
        {
            UploadCorrectXMlFile();
            UploadCsvFile("EmptyCsv.csv");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.EmptyFile.ToString())).Displayed);
        }


        [Fact]
        public void MoodleAssistant_UploadCSV_CSVWithoutHeader_ReturnToUpload()
        {
            UploadCorrectXMlFile();
            UploadCsvFile("CsvWithoutHeader.csv");
            Assert.Equal(UploadCsvPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CSVWithoutHeader_DisplaysAlert()
        {
            UploadCorrectXMlFile();
            UploadCsvFile("CsvWithoutHeader.csv");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.CsvInvalidHeader.ToString())).Displayed);
        }

        [Theory]
        [InlineData("CsvWithMissingQuestion.csv")]
        [InlineData("CsvWithMissingAnswer.csv")]
        [InlineData("CsvBadFormed.csv")]
        public void MoodleAssistant_UploadCSV_CSVBadFormed_ReturnToUpload(string filename)
        {
            UploadCorrectXMlFile();
            UploadCsvFile(filename);
            Assert.Equal(UploadCsvPageTitle, WebDriver.Title);
        }

        [Theory]
        [InlineData("CsvWithMissingQuestion.csv")]
        [InlineData("CsvWithMissingAnswer.csv")]
        [InlineData("CsvBadFormed.csv")]
        public void MoodleAssistant_UploadCSV_CSVBadFormed_DisplaysAlert(string filename)
        {
            UploadCorrectXMlFile();
            UploadCsvFile(filename);
            Assert.True(WebDriver.FindElement(By.ClassName(Error.CsvBadFormed.ToString())).Displayed);
            
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CSVWithSemicolonSeparator_ReturnToUpload()
        {
            UploadCorrectXMlFile();
            UploadCsvFile("CsvWithSemiColonSeparator.csv");
            Assert.Equal(UploadCsvPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CSVWithSemicolonSeparator_DisplaysAlert()
        {
            UploadCorrectXMlFile();
            UploadCsvFile("CsvWithSemiColonSeparator.csv");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.CsvInvalidHeader.ToString())).Displayed);
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CorrectCSVFile_Ok()
        {
            throw new NotImplementedException();
        }

        private void UploadCorrectXMlFile()
        {
            WebDriver.Url = SiteUrl + "Xml/Upload";
            UploadXmlFile("MoodleQuestionOk.xml");
            WebDriver.FindElement(By.Id("upload-csv")).Click();
        }
    }
}