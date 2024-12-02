using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Utils;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Services;

namespace MoodleAssistant.UnitTest;

public class XmlTest : FileUploadTest{

    private IRenderedComponent<Replicator> Page;
    private IRenderedComponent<InputFile> Xml;
    private IRenderedComponent<InputFile> Csv;
    private IElement Submit;
    private InputFileContent mockCsv = InputFileContent.CreateFromText("", "Useless.csv", null,System.Net.Mime.MediaTypeNames.Text.Csv);
    
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
    public void UploadXML_NonXMLFile(){
        var xml = TestService.Create("txtFile.txt", System.Net.Mime.MediaTypeNames.Text.Plain);
        Xml.UploadFiles(xml);
        Csv.UploadFiles(mockCsv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.NonXmlFile));
    }

    [Test]
    public void UploadXML_EmptyXML(){
        var xml = TestService.Create("EmptyXmlFile.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        Xml.UploadFiles(xml);
        Csv.UploadFiles(mockCsv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.EmptyFile));
    }

    [Test]
    [TestCase("XmlBadFormed.xml")]
    [TestCase("XmlBadFormed-1.xml")]
    [TestCase("XmlBadFormed-2.xml")]
    public void UploadXML_XmlBadFormed(string name){
        var xml = TestService.Create(name, System.Net.Mime.MediaTypeNames.Text.Xml);
        Xml.UploadFiles(xml);
        Csv.UploadFiles(mockCsv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.XmlBadFormed));
    }

    [Test]
    public void UploadXML_XMLWithoutQuestions(){
        var xml = TestService.Create("MoodleXMLWithoutQuestions.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        Xml.UploadFiles(xml);
        Csv.UploadFiles(mockCsv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.ZeroOrMoreQuestions));
    }

    [Test]
    public void UploadXML_XMLWithMoreThanOneQuestion(){
        var xml = TestService.Create("MoodleXMLWithMoreThanOneQuestion.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        Xml.UploadFiles(xml);
        Csv.UploadFiles(mockCsv);
        
        Submit.Click();
        Page.WaitForState(() => Page.Instance.IsUploading == false);
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.ZeroOrMoreQuestions));
    }

    [Test]
    public void UploadXML_CorrectXml(){
        var xml = TestService.Create("MoodleQuestionOk.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        var csv = TestService.Create("MoodleQuestionOk.csv", System.Net.Mime.MediaTypeNames.Text.Csv);
        Xml.UploadFiles(xml);
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
        
        Submit = null;
        Xml.Dispose();
        Csv.Dispose();
        Page.Dispose();
        
        base.TearDown();
    }
}