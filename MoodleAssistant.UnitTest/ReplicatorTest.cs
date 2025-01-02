using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Utils;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Services;

namespace MoodleAssistant.UnitTest;

internal class ReplicatorTest : FileUploadTest{

    [SetUp]
    public new void Setup(){ }

    [Test]
    public void Upload_MergedIsNotNull(){
        var page = Ctx.Render<Replicator>();
        var inputs = page.FindComponents<InputFile>();
        inputs[0].UploadFiles(TestService.Create("MoodleQuestionOk.xml", System.Net.Mime.MediaTypeNames.Text.Xml));
        inputs[1].UploadFiles(TestService.Create("MoodleQuestionOk.csv", System.Net.Mime.MediaTypeNames.Text.Csv));
        page.Find("button[type=submit]").Click();
        page.WaitForState(() => page.Instance.IsUploading == false);
        
        var state = Ctx.Services.GetService<ReplicatorState>();
        
        Assert.Multiple(() => {
            Assert.That(page.Instance.Error, Is.EqualTo(Error.NoErrors));
            Assert.That(page.Instance.SuccessUpload, Is.True);
            Assert.That(state?.Merged, Is.Not.Null);
        });
    }

    [TearDown]
    public new void TearDown(){ }

}