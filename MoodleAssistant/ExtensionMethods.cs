using MoodleAssistant.Services;

namespace MoodleAssistant;

public static class ExtensionMethods{
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

