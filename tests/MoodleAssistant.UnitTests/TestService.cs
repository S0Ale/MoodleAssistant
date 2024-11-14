using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OpenQA.Selenium.DevTools.V128.FileSystem;

namespace MoodleAssistant.UnitTests;
internal class TestService {

    public static IFormFile GetFileResource(string name) {
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("MoodleAssistant.UnitTests.assets." + name);
        if (stream == null) return null;

        var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        memoryStream.Position = 0;

        return new FormFile(memoryStream, 0, memoryStream.Length, name, name) {
            Headers = new HeaderDictionary()
        };
    }
}
