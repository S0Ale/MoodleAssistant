using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Components.Sections;
using MoodleAssistant.Components.Upload;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.UnitTest;

internal class FileTest : FileUploadTest{
    
    private IRenderedComponent<Replicator> _page;
    private IRenderedComponent<FileParam> _fileSection;
    private IElement _submitFile;
    
    [SetUp]
    public new void Setup(){
        base.Setup();
        _page = Ctx.Render<Replicator>();
        var inputs = _page.FindComponents<InputFile>();
        var xml = inputs[0];
        var csv = inputs[1];
        var submit = _page.Find("button[type=submit]");
        
        xml.UploadFiles(TestService.Create("MoodleOkWithFile.xml", System.Net.Mime.MediaTypeNames.Text.Xml));
        csv.UploadFiles(TestService.Create("MoodleOkWithFile.csv", System.Net.Mime.MediaTypeNames.Text.Csv));
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
    public void UploadFiles_UploadFileCorrect(){
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

    [Test]
    public void UploadFiles_UploadImageCorrect(){
        var inputs = _page.FindComponents<InputFile>();
        var xml = inputs[0];
        var csv = inputs[1];
        var submit = _page.Find("button[type=submit]");
        
        xml.UploadFiles(TestService.Create("MoodleOkWithImage.xml", System.Net.Mime.MediaTypeNames.Text.Xml));
        csv.UploadFiles(TestService.Create("MoodleOkWithImage.csv", System.Net.Mime.MediaTypeNames.Text.Csv));
        submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);

        _fileSection = _page.FindComponent<FileParam>();
        _submitFile = _fileSection.Find("button[type=submit]");
        
        
        var input = _fileSection.FindComponent<DropFileInput>();
        var img1 = TestService.Create("Image1.png", System.Net.Mime.MediaTypeNames.Image.Png);
        var img2 = TestService.Create("Image2.png", System.Net.Mime.MediaTypeNames.Image.Png);
        var img3 = TestService.Create("Image3.png", System.Net.Mime.MediaTypeNames.Image.Png);
        
        input.FindComponent<CustomLabel>().FindComponent<InputFile>().UploadFiles(img1, img2, img3);
        _submitFile.Click();
        _fileSection.WaitForState(() => _fileSection.Instance.IsUploading == false);
        
        Assert.Multiple(() => {
            Assert.That(_fileSection.Instance.Error, Is.EqualTo(Error.NoErrors));
            Assert.That(_fileSection.Instance.SuccessUpload, Is.True);
        });
    }
    
    [Test]
    public void UploadFiles_UploadImageWithNoCdataCorrect(){
        var inputs = _page.FindComponents<InputFile>();
        var xml = inputs[0];
        var csv = inputs[1];
        var submit = _page.Find("button[type=submit]");
        
        xml.UploadFiles(TestService.Create("MoodleFileOkWithNoCdata.xml", System.Net.Mime.MediaTypeNames.Text.Xml));
        csv.UploadFiles(TestService.Create("MoodleFileOkWithNoCdata.csv", System.Net.Mime.MediaTypeNames.Text.Csv));
        submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);

        _fileSection = _page.FindComponent<FileParam>();
        _submitFile = _fileSection.Find("button[type=submit]");
        
        var input = _fileSection.FindComponent<DropFileInput>();
        var word1 = TestService.Create("Test1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word2 = TestService.Create("Test2.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word3 = TestService.Create("Test3.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        
        input.FindComponent<CustomLabel>().FindComponent<InputFile>().UploadFiles(word1, word2, word3);
        _submitFile.Click();
        _fileSection.WaitForState(() => _fileSection.Instance.IsUploading == false);
        
        var state = Ctx.Services.GetService<ReplicatorState>();
        
        Assert.Multiple(() => {
            Assert.That(_fileSection.Instance.Error, Is.EqualTo(Error.NoErrors));
            Assert.That(_fileSection.Instance.SuccessUpload, Is.True);
            Assert.That(state?.Merged, Is.Not.Null);
            Assert.That(state?.Merged?.InnerXml, Does.Contain("<![CDATA["));
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