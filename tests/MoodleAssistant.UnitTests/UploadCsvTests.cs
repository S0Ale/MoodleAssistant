using System;
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
            UploadCsvFile("txtFile.txt");
            Assert.Equal(UploadCsvPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadXML_NonCSVFile_DisplaysAlert()
        {
            UploadCsvFile("txtFile.txt");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.NonCsvFile.ToString())).Displayed);
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_EmptyCSV_ReturnToUpload()
        {
            UploadCsvFile("EmptyCsv.csv");
            Assert.Equal(UploadCsvPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_EmptyCSV_DisplaysAlert()
        {
            UploadCsvFile("EmptyCsv.csv");
            Assert.True(WebDriver.FindElement(By.ClassName(Error.EmptyFile.ToString())).Displayed);
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CSVWithoutHeader_ReturnToUpload()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CSVWithAnEmptyQuestionField_ReturnToUpload()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CSVWithAnEmptyAnswerField_ReturnToUpload()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CSVWithSemicolonSeparator_ReturnToUpload()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CorrectCSVFile_Ok()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void MoodleAssistant_UploadCSV_CorrectCSVFile_TakeFields()
        {
            throw new NotImplementedException();
        }
    }
}