#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Services](MoodleAssistant.Services.md 'MoodleAssistant.Services').[IBrowserFileService](MoodleAssistant.Services.IBrowserFileService.md 'MoodleAssistant.Services.IBrowserFileService')

## IBrowserFileService.SaveFile(IBrowserFile, string) Method

Saves the specified file.

```csharp
System.Threading.Tasks.Task<bool> SaveFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile file, string fileName);
```
#### Parameters

<a name='MoodleAssistant.Services.IBrowserFileService.SaveFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile,string).file'></a>

`file` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')

The instance of [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile') to save.

<a name='MoodleAssistant.Services.IBrowserFileService.SaveFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile,string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file's name.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
`true` if the operation is successful; otherwise `false`.