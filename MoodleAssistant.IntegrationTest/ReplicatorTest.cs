using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace MoodleAssistant.IntegrationTest;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ReplicatorTest : PageTest{
    private const string Url = "https://localhost:7085/replicator";
 
    [TestCase("MoodleQuestionOk.xml", "MoodleQuestionOk.csv")]
    [TestCase("multichoice.xml", "multichoice.csv")]
    [TestCase("Multichoice1.xml", "Multichoice1.csv")]
    [TestCase("trueFalse.xml", "trueFalse.csv")]
    [TestCase("shortAnswer.xml", "shortAnswer.csv")]
    public async Task UploadFiles_BasicQuestion(string xmlName, string csvName){
        await Page.GotoAsync(Url);
        var xml = Page.GetByTestId("xml-input");
        var csv = Page.GetByTestId("csv-input");
        await Task.Delay(1000);
        
        await xml.SetInputFilesAsync(TestService.GetPath(xmlName));
        await csv.SetInputFilesAsync(TestService.GetPath(csvName));
        
        await Page.GetByTestId("main-submit").ClickAsync();
        await Expect(Page.GetByTestId("download")).ToBeVisibleAsync();
    }

    [Test]
    public async Task UploadFiles_QuestionWithImage(){
        await Page.GotoAsync(Url);
        var xml = Page.GetByTestId("xml-input");
        var csv = Page.GetByTestId("csv-input");
        await Task.Delay(1000);
        
        await xml.SetInputFilesAsync(TestService.GetPath("MoodleOkWithImage.xml"));
        await csv.SetInputFilesAsync(TestService.GetPath("MoodleOkWithImage.csv"));
        
        await Page.GetByTestId("main-submit").ClickAsync();
        await Task.Delay(2000);
        var fileSection = Page.GetByTestId("file-form");
        
        await Expect(fileSection).ToBeVisibleAsync();
        
        var inputs = await fileSection.GetByTestId("IMAGE-number-input").AllAsync();
        await Task.Delay(1000);
        
        // Set the files for the inputs (one input cannot have multiple files)
        var files = new[]{TestService.GetPath("Image1.png"), TestService.GetPath("Image2.png"), TestService.GetPath("Image3.png")};
        var i = 0;
        foreach (var input in inputs){
            await input.SetInputFilesAsync(files[i]);
            i++;
        }
            
        await Page.GetByTestId("snd-submit").ClickAsync();
        await Expect(Page.GetByTestId("download")).ToBeVisibleAsync();
    }

}