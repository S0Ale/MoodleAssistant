using Bunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MoodleAssistant.Services;
using Moq;

namespace MoodleAssistant.Test;

[TestFixture]
internal abstract  class FileUploadTest{
    protected BunitContext Ctx;

    [SetUp]
    public void Setup(){
        Ctx = new BunitContext();
        var env = new Mock<IWebHostEnvironment>(); // faking IWebHostEnvironment
        env.Setup(e => e.WebRootPath).Returns("./wwwroot");
        Ctx.Services.AddScoped<IWebHostEnvironment>(_ => env.Object);
        
        Ctx.JSInterop.Mode = JSRuntimeMode.Loose;
        
        Ctx.Services.AddScoped<IBrowserFileService, FileService>();
        Ctx.Services.AddScoped<ReplicatorState>();
    }

    [TearDown]
    public void TearDown(){
        Ctx.Dispose();
    }
}