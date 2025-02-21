#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Services](MoodleAssistant.Services.md 'MoodleAssistant.Services').[IBrowserFileService](MoodleAssistant.Services.IBrowserFileService.md 'MoodleAssistant.Services.IBrowserFileService')

## IBrowserFileService.StoreDownloadFile(object, Format) Method

Saves the specified document to file.

```csharp
System.Threading.Tasks.Task<string> StoreDownloadFile(object doc, MoodleAssistant.Logic.Utils.Format format);
```
#### Parameters

<a name='MoodleAssistant.Services.IBrowserFileService.StoreDownloadFile(object,MoodleAssistant.Logic.Utils.Format).doc'></a>

`doc` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The document to save.

<a name='MoodleAssistant.Services.IBrowserFileService.StoreDownloadFile(object,MoodleAssistant.Logic.Utils.Format).format'></a>

`format` [Format](MoodleAssistant.Logic.Utils.Format.md 'MoodleAssistant.Logic.Utils.Format')

The document's format.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The file's name if the operation is successful; otherwise `null`.