#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Services](MoodleAssistant.Services.md 'MoodleAssistant.Services')

## IBrowserFileService Interface

Represents a service that manages the file operations during a user session.

```csharp
public interface IBrowserFileService
```

Derived  
&#8627; [FileService](MoodleAssistant.Services.FileService.md 'MoodleAssistant.Services.FileService')

| Methods | |
| :--- | :--- |
| [DeleteAllFiles()](MoodleAssistant.Services.IBrowserFileService.DeleteAllFiles().md 'MoodleAssistant.Services.IBrowserFileService.DeleteAllFiles()') | Deletes all files. |
| [DeleteFile(string)](MoodleAssistant.Services.IBrowserFileService.DeleteFile(string).md 'MoodleAssistant.Services.IBrowserFileService.DeleteFile(string)') | Deletes the file with the specified name. |
| [GetBase64(string)](MoodleAssistant.Services.IBrowserFileService.GetBase64(string).md 'MoodleAssistant.Services.IBrowserFileService.GetBase64(string)') | Gets the base64 string of the specified file. |
| [GetFile(string)](MoodleAssistant.Services.IBrowserFileService.GetFile(string).md 'MoodleAssistant.Services.IBrowserFileService.GetFile(string)') | Gets the [System.IO.FileStream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileStream 'System.IO.FileStream') of the specified file. |
| [SaveFile(IBrowserFile, string)](MoodleAssistant.Services.IBrowserFileService.SaveFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile,string).md 'MoodleAssistant.Services.IBrowserFileService.SaveFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile, string)') | Saves the specified file. |
