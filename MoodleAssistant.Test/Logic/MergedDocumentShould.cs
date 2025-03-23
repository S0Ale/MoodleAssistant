using System.Xml;
using MoodleAssistant.Logic;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Test.Logic;

[TestFixture]
internal class MergedDocumentShould{
    
    [SetUp]
    public void Setup(){
        if(!Directory.Exists("tmp"))
            Directory.CreateDirectory("tmp");
    }

    [Test]
    public void Throw_FormatOutOfRange(){
        var doc = new MergedDocument(new XmlDocument(), Format.Invalid);
        Assert.Throws<ArgumentOutOfRangeException>(() => doc.Save("./tmp/SAMPLE"));
    }

    [Test]
    public void Success_XmlDocument(){
        var xml = new XmlDocument();
        xml.LoadXml(TestService.GetString("MoodleQuestionOk.xml", true));
        var dir = Directory.GetCurrentDirectory();

        var doc = new MergedDocument(xml, Format.Xml);
        doc.Save("./tmp/SAMPLE.xml");
        Assert.That(File.Exists($"{dir}/tmp/SAMPLE.xml"));
    }

    [TearDown]
    public void TearDown(){
        File.Delete("./tmp/SAMPLE");
    }
}