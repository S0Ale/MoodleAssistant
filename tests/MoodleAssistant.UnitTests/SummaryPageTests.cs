using System;
using System.Collections.Generic;
using System.Text;
using MoodleAssistant.Utils;
using OpenQA.Selenium;
using Xunit;

namespace MoodleAssistant.UnitTests
{
    public class SummaryPageTests : TestsBase
    {
        [Theory]
        [InlineData("MoodleQuestionOk.xml")]
        public void MoodleAssistant_SummaryPage_QuestionText_Displayed(string fileName)
        {
            UploadFile(fileName);
            Assert.True(WebDriver.FindElement(By.Id("questiontext")).Displayed);
        }
    }
}
