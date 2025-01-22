#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Services](MoodleAssistant.Services.md 'MoodleAssistant.Services').[FileService](MoodleAssistant.Services.FileService.md 'MoodleAssistant.Services.FileService')

## FileService.GetFile(string) Method

Gets the [System.IO.FileStream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileStream 'System.IO.FileStream') of the specified file.

```csharp
public System.IO.FileStream GetFile(string fileName);
```
#### Parameters

<a name='MoodleAssistant.Services.FileService.GetFile(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file's name.

Implements [GetFile(string)](MoodleAssistant.Services.IBrowserFileService.GetFile(string).md 'MoodleAssistant.Services.IBrowserFileService.GetFile(string)')

#### Returns
[System.IO.FileStream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileStream 'System.IO.FileStream')  
The [System.IO.FileStream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileStream 'System.IO.FileStream') that encapsulates the file with the specified name.