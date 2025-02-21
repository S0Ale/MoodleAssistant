#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing](MoodleAssistant.Logic.Processing.md 'MoodleAssistant.Logic.Processing').[Loader](MoodleAssistant.Logic.Processing.Loader.md 'MoodleAssistant.Logic.Processing.Loader')

## Loader.LoadTemplate(IBrowserFile) Method

Loads the template question file and validates it.

```csharp
public System.Threading.Tasks.Task<MoodleAssistant.Logic.Models.ITemplateModel> LoadTemplate(Microsoft.AspNetCore.Components.Forms.IBrowserFile file);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.Loader.LoadTemplate(Microsoft.AspNetCore.Components.Forms.IBrowserFile).file'></a>

`file` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')

An instance of [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')representing the template question.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An instance of [ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel') to manage the file.

#### Exceptions

[ReplicatorException](MoodleAssistant.Logic.Utils.ReplicatorException.md 'MoodleAssistant.Logic.Utils.ReplicatorException')  
Thrown when a validation error occurs.