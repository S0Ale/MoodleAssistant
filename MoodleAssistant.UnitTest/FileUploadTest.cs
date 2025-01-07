using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MoodleAssistant.Services;
using Moq;

namespace MoodleAssistant.UnitTest;

[TestFixture]
internal abstract  class FileUploadTest{
    protected BunitContext Ctx;

    [SetUp]
    public void Setup(){
        Ctx = new BunitContext();
        
        Ctx.JSInterop.Mode = JSRuntimeMode.Loose;
        
        Ctx.Services.AddScoped<IBrowserFileService, FileService>();
        Ctx.Services.AddScoped<ReplicatorState>();
    }

    [TearDown]
    public void TearDown(){
        Ctx.Dispose();
    }
}