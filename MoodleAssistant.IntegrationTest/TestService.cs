using Microsoft.Playwright;

namespace MoodleAssistant.IntegrationTest;

internal abstract class TestService{
    private const string AssetsDir = "./assets";
    private const string ScreenDir = "./screenshots";

    public static string GetPath(string fileName){
        return Path.Combine(AssetsDir, fileName);
    }
    
    private static byte[] GetBytes(string fileName){
        return File.ReadAllBytes(Path.Combine(AssetsDir, fileName));
    }

    public static async Task Screenshot(IPage page, string name, bool fullPage = false){
        await page.ScreenshotAsync(new(){
            Path = Path.Combine(ScreenDir, $"screen-{name}.png"),
            FullPage = fullPage
        });
    }



}