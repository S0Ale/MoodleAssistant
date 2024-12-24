using System.Globalization;
using Bunit;
using CsvHelper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace MoodleAssistant.UnitTest;

internal abstract class TestService{
    private const string _assetsDir = @"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant.UnitTest\assets";
    
    private static byte[] GetBytes(string fileName){
        return File.ReadAllBytes(Path.Combine(_assetsDir, fileName));
    }
    
    public static InputFileContent Create(string name, string contentType){
        return InputFileContent.CreateFromBinary(GetBytes(name), name, null, contentType);
    }
}