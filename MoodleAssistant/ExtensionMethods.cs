using MoodleAssistant.Services;

namespace MoodleAssistant;

public static class ExtensionMethods{
    
    /// <summary>
    /// Checks if the file is empty.
    /// </summary>
    /// <param name="service">The <see cref="IBrowserFileService"/> instance to get the file.</param>
    /// <param name="name">The specified file name.</param>
    /// <returns>If the file with the specified file name is empty.</returns>
    public static bool IsEmpty(this IBrowserFileService service, string name){
        var info = service.GetFileInfo(name);
        switch (info.Length){
            case 0:
                return true;
            case >= 6:
                return false;
        }

        var stream = service.GetFile(name);
        using var reader = new StreamReader(stream);
        stream.Position = 0;
        return reader.ReadToEnd().Length == 0;
    }
}

