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
    //private const string _screenDir = @"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant.IntegrationTest\screenshots";
    
    [SetUp]
    public async Task Setup(){
        await Page.GotoAsync(_url);
    }

    [Test]
    public async Task UploadFiles_BasicFiles(){
        var xml = Page.GetByTestId("xml-input");
        var csv = Page.GetByTestId("csv-input");
        
        await xml.SetInputFilesAsync(TestService.GetPath("MoodleQuestionOk.xml"));
        await csv.SetInputFilesAsync(TestService.GetPath("MoodleQuestionOk.csv"));
        
        await Page.GetByTestId("main-submit").ClickAsync();
        // Wait for the download button to appear, with a 10-second timeout
        IElementHandle? downloadBtn = null;
        try{
            downloadBtn = await Page.WaitForSelectorAsync("[data-testid=download]",
                new PageWaitForSelectorOptions{ Timeout = 10000 });
        }catch{
            Assert.Fail("Download button did not appear");
        }

        Assert.That(await downloadBtn.IsVisibleAsync(), Is.True);
    }
    
    [Test]
    
}