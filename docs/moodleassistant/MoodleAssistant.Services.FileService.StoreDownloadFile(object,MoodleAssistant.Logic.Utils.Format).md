#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Services](MoodleAssistant.Services.md 'MoodleAssistant.Services').[FileService](MoodleAssistant.Services.FileService.md 'MoodleAssistant.Services.FileService')

## FileService.StoreDownloadFile(object, Format) Method

Saves the specified document to file.

```csharp
public System.Threading.Tasks.Task<string> StoreDownloadFile(object doc, MoodleAssistant.Logic.Utils.Format format);
```
#### Parameters

<a name='MoodleAssistant.Services.FileService.StoreDownloadFile(object,MoodleAssistant.Logic.Utils.Format).doc'></a>

`doc` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The document to save.

<a name='MoodleAssistant.Services.FileService.StoreDownloadFile(object,MoodleAssistant.Logic.Utils.Format).format'></a>

`format` [Format](MoodleAssistant.Logic.Utils.Format.md 'MoodleAssistant.Logic.Utils.Format')

The document's format.

Implements [StoreDownloadFile(object, Format)](MoodleAssistant.Services.IBrowserFileService.StoreDownloadFile(object,MoodleAssistant.Logic.Utils.Format).md 'MoodleAssistant.Services.IBrowserFileService.StoreDownloadFile(object, MoodleAssistant.Logic.Utils.Format)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The file's name if the operation is successful; otherwise `null`.