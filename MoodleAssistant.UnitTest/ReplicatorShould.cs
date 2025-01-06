using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Components.Sections;
using MoodleAssistant.Components.Upload;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.UnitTest;

internal class ReplicatorShould : FileUploadTest{
    
    private IRenderedComponent<Replicator> _page;

    [SetUp]
    public new void Setup(){
        base.Setup();
        _page = Ctx.Render<Replicator>();
    }

    [Test]
    public void Success_ClearForm(){
        var inputs = _page.FindComponents<InputFile>();
        inputs[0].UploadFiles(TestService.Create("MoodleOkWithFile.xml", System.Net.Mime.MediaTypeNames.Text.Xml));
        inputs[1].UploadFiles(TestService.Create("MoodleOkWithFile.csv", System.Net.Mime.MediaTypeNames.Text.Csv));
        
        var customInputs = _page.FindComponents<DropInput>();
        
        _page.Find("button[id=clear-files]").Click();
        Assert.Multiple(() => {
            Assert.That(customInputs[0].Instance.UploadedFiles, Has.Count.EqualTo(0));
            Assert.That(customInputs[1].Instance.UploadedFiles, Has.Count.EqualTo(0));
        });
    }

    [Test]
    public void Success_ShowFileUploadForm(){
        var inputs = _page.FindComponents<InputFile>();
        inputs[0].UploadFiles(TestService.Create("MoodleOkWithFile.xml", System.Net.Mime.MediaTypeNames.Text.Xml));
        inputs[1].UploadFiles(TestService.Create("MoodleOkWithFile.csv", System.Net.Mime.MediaTypeNames.Text.Csv));
        _page.Find("button[type=submit]").Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        
        var fileForm = _page.Find("form[id=param-upload]");
        Assert.Multiple(() => {
            Assert.That(_page.Instance.ShowFileParams, Is.True);
            Assert.That(fileForm, Is.Not.Null);
        });
    }

    [Test]
    public void Success_ShowAnalysis(){
        var inputs = _page.FindComponents<InputFile>();
        inputs[0].UploadFiles(TestService.Create("MoodleQuestionOk.xml", System.Net.Mime.MediaTypeNames.Text.Xml));
        inputs[1].UploadFiles(TestService.Create("MoodleQuestionOk.csv", System.Net.Mime.MediaTypeNames.Text.Csv));
        _page.Find("button[type=submit]").Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);

        var analysis = _page.FindComponents<Analysis>();
        Assert.Multiple(() => {
            Assert.That(_page.Instance.SuccessUpload, Is.True);
            Assert.That(analysis, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void Success_ShowPreview(){
        var inputs = _page.FindComponents<InputFile>();
        inputs[0].UploadFiles(TestService.Create("MoodleQuestionOk.xml", System.Net.Mime.MediaTypeNames.Text.Xml));
        inputs[1].UploadFiles(TestService.Create("MoodleQuestionOk.csv", System.Net.Mime.MediaTypeNames.Text.Csv));
        _page.Find("button[type=submit]").Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        
        var preview = _page.FindComponents<Preview>();
        Assert.Multiple(() => {
            Assert.That(_page.Instance.SuccessUpload, Is.True);
            Assert.That(preview, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void Success_MergedIsNotNull(){
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