using AikenDoc;
using MoodleAssistant.Logic.Models;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Test.Logic;

internal class AikenModelShould : ModelTest{
    [SetUp]
    public new void Setup(){
        base.Setup();
    }
    
    [Test]
    public void Throw_NonAikenFile(){
        var file = TestService.GetMockFile("EmptyCsv.csv", System.Net.Mime.MediaTypeNames.Text.Csv).Object;
        var model = new AikenModel(file, Service.Object);
        Assert.Throws<ReplicatorException>(() => model.Validate());
    }
    
    [Test]
    public void Throw_NoAnswer(){
        Service.Setup(s => s.GetFile("TEMPLATE"))
            .Returns(() => TestService.GetStream("InvalidAnswer.txt"));

        var file = TestService.GetMockFile("InvalidAnswer.txt", System.Net.Mime.MediaTypeNames.Text.Plain).Object;
        var model = new AikenModel(file, Service.Object);
        Assert.Throws<ReplicatorException>(() => model.Validate());
    }
    
    [Test]
    public void Throw_InvalidOption(){
        Service.Setup(s => s.GetFile("TEMPLATE"))
            .Returns(() => TestService.GetStream("InvalidOption.txt"));
        
        var file = TestService.GetMockFile("InvalidOption.txt", System.Net.Mime.MediaTypeNames.Text.Plain).Object;
        var model = new AikenModel(file, Service.Object);
        Assert.Throws<ReplicatorException>(() => model.Validate());
    }
    
    [Test]
    public void Throw_MoreThanOneQuestion(){
        Service.Setup(s => s.GetFile("TEMPLATE"))
            .Returns(() => TestService.GetStream("AikenMoreQuestions.txt"));
        
        var file = TestService.GetMockFile("AikenMoreQuestions.txt", System.Net.Mime.MediaTypeNames.Text.Plain).Object;
        var model = new AikenModel(file, Service.Object);
        Assert.Throws<ReplicatorException>(() => model.Validate());
    }

    [Test]
    public void Throw_AikenWithFile(){
        Service.Setup(s => s.GetFile("TEMPLATE"))
            .Returns(() => TestService.GetStream("AikenWithFileParams.txt"));
        
        var file = TestService.GetMockFile("InvalidOption.txt", System.Net.Mime.MediaTypeNames.Text.Plain).Object;
        var model = new AikenModel(file, Service.Object);
        Assert.Throws<ReplicatorException>(() => model.Validate());
    }

    [Test]
    public void Success_BasicAiken(){
        Service.Setup(s => s.GetFile("TEMPLATE"))
            .Returns(() => TestService.GetStream("AikenOk.txt"));
        
        var file = TestService.GetMockFile("AikenOk.txt", System.Net.Mime.MediaTypeNames.Text.Plain).Object;
        var model = new AikenModel(file, Service.Object);
        model.Validate();
        Assert.That(((AikenDocument)model.TemplateDocument).Questions, Has.Count.EqualTo(1));
    }
    
    [TearDown]
    public new void TearDown(){
        base.TearDown();
    }
}