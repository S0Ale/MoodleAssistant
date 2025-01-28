#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Models](MoodleAssistant.Logic.Models.md 'MoodleAssistant.Logic.Models').[XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel')

## XmlModel(IBrowserFile, IBrowserFileService) Constructor

Manages the validation of a XML template file and its parameters.

```csharp
public XmlModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile file, MoodleAssistant.Services.IBrowserFileService fileService);
```
#### Parameters

<a name='MoodleAssistant.Logic.Models.XmlModel.XmlModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile,MoodleAssistant.Services.IBrowserFileService).file'></a>

`file` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')

The instance of [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile') representing the file to validate.

<a name='MoodleAssistant.Logic.Models.XmlModel.XmlModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile,MoodleAssistant.Services.IBrowserFileService).fileService'></a>

`fileService` [IBrowserFileService](MoodleAssistant.Services.IBrowserFileService.md 'MoodleAssistant.Services.IBrowserFileService')

An instance of [IBrowserFileService](MoodleAssistant.Services.IBrowserFileService.md 'MoodleAssistant.Services.IBrowserFileService') to manage saved files.