using Bunit;

namespace MoodleAssistant.UnitTest;

internal class TestService{
    private const string _assetsDir = @"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant.UnitTest\assets";
    
    private static byte[] GetBytes(string fileName){
        return File.ReadAllBytes(Path.Combine(_assetsDir, fileName));
    }
    
    public static InputFileContent Create(string name, string contentType){
        return InputFileContent.CreateFromBinary(GetBytes(name), name, null, contentType);
    }
}