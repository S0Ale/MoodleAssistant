using Microsoft.AspNetCore.Hosting;
using MoodleAssistant.Services;
using Moq;

namespace MoodleAssistant.Test.Logic;

[TestFixture]
public abstract class ModelTest{

    protected Mock<IBrowserFileService> Service;
    
    [SetUp]
    public void Setup(){
        var env = new Mock<IWebHostEnvironment>(); // faking IWebHostEnvironment
        env.Setup(e => e.WebRootPath).Returns("./wwwroot");
        Service = new Mock<IBrowserFileService>();
    }
    
    [TearDown]
    public new void TearDown(){
    }
}