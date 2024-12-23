using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Utils;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Components.Sections;
using MoodleAssistant.Components.Upload;
using MoodleAssistant.Services;

namespace MoodleAssistant.UnitTest;

internal class FileTest : FileUploadTest{
    
    private IRenderedComponent<Replicator> _page;
    private IRenderedComponent<FileParam> _fileSection;
    private InputFileContent correctXml = TestService.Create("MoodleOkWithImage.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
    private InputFileContent correctCsv = TestService.Create("MoodleOkWithImage.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
    private IElement _submitFile;
    
    [SetUp]
    public new void Setup(){
        base.Setup();
        _page = Ctx.Render<Replicator>();
        var inputs = _page.FindComponents<InputFile>();
        var xml = inputs[0];
        var csv = inputs[1];
        var submit = _page.Find("button[type=submit]");
        
        xml.UploadFiles(correctXml);
        csv.UploadFiles(correctCsv);
        submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);

        _fileSection = _page.FindComponent<FileParam>();
        _submitFile = _fileSection.Find("button[type=submit]");
    }

    [Test]
    public void UploadFiles_ShowsFileUploadForm(){
        var fileForm = _page.Find("form[id=param-upload]");
        Assert.Multiple(() => {
            Assert.That(_page.Instance.ShowFileParams, Is.True);
            Assert.That(fileForm, Is.Not.Null);
        });
    }

    [Test]
    public void UploadFiles_FileMismatchDuringMerge(){
        var input = _fileSection.FindComponent<DropFileInput>();
        var word1 = TestService.Create("Test1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word2 = TestService.Create("Test2.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        
        input.FindComponent<CustomLabel>().FindComponent<InputFile>().UploadFiles(word1, word2, word2);
        _submitFile.Click();
        _fileSection.WaitForState(() => _fileSection.Instance.IsUploading == false);
        
        Assert.That(_fileSection.Instance.Error, Is.EqualTo(Error.FileMismatch));
    }

    [Test]
    public void UploadFiles_InvalidFile(){
        var input = _fileSection.FindComponent<DropFileInput>();
        var word1 = TestService.Create("Test1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word2 = TestService.Create("Test2.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var text = TestService.Create("txtFile.txt", System.Net.Mime.MediaTypeNames.Text.Plain);
        
        input.FindComponent<CustomLabel>().FindComponent<InputFile>().UploadFiles(word1, word2, text);
        _submitFile.Click();
        _fileSection.WaitForState(() => _fileSection.Instance.IsUploading == false);
        
        Assert.That(_fileSection.Instance.Error, Is.EqualTo(Error.NoValidFile));
    }
    
    [Test]
    public void UploadFiles_EmptyFile(){
        var input = _fileSection.FindComponent<DropFileInput>();
        var word1 = TestService.Create("Test1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word2 = TestService.Create("Test2.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var empty = TestService.Create("EmptyXmlFile.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        
        input.FindComponent<CustomLabel>().FindComponent<InputFile>().UploadFiles(word1, word2, empty);
        _submitFile.Click();
        _fileSection.WaitForState(() => _fileSection.Instance.IsUploading == false);
        
        Assert.That(_fileSection.Instance.Error, Is.EqualTo(Error.EmptyFile));
    }

    [Test]
    public void UploadFiles_MissingFiles(){
        var input = _fileSection.FindComponent<DropFileInput>();
        var word1 = TestService.Create("Test1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        
        input.FindComponent<CustomLabel>().FindComponent<InputFile>().UploadFiles(word1);
        _submitFile.Click();
        _fileSection.WaitForState(() => _fileSection.Instance.IsUploading == false);
        
        Assert.That(_fileSection.Instance.Error, Is.EqualTo(Error.NoFiles));
    }

    [Test]
    public void UploadFiles_UploadCorrect(){
        var input = _fileSection.FindComponent<DropFileInput>();
        var word1 = TestService.Create("Test1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word2 = TestService.Create("Test2.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word3 = TestService.Create("Test3.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        
        input.FindComponent<CustomLabel>().FindComponent<InputFile>().UploadFiles(word1, word2, word3);
        _submitFile.Click();
        _fileSection.WaitForState(() => _fileSection.Instance.IsUploading == false);
        
        Assert.Multiple(() => {
            Assert.That(_fileSection.Instance.Error, Is.EqualTo(Error.NoErrors));
            Assert.That(_fileSection.Instance.SuccessUpload, Is.True);
        });
    }

    [TearDown]
    public new void TearDown(){
        var fs = Ctx.Services.GetService<FileService>();
        fs?.DeleteAllFiles();
        
        _submitFile = null!;
        _fileSection.Dispose();
        _page.Dispose();
        
        base.TearDown();
    }
}