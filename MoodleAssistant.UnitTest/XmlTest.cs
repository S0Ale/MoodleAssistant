using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Utils;
using MoodleAssistant.Components.Pages;

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
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.NonXmlFile));
    }

    [Test]
    public void UploadXML_EmptyXML(){
        var xml = TestService.Create("EmptyXmlFile.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        Xml.UploadFiles(xml);
        Csv.UploadFiles(mockCsv);
        
        Submit.Click();
        Assert.That(Page.Instance.Error, Is.EqualTo(Error.EmptyFile));
    }

    [TearDown]
    public new void TearDown(){
        base.TearDown();
        Page.Dispose();
    }
}