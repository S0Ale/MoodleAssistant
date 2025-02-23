using MoodleAssistant.Logic.Models;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Test;


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
    
    [TearDown]
    public new void TearDown(){
        base.TearDown();
    }
}