using Bunit;

namespace MoodleAssistant.UnitTest;

internal abstract class TestService{
    private const string AssetsDir = @"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant.UnitTest\assets";
    
    private static byte[] GetBytes(string fileName){
        return File.ReadAllBytes(Path.Combine(AssetsDir, fileName));
    }
    
    public static InputFileContent Create(string name, string contentType){
        return InputFileContent.CreateFromBinary(GetBytes(name), name, null, contentType);
    }
}