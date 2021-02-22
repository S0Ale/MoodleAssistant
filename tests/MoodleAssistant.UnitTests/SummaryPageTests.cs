using OpenQA.Selenium;
using Xunit;

namespace MoodleAssistant.UnitTests
{
    public class SummaryPageTests : TestsBase
    {
        private const string QuestionTextId = "questiontext";
        private const string AnswerTextId = "answerbox";
        private const string ReturnToUploadButtonId = "return-to-upload";
        private const string UploadCsvButtonId = "upload-csv";

        public SummaryPageTests() : base("Xml/Upload")
        {
        }

        [Theory]
        [InlineData("MoodleQuestionOk.xml")]
        [InlineData("MoodleQuestionOk_2Params.xml")]
        public void MoodleAssistant_SummaryPage_QuestionText_Displayed(string fileName)
        {
            UploadXmlFile(fileName);
            Assert.True(WebDriver.FindElement(By.Id(QuestionTextId)).Displayed);
        }

        [Theory]
        [InlineData("MoodleQuestionOk.xml", 1)]
        [InlineData("MoodleQuestionOk_2Params.xml", 2)]
        public void MoodleAssistant_SummaryPage_QuestionText_CountNumberOfParameters(string fileName, int numberOfParameters)
        {
            UploadXmlFile(fileName);
            Assert.Equal(numberOfParameters, WebDriver.FindElements(By.XPath("//*[@id='"+ QuestionTextId + "']/mark")).Count);
        }

        [Theory]
        [InlineData("MoodleQuestionOk.xml")]
        [InlineData("MoodleQuestionOk_2Params.xml")]
        public void MoodleAssistant_SummaryPage_AnswerBox_Displayed(string fileName)
        {
            UploadXmlFile(fileName);
            Assert.True(WebDriver.FindElement(By.Id(AnswerTextId)).Displayed);
        }

        [Theory]
        [InlineData("MoodleQuestionOk.xml", 1)]
        [InlineData("MoodleQuestionOk_2Params.xml", 2)]
        public void MoodleAssistant_SummaryPage_AnswerText_CountNumberOfParameters(string fileName, int numberOfParameters)
        {
            UploadXmlFile(fileName);
            Assert.Equal(numberOfParameters, WebDriver.FindElements(By.XPath("//*[@id='" + AnswerTextId + "']/p/mark")).Count);
        }

        [Fact]
        public void MoodleAssistant_SummaryPage_ReturnToUploadButton_Displayed()
        {
            UploadXmlFile("MoodleQuestionOk.xml");
            Assert.True(WebDriver.FindElement(By.Id(ReturnToUploadButtonId)).Displayed);
        }

        [Fact]
        public void MoodleAssistant_SummaryPage_ClickReturnToUploadButton_ReturnToUploadPage()
        {
            UploadXmlFile("MoodleQuestionOk.xml");
            WebDriver.FindElement(By.Id(ReturnToUploadButtonId)).Click();
            Assert.Equal(RandomQuestionPageTitle, WebDriver.Title);
        }

        [Fact]
        public void MoodleAssistant_SummaryPage_UploadCSVButton_Displayed()
        {
            UploadXmlFile("MoodleQuestionOk.xml");
            Assert.True(WebDriver.FindElement(By.Id(UploadCsvButtonId)).Displayed);
        }

        [Fact]
        public void MoodleAssistant_SummaryPage_ClickUploadCSVButton_GoToUploadCSVPage()
        {
            UploadXmlFile("MoodleQuestionOk.xml");
            WebDriver.FindElement(By.Id(UploadCsvButtonId)).Click();
            Assert.Equal(UploadCsvPageTitle, WebDriver.Title);
        }
    }
}
