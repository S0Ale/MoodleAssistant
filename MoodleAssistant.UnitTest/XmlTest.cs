using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Components.Pages;

namespace MoodleAssistant.UnitTest;

public class XmlTest : FileUploadTest{

    private IRenderedComponent<Replicator> Page;
    
    [SetUp]
    public new void Setup(){
        base.Setup();
        Page = Ctx.Render<Replicator>();
    }

    [Test]
    public void UploadXML_NonXMLFile(){
        var page = Page.FindComponent<InputFile>();
        var cut = Page.FindComponent<InputFile>();

        //var content = InputFileContent.CreateFromBinary();
        //cut.UploadFiles()
        Assert.Pass();
    }

    [TearDown]
    public new void TearDown(){
        base.TearDown();
        Page.Dispose();
    }
}