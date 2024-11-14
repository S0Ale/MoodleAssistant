using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Moq;

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

    public static IFormCollection GetFormsMock(IFormFile file){
        var list = new Mock<IFormFileCollection>();
        list.Setup(l => l.GetFile(It.IsAny<String>())).Returns(file);
        list.Setup(l => l.Count).Returns(2);
        var form = new Mock<IFormCollection>();
        form.Setup(f => f.Files).Returns(list.Object);
        return form.Object;
    }
}
