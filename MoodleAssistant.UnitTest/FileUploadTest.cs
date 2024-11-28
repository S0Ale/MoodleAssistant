using Bunit;

namespace MoodleAssistant.UnitTest;

public class FileUploadTest{
    protected BunitContext Ctx;

    [SetUp]
    public void Setup(){
        Ctx = new BunitContext();
    }

    [TearDown]
    public void TearDown(){
        Ctx.Dispose();
    }
}