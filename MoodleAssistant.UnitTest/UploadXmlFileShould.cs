using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.UnitTest;

[TestFixture]
internal class UploadXmlFileShould : FileUploadTest{

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
    }

    [Test]
    public void Throw_NonXMLFile(){
        var xml = TestService.Create("txtFile.txt", System.Net.Mime.MediaTypeNames.Text.Plain);
        _xml.UploadFiles(xml);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.Error, Is.EqualTo(Error.NonXmlFile));
    }

    [Test]
    public void Throw_EmptyXML(){
        var xml = TestService.Create("EmptyXmlFile.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        _xml.UploadFiles(xml);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.Error, Is.EqualTo(Error.EmptyFile));
    }

    [Test]
    [TestCase("XmlBadFormed.xml")]
    [TestCase("XmlBadFormed-1.xml")]
    [TestCase("XmlBadFormed-2.xml")]
    public void Throw_XmlBadFormed(string name){
        var xml = TestService.Create(name, System.Net.Mime.MediaTypeNames.Text.Xml);
        _xml.UploadFiles(xml);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.Error, Is.EqualTo(Error.XmlBadFormed));
    }

    [Test]
    public void Throw_XMLWithoutQuestions(){
        var xml = TestService.Create("MoodleXMLWithoutQuestions.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        _xml.UploadFiles(xml);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.Error, Is.EqualTo(Error.ZeroOrMoreQuestions));
    }

    [Test]
    public void Throw_XMLWithMoreThanOneQuestion(){
        var xml = TestService.Create("MoodleXMLWithMoreThanOneQuestion.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        _xml.UploadFiles(xml);
        _csv.UploadFiles(_mockCsv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.That(_page.Instance.Error, Is.EqualTo(Error.ZeroOrMoreQuestions));
    }

    [Test]
    public void Success_BasicXml(){
        var xml = TestService.Create("MoodleQuestionOk.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        var csv = TestService.Create("MoodleQuestionOk.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        _xml.UploadFiles(xml);
        _csv.UploadFiles(csv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.Multiple(() => {
            Assert.That(_page.Instance.Error, Is.EqualTo(Error.NoErrors));
            Assert.That(_page.Instance.SuccessUpload, Is.True);
        });
    }

    [Test]
    public void Success_XmlWithFile(){
        var xml = TestService.Create("MoodleOkWithImage.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        var csv = TestService.Create("MoodleOkWithImage.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        _xml.UploadFiles(xml);
        _csv.UploadFiles(csv);
        
        _submit.Click();
        _page.WaitForState(() => _page.Instance.IsUploading == false);
        Assert.Multiple(() => {
            Assert.That(_page.Instance.Error, Is.EqualTo(Error.NoErrors));
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