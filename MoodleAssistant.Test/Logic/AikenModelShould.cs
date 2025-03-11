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
    [TestCase("InvalidAnswer.txt")]
    [TestCase("InvalidOption.txt")]
    [TestCase("AikenMoreQuestions.txt")]
    [TestCase("AikenWithFileParams.txt")]
    public void Throw_AikenBadFormed(string name){
        Service.Setup(s => s.GetFile("TEMPLATE"))
            .Returns(() => TestService.GetStream(name));
        
        var file = TestService.GetMockFile(name, System.Net.Mime.MediaTypeNames.Text.Plain).Object;
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