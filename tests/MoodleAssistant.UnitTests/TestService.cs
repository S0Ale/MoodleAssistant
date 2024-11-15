using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Moq;
using static OpenQA.Selenium.BiDi.Modules.Session.ProxyConfiguration;

namespace MoodleAssistant.UnitTests;
internal class TestService {

    public static IFormFile GetFileResource(string name, string type) {
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("MoodleAssistant.UnitTests.assets." + name);
        if (stream == null) return null;

        var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        memoryStream.Position = 0;

        return new FormFile(memoryStream, 0, memoryStream.Length, name, name) {
            Headers = new HeaderDictionary(),
            ContentType = type
        };
    }

    public static IFormCollection GetFormsMock(IFormFile xml, IFormFile csv){
        var list = new Mock<IFormFileCollection>();

        if (csv == null) list.Setup(l => l.GetFile(It.IsAny<String>())).Returns(xml);
        else{
            list.Setup(l => l.GetFile("xml_upload")).Returns(xml);
            list.Setup(l => l.GetFile("csv_upload")).Returns(csv);
        }

        list.Setup(l => l.Count).Returns(2);
        var form = new Mock<IFormCollection>();
        form.Setup(f => f.Files).Returns(list.Object);
        return form.Object;
    }

    public static IFormFile GetCorrectXmlFile(){
        return GetFileResource("MoodleQuestionOk.xml", System.Net.Mime.MediaTypeNames.Text.Xml);
    }
}
