using Bunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MoodleAssistant.Services;
using Moq;

namespace MoodleAssistant.UnitTest;

public class FileUploadTest{
    protected BunitContext Ctx;

    [SetUp]
    public void Setup(){
        Ctx = new BunitContext();
        var env = new Mock<IWebHostEnvironment>(); // faking IWebHostEnvironment
        env.Setup(e => e.WebRootPath).Returns(@"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant\wwwroot");
        Ctx.Services.AddScoped<IWebHostEnvironment>(e => env.Object);
        
        Ctx.JSInterop.Mode = JSRuntimeMode.Loose;
        //Ctx.JSInterop.SetupModule(@"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant\Components\Upload\FileDropInput.razor.js");
        
        Ctx.Services.AddScoped<IBrowserFileService, FileService>();
        Ctx.Services.AddScoped<ReplicatorState>();
    }

    [TearDown]
    public void TearDown(){
        var fs = Ctx.Services.GetService<FileService>();
        fs?.DeleteAllFiles();
        Ctx.Dispose();
    }
}