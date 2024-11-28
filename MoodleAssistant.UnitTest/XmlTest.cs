using Bunit;
using MoodleAssistant.Components.Pages;

namespace MoodleAssistant.UnitTest;

public class XmlTest : FileUploadTest{

    private IRenderedComponent<Replicator> Page;
    
    [SetUp]
    public new void Setup(){
        base.Setup();
        Page = Ctx.Render<Replicator>();
    }

    [TearDown]
    public new void TearDown(){
        base.TearDown();
        Page.Dispose();
    }
}