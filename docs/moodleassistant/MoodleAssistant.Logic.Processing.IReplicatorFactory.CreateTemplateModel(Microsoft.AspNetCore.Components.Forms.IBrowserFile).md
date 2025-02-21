#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing](MoodleAssistant.Logic.Processing.md 'MoodleAssistant.Logic.Processing').[IReplicatorFactory](MoodleAssistant.Logic.Processing.IReplicatorFactory.md 'MoodleAssistant.Logic.Processing.IReplicatorFactory')

## IReplicatorFactory.CreateTemplateModel(IBrowserFile) Method

Creates a new instance of [ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel').

```csharp
MoodleAssistant.Logic.Models.ITemplateModel CreateTemplateModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile file);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateTemplateModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile).file'></a>

`file` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')

The file to create the model from.

#### Returns
[ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel')  
An instance of [ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel').