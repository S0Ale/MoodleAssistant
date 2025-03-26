using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Components;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.Test;

internal class UploadAikenFileShould : FileUploadTest{
    private IRenderedComponent<Replicator> _page;
    private IRenderedComponent<InputFile> _xml;
    private IRenderedComponent<InputFile> _csv;
    private IElement _submit;
    private readonly InputFileContent _mockCsv = InputFileContent.CreateFromText("", "Useless.csv", null,System.Net.Mime.MediaTypeNames.Text.Csv);
    
    [SetUp]
    public new void Setup(){
        base.Setup();
        _page = Ctx.Render<Replicator>();
        var inputs = _page.FindComponents<InputFile>();
        _xml = inputs[0];
        _csv = inputs[1];
        _submit = _page.Find("button[type=submit]");
        
        var select = _page.FindComponent<FormatSelect>();
        var selectElement = select.Find("select");
        selectElement.Change("Aiken");
    }
    
    [Test]
    public void Throw_NonAikenFile(){
        var template = TestService.Create("trueFalse.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        _xml.UploadFiles(template);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.NonAikenFile));
    }
    
    [Test]
    public void Throw_EmptyAiken(){
        var template = TestService.Create("EmptyAiken.txt", System.Net.Mime.MediaTypeNames.Text.Plain);
        _xml.UploadFiles(template);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.EmptyFile));
    }

    [Test]
    [TestCase("InvalidOption.txt")]
    public void Throw_AikenBadFormed(string name){
        var template = TestService.Create(name, System.Net.Mime.MediaTypeNames.Text.Plain);
        _xml.UploadFiles(template);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.TemplateBadFormed));
    }
    
    [Test]
    public void Throw_AikenMoreThanOneQuestion(){
        var template = TestService.Create("AikenMoreQuestions.txt", System.Net.Mime.MediaTypeNames.Text.Plain);
        _xml.UploadFiles(template);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.ZeroOrMoreQuestions));
    }
    
    [Test]
    public void Throw_AikenWithFileParams(){
        var template = TestService.Create("AikenWithFileParams.txt", System.Net.Mime.MediaTypeNames.Text.Plain);
        _xml.UploadFiles(template);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.AikenWithFile));
    }
    
    [Test]
    [TestCase("AikenOk.txt", "CsvOkWithAiken.csv")]
    [TestCase("AikenOk2.txt", "CsvOkWithAiken2.csv")]
    public void Success_BasicAiken(string aiken, string csvName){
        var template = TestService.Create(aiken, System.Net.Mime.MediaTypeNames.Text.Plain);
        var csv = TestService.Create(csvName, System.Net.Mime.MediaTypeNames.Text.Csv);
        _xml.UploadFiles(template);
        _csv.UploadFiles(csv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.Multiple(() => {
            Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.NoErrors));
            Assert.That(_page.Instance.SuccessUpload, Is.True);
        });
    }

    [TearDown]
    public new void TearDown(){
        var fs = Ctx.Services.GetService<FileService>();
        fs?.DeleteAllFiles();
        
        _submit = null!;
        _xml.Dispose();
        _csv.Dispose();
        _page.Dispose();
        
        base.TearDown();
    }
}