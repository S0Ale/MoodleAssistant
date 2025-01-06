using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.UnitTest;

[TestFixture]
internal class UploadCsvFileShould : FileUploadTest{
    private IRenderedComponent<Replicator> _page;
    private IRenderedComponent<InputFile> _xml;
    private IRenderedComponent<InputFile> _csv;

    private readonly InputFileContent _correctXml = TestService.Create("MoodleQuestionOk.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
    private IElement _submit;
    
    [SetUp]
    public new void Setup(){
        base.Setup();
        _page = Ctx.Render<Replicator>();
        var inputs = _page.FindComponents<InputFile>();
        _xml = inputs[0];
        _csv = inputs[1];
        _submit = _page.Find("button[type=submit]");
    }

    [Test]
    public void Throw_NonCSVFile(){
        var csv = TestService.Create("txtFile.txt", System.Net.Mime.MediaTypeNames.Text.Plain);
        _xml.UploadFiles(_correctXml);
        _csv.UploadFiles(csv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.NonCsvFile));
    }

    [Test]
    public void Throw_EmptyCSV(){
        var csv = TestService.Create("EmptyCsv.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        _xml.UploadFiles(_correctXml);
        _csv.UploadFiles(csv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.EmptyFile));
    }

    [Test]
    public void Throw_CSVWithoutHeader(){
        var csv = TestService.Create("CsvWithoutHeader.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        _xml.UploadFiles(_correctXml);
        _csv.UploadFiles(csv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.CsvInvalidHeader));
    }

    [Test]
    public void Throw_CSVBadFormed(){
        var csv = TestService.Create("CsvBadFormed.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        _xml.UploadFiles(_correctXml);
        _csv.UploadFiles(csv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.CsvBadFormed));
    }

    [Test]
    public void Throw_CSVWithSemicolonSeparator(){
        var csv = TestService.Create("CsvWithSemiColonSeparator.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        _xml.UploadFiles(_correctXml);
        _csv.UploadFiles(csv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.ErrorMsg, Is.EqualTo(Error.CsvInvalidHeader));
    }

    [Test]
    public void Success_CorrectCSVFile(){
        var csv = TestService.Create("MoodleQuestionOk.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        _xml.UploadFiles(_correctXml);
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