using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Utils;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Services;

namespace MoodleAssistant.UnitTest;

internal class ReplicatorTest : FileUploadTest{
    
    private IRenderedComponent<Replicator> _page;

    [SetUp]
    public new void Setup(){
        base.Setup();
        _page = Ctx.Render<Replicator>();
    }

    [Test]
    public void Upload_MergedIsNotNull(){
        var inputs = _page.FindComponents<InputFile>();
        inputs[0].UploadFiles(TestService.Create("MoodleQuestionOk.xml", System.Net.Mime.MediaTypeNames.Text.Xml));
        inputs[1].UploadFiles(TestService.Create("MoodleQuestionOk.csv", System.Net.Mime.MediaTypeNames.Text.Csv));
        _page.Find("button[type=submit]").Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        
        var state = Ctx.Services.GetService<ReplicatorState>();
        
        Assert.Multiple(() => {
            Assert.That(_page.Instance.Error, Is.EqualTo(Error.NoErrors));
            Assert.That(_page.Instance.SuccessUpload, Is.True);
            Assert.That(state?.Merged, Is.Not.Null);
        });
    }

    [TearDown]
    public new void TearDown(){
        _page.Dispose();
    }

}