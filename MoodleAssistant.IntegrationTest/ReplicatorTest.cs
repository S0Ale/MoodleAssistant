using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using MoodleAssistant.UnitTest;
using NUnit.Framework;

namespace MoodleAssistant.IntegrationTest;

[TestFixture]
public class ReplicatorTest : PageTest{
    
    private string _url = "https://localhost:7085/replicator";
    //private string _main

    [TestCase("MoodleQuestionOk.xml", "MoodleQuestionOk.csv")]
    [TestCase("multichoice.xml", "multichoice.csv")]
    [TestCase("Multichoice1.xml", "Multichoice1.csv")][Ignore("Multiple parameter occurrences are not supported")]
    [TestCase("trueFalse.xml", "trueFalse.csv")]
    public async Task UploadFiles_BasicQuestion(string xmlName, string csvName){
        await Page.GotoAsync(_url);
        var xml = Page.GetByTestId("xml-input");
        var csv = Page.GetByTestId("csv-input");
        
        await xml.SetInputFilesAsync(TestService.GetPath(xmlName));
        await csv.SetInputFilesAsync(TestService.GetPath(csvName));
        
        await Page.GetByTestId("main-submit").ClickAsync();
        // Wait for the download button to appear, with a 10-second timeout
        await TestService.Screenshot(Page, $"upload-{Path.GetFileNameWithoutExtension(xmlName)}", 0);
        /*
        try{
            downloadBtn = await Page.WaitForSelectorAsync("[data-testid=download]",
                new PageWaitForSelectorOptions{ Timeout = 10000 });
        }catch{
            await TestService.Screenshot(Page, $"error-{Path.GetFileNameWithoutExtension(xmlName)}");
            Assert.Fail("Download button did not appear");
        }
        */

        await TestService.Screenshot(Page, $"success-{Path.GetFileNameWithoutExtension(xmlName)}", 0);
        await Expect(Page.GetByTestId("download")).ToBeVisibleAsync(new(){Timeout = 10000});
    }

    [Test][Ignore("This test is not working")]
    public async Task UploadFiles_QuestionWithImage(){
        var xml = Page.GetByTestId("xml-input");
        var csv = Page.GetByTestId("csv-input");
        
        await xml.SetInputFilesAsync(TestService.GetPath("MoodleOkWithImage.xml"));
        await csv.SetInputFilesAsync(TestService.GetPath("MoodleOkWithImage.csv"));
        
        await Page.GetByTestId("main-submit").ClickAsync();
    }

    [Test]
    public async Task Screen_Test(){
        await Page.GotoAsync(_url);
        var xml = Page.GetByTestId("xml-input");
        var csv = Page.GetByTestId("csv-input");

        await TestService.Screenshot(Page, "start-file-upload", 0);
        
        await xml.SetInputFilesAsync(TestService.GetPath("MoodleQuestionOk.xml"));
        await csv.SetInputFilesAsync(TestService.GetPath("MoodleQuestionOk.csv"));
        
        await TestService.Screenshot(Page, "after-file-upload", 0);

        Assert.Pass();
    }

}