using MoodleAssistant.Logic.Models;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Test.Logic;

public class XmlModelShould : ModelTest{
    [SetUp]
    public new void Setup(){
        base.Setup();
    }
    
    [Test]
    public void Throw_NonXmlFile(){
        var file = TestService.GetMockFile("EmptyCsv.csv", System.Net.Mime.MediaTypeNames.Text.Csv).Object;
        var model = new XmlModel(file, Service.Object);
        Assert.Throws<ReplicatorException>(() => model.Validate());
    }
    
    [Test]
    [TestCase("XmlBadFormed.xml")]
    [TestCase("XmlBadFormed-1.xml")]
    [TestCase("XmlBadFormed-2.xml")]
    [TestCase("XmlBadFormed-1.xml")]
    [TestCase("MoodleXMLWithoutQuestions.xml")]
    [TestCase("MoodleXMLWithMoreThanOneQuestion.xml")]
    public void Throw_XMLErrors(string name){
        Service.Setup(s => s.GetFile("TEMPLATE"))
            .Returns(() => TestService.GetStream(name));
        
        var file = TestService.GetMockFile(name, System.Net.Mime.MediaTypeNames.Text.Xml).Object;
        var model = new XmlModel(file, Service.Object);
        Assert.Throws<ReplicatorException>(() => model.Validate());
    }

    [Test]
    [TestCase("MoodleQuestionOk.xml")]
    [TestCase("MoodleOkWithImage.xml")]
    public void Success_XmlFiles(string name){
        Service.Setup(s => s.GetFile("TEMPLATE"))
            .Returns(() => TestService.GetStream(name));
        
        var file = TestService.GetMockFile(name, System.Net.Mime.MediaTypeNames.Text.Xml).Object;
        var model = new XmlModel(file, Service.Object);
        model.Validate();
    }

    [TearDown]
    public new void TearDown(){
        base.TearDown();
    }
}