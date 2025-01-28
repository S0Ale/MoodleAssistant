#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Models](MoodleAssistant.Logic.Models.md 'MoodleAssistant.Logic.Models').[FileModel](MoodleAssistant.Logic.Models.FileModel.md 'MoodleAssistant.Logic.Models.FileModel')

## FileModel.IsImage(IBrowserFile) Method

Checks if the [Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType 'Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType') of a file is an image.

```csharp
public bool IsImage(Microsoft.AspNetCore.Components.Forms.IBrowserFile file);
```
#### Parameters

<a name='MoodleAssistant.Logic.Models.FileModel.IsImage(Microsoft.AspNetCore.Components.Forms.IBrowserFile).file'></a>

`file` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')

An instance of [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile') representing the file.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the file is an image; otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').