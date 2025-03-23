using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Test.Logic;

[TestFixture]
internal class FormatExtensionShould{

    [Test]
    public void Throw_InvalidFormat(){
        Assert.Throws<ArgumentOutOfRangeException>(() => FormatExtension.GetExtension(Format.Invalid));
    }
    
    [Test]
    public void Success_XmlFile(){
        Assert.That(FormatExtension.GetExtension(Format.Xml), Is.EqualTo(".xml"));
    }
    
    [Test]
    public void Success_AikenFile(){
        Assert.That(FormatExtension.GetExtension(Format.Aiken), Is.EqualTo(".txt"));
    }
}