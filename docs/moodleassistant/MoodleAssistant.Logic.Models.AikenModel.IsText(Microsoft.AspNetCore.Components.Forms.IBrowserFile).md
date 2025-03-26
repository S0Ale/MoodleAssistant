#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Models](MoodleAssistant.Logic.Models.md 'MoodleAssistant.Logic.Models').[AikenModel](MoodleAssistant.Logic.Models.AikenModel.md 'MoodleAssistant.Logic.Models.AikenModel')

## AikenModel.IsText(IBrowserFile) Method

Checks if the [Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType 'Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType') of a file is plain text.

```csharp
private static bool IsText(Microsoft.AspNetCore.Components.Forms.IBrowserFile file);
```
#### Parameters

<a name='MoodleAssistant.Logic.Models.AikenModel.IsText(Microsoft.AspNetCore.Components.Forms.IBrowserFile).file'></a>

`file` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')

An instance of [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile') representing the file.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the file is plain text; otherwise `false`.