using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.UnitTest;

[TestFixture]
internal class CsvTest : FileUploadTest{
    private IRenderedComponent<Replicator> Page;
    private IRenderedComponent<InputFile> Xml;
    private IRenderedComponent<InputFile> Csv;

    private InputFileContent correctXml = TestService.Create("MoodleQuestionOk.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
    private IElement Submit;
    
    [SetUp]
    public new void Setup(){
        base.Setup();
        Page = Ctx.Render<Replicator>();
        var inputs = Page.FindComponents<InputFile>();
        Xml = inputs[0];
        Csv = inputs[1];
        Submit = Page.Find("button[type=submit]");
    }

    [Test]
    public void UploadCSV_NonCSVFile(){
        var csv = TestService.Create("txtFile.txt", System.Net.Mime.MediaTypeNames.Text.Plain);
        Xml.UploadFiles(correctXml);
        Csv.UploadFiles(csv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.NonCsvFile));
    }

    [Test]
    public void UploadCSV_EmptyCSV(){
        var csv = TestService.Create("EmptyCsv.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        Xml.UploadFiles(correctXml);
        Csv.UploadFiles(csv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.EmptyFile));
    }

    [Test]
    public void UploadCSV_CSVWithoutHeader(){
        var csv = TestService.Create("CsvWithoutHeader.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        Xml.UploadFiles(correctXml);
        Csv.UploadFiles(csv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.CsvInvalidHeader));
    }

    [Test]
    public void UploadCSV_CSVBadFormed(){
        var csv = TestService.Create("CsvBadFormed.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        Xml.UploadFiles(correctXml);
        Csv.UploadFiles(csv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.CsvBadFormed));
    }

    [Test]
    public void UploadCSV_CSVWithSemicolonSeparator(){
        var csv = TestService.Create("CsvWithSemiColonSeparator.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        Xml.UploadFiles(correctXml);
        Csv.UploadFiles(csv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.CsvInvalidHeader));
    }

    [Test]
    public void UploadCSV_CorrectCSVFile(){
        var csv = TestService.Create("MoodleQuestionOk.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        Xml.UploadFiles(correctXml);
        Csv.UploadFiles(csv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.Multiple(() => {
            Assert.That(Page.Instance.Error, Is.EqualTo(Error.NoErrors));
            Assert.That(Page.Instance.SuccessUpload, Is.True);
        });
    }

    [TearDown]
    public new void TearDown(){
        var fs = Ctx.Services.GetService<FileService>();
        fs?.DeleteAllFiles();
        
        Submit = null!;
        Xml.Dispose();
        Csv.Dispose();
        Page.Dispose();
        
        base.TearDown();
    }
    
}