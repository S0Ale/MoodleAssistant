using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using Moq;

namespace MoodleAssistant.Test;

internal abstract class TestService{
    private const string AssetsDir = "./assets";
    private const string TempDir = "./tmp";

    private static byte[] GetBytes(string fileName){
        return File.ReadAllBytes(Path.Combine(AssetsDir, fileName));
    }
    
    public static FileStream GetStream(string fileName){
        return new FileStream(Path.Combine(AssetsDir, fileName), FileMode.Open);
    }

    public static string GetString(string fileName, bool includeDir = false){
        var path = includeDir ? Path.Combine(AssetsDir, fileName) : fileName;
        return File.ReadAllText(path);
    }
    
    public static Mock<IBrowserFile> GetMockFile(string name, string contentType){
        var file = new Mock<IBrowserFile>();
        file.Setup(f => f.Name).Returns(name);
        file.Setup(f => f.ContentType).Returns(contentType);
        return file;
    }

    public static InputFileContent Create(string name, string contentType){
        return InputFileContent.CreateFromBinary(GetBytes(name), name, null, contentType);
    }

    public static InputFileContent CreateDummy(string name, int size, string contentType){
        return InputFileContent.CreateFromBinary(new byte[size], name, null, contentType);
    }

}