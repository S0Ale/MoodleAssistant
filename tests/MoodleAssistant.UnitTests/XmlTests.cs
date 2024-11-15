using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;
using NUnit.Framework;

namespace MoodleAssistant.UnitTests;

[TestFixture]
internal class XmlTests : FileUploadTests{

    [Test]
    public void UploadXML_NonXMLFile() {
        var xml = TestService.GetFileResource("txtFile.txt", System.Net.Mime.MediaTypeNames.Text.Plain);
        var form = TestService.GetFormsMock(xml);

        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as MainModel;
        Assert.That(m.Error, Is.EqualTo(Error.NonXmlFile));
    }

    [Test]
    public void UploadXML_EmptyXML() {
        var xml = TestService.GetFileResource("EmptyXmlFile.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
        var form = TestService.GetFormsMock(xml);

        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as MainModel;
        ;
        Assert.That(m.Error, Is.EqualTo(Error.EmptyFile));
    }

    [Test]
    [TestCase("XmlBadFormed.xml")]
    [TestCase("XmlBadFormed-1.xml")]
    [TestCase("XmlBadFormed-2.xml")]
    public void UploadXML_XmlBadFormed(string name) {
        var xml = TestService.GetFileResource(name, System.Net.Mime.MediaTypeNames.Text.Xml);
        var form = TestService.GetFormsMock(xml);

        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as MainModel;
        Assert.That(m.Error, Is.EqualTo(Error.XmlBadFormed));
    }

    [Test]
    public void UploadXML_XMLWithoutQuestions() {
        var xml = TestService.GetFileResource("MoodleXMLWithoutQuestions.xml", System.Net.Mime.MediaTypeNames.Text.Xml);

        var form = TestService.GetFormsMock(xml);
        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as MainModel;
        Assert.That(m.Error, Is.EqualTo(Error.ZeroOrMoreQuestions));
    }

    [Test]
    public void UploadXML_XMLWithMoreThanOneQuestion(){
        var xml = TestService.GetFileResource("MoodleXMLWithMoreThanOneQuestion.xml", System.Net.Mime.MediaTypeNames.Text.Xml);

        var form = TestService.GetFormsMock(xml);
        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as MainModel;
        Assert.That(m.Error, Is.EqualTo(Error.ZeroOrMoreQuestions));
    }
}
