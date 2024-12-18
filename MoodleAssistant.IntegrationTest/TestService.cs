using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace MoodleAssistant.UnitTest;

internal abstract class TestService{
    private const string _assetsDir = @"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant.IntegrationTest\assets";
    private const string _screenDir = @"C:\Users\user\Desktop\UNI\MoodleAssistant\MoodleAssistant.IntegrationTest\screenshots";

    public static string GetPath(string fileName){
        return Path.Combine(_assetsDir, fileName);
    }
    
    private static byte[] GetBytes(string fileName){
        return File.ReadAllBytes(Path.Combine(_assetsDir, fileName));
    }

    public static async Task Screenshot(IPage page, string name, float y){
        var c = new Clip(){
            X = 0,
            Y = y,
            Width = 1920,
            Height = 1080
        };
        await page.ScreenshotAsync(new(){
            Path = Path.Combine(_screenDir, $"screen-{name}.png"),
            Clip = c
        });
    }



}