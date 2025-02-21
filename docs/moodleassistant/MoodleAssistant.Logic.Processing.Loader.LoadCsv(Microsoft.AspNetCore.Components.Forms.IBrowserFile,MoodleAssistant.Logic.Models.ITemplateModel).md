#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing](MoodleAssistant.Logic.Processing.md 'MoodleAssistant.Logic.Processing').[Loader](MoodleAssistant.Logic.Processing.Loader.md 'MoodleAssistant.Logic.Processing.Loader')

## Loader.LoadCsv(IBrowserFile, ITemplateModel) Method

Loads the CSV file and validates it.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string[]>> LoadCsv(Microsoft.AspNetCore.Components.Forms.IBrowserFile file, MoodleAssistant.Logic.Models.ITemplateModel templateModel);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.Loader.LoadCsv(Microsoft.AspNetCore.Components.Forms.IBrowserFile,MoodleAssistant.Logic.Models.ITemplateModel).file'></a>

`file` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')

An instance of [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile') representing the CSV file.

<a name='MoodleAssistant.Logic.Processing.Loader.LoadCsv(Microsoft.AspNetCore.Components.Forms.IBrowserFile,MoodleAssistant.Logic.Models.ITemplateModel).templateModel'></a>

`templateModel` [ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel')

An instance of [ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel') representing the template file.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A list of string arrays representing the CSV file.

#### Exceptions

[ReplicatorException](MoodleAssistant.Logic.Utils.ReplicatorException.md 'MoodleAssistant.Logic.Utils.ReplicatorException')  
Thrown when a validation error occurs.