using Microsoft.AspNetCore.Hosting;
using MoodleAssistant.Services;
using Moq;

namespace MoodleAssistant.Test;

[TestFixture]
internal abstract class ModelTest{

    protected Mock<IBrowserFileService> Service;
    
    [SetUp]
    public void Setup(){
        var env = new Mock<IWebHostEnvironment>(); // faking IWebHostEnvironment
        env.Setup(e => e.WebRootPath).Returns("./wwwroot");
        Service = new Mock<IBrowserFileService>();
        
        Service.Setup(s => s.GetFile(It.IsAny<string>()))
            .Returns((string filename) => TestService.GetStream(filename));
    }
    
    [TearDown]
    public new void TearDown(){
    }
}