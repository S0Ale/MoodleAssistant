#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Services](MoodleAssistant.Services.md 'MoodleAssistant.Services')

## FileService Class

Represents a service that manages the file operations during a user session.

```csharp
public class FileService :
MoodleAssistant.Services.IBrowserFileService,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FileService

Implements [IBrowserFileService](MoodleAssistant.Services.IBrowserFileService.md 'MoodleAssistant.Services.IBrowserFileService'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [FileService(IWebHostEnvironment)](MoodleAssistant.Services.FileService.FileService(Microsoft.AspNetCore.Hosting.IWebHostEnvironment).md 'MoodleAssistant.Services.FileService.FileService(Microsoft.AspNetCore.Hosting.IWebHostEnvironment)') | Represents a service that manages the file operations during a user session. |

| Fields | |
| :--- | :--- |
| [_rootFolder](MoodleAssistant.Services.FileService._rootFolder.md 'MoodleAssistant.Services.FileService._rootFolder') | The root folder where the files are saved. |
| [_trustedFiles](MoodleAssistant.Services.FileService._trustedFiles.md 'MoodleAssistant.Services.FileService._trustedFiles') | Map of fixed file names with their trusted file names. |
| [MaxFileSize](MoodleAssistant.Services.FileService.MaxFileSize.md 'MoodleAssistant.Services.FileService.MaxFileSize') | The maximum file size in bytes. |

| Methods | |
| :--- | :--- |
| [DeleteAllFiles()](MoodleAssistant.Services.FileService.DeleteAllFiles().md 'MoodleAssistant.Services.FileService.DeleteAllFiles()') | Deletes all files. |
| [DeleteFile(string)](MoodleAssistant.Services.FileService.DeleteFile(string).md 'MoodleAssistant.Services.FileService.DeleteFile(string)') | Deletes the file with the specified name. |
| [Dispose()](MoodleAssistant.Services.FileService.Dispose().md 'MoodleAssistant.Services.FileService.Dispose()') | Disposes the service and deletes all files. |
| [GetBase64(string)](MoodleAssistant.Services.FileService.GetBase64(string).md 'MoodleAssistant.Services.FileService.GetBase64(string)') | Gets the base64 string of the specified file. |
| [GetFile(string)](MoodleAssistant.Services.FileService.GetFile(string).md 'MoodleAssistant.Services.FileService.GetFile(string)') | Gets the [System.IO.FileStream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileStream 'System.IO.FileStream') of the specified file. |
| [SaveFile(IBrowserFile, string)](MoodleAssistant.Services.FileService.SaveFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile,string).md 'MoodleAssistant.Services.FileService.SaveFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile, string)') | Saves the specified file. |
