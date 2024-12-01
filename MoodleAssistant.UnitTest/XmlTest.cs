using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MoodleAssistant.Components.Pages;
using MoodleAssistant.Services;
using Moq;

namespace MoodleAssistant.UnitTest;

public class XmlTest : FileUploadTest{

    private IRenderedComponent<Replicator> Page;
    
    [SetUp]
    public new void Setup(){
        base.Setup();
        // C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant\wwwroot
        var env = new Mock<IWebHostEnvironment>(); // faking IWebHostEnvironment
        env.Setup(e => e.WebRootPath).Returns(@"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant\wwwroot");
        Ctx.Services.AddScoped<IWebHostEnvironment>(e => env.Object);
        
        Ctx.JSInterop.Mode = JSRuntimeMode.Loose;
        //Ctx.JSInterop.SetupModule(@"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant\Components\Upload\FileDropInput.razor.js");
        
        Ctx.Services.AddScoped<FileService>();
        Ctx.Services.AddScoped<ReplicatorState>();
        Page = Ctx.Render<Replicator>();
    }

    [Test]
    public void UploadXML_NonXMLFile(){
        var page = Page.FindComponent<InputFile>();
        var cut = Page.FindComponent<InputFile>();
        
        //var content = 
        //cut.UploadFiles();
        Assert.Pass();
    }

    [TearDown]
    public new void TearDown(){
        base.TearDown();
        Page.Dispose();
    }
}