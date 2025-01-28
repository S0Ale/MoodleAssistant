using Bunit;

namespace MoodleAssistant.Test;

internal abstract class TestService{
    private const string AssetsDir = "./assets";

    private static byte[] GetBytes(string fileName){
        return File.ReadAllBytes(Path.Combine(AssetsDir, fileName));
    }

    public static InputFileContent Create(string name, string contentType){
        return InputFileContent.CreateFromBinary(GetBytes(name), name, null, contentType);
    }

    public static InputFileContent CreateDummy(string name, int size, string contentType){
        return InputFileContent.CreateFromBinary(new byte[size], name, null, contentType);
    }

}