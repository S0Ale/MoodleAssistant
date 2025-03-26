#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.Aiken](MoodleAssistant.Logic.Processing.Aiken.md 'MoodleAssistant.Logic.Processing.Aiken')

## AikenFactory Class

Factory implementation for Aiken template types.

```csharp
public class AikenFactory :
MoodleAssistant.Logic.Processing.IReplicatorFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AikenFactory

Implements [IReplicatorFactory](MoodleAssistant.Logic.Processing.IReplicatorFactory.md 'MoodleAssistant.Logic.Processing.IReplicatorFactory')

| Constructors | |
| :--- | :--- |
| [AikenFactory(IBrowserFileService)](MoodleAssistant.Logic.Processing.Aiken.AikenFactory.AikenFactory(MoodleAssistant.Services.IBrowserFileService).md 'MoodleAssistant.Logic.Processing.Aiken.AikenFactory.AikenFactory(MoodleAssistant.Services.IBrowserFileService)') | Factory implementation for Aiken template types. |

| Methods | |
| :--- | :--- |
| [CreateAnalyzer()](MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateAnalyzer().md 'MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateAnalyzer()') | Creates a new instance of [IAnalyzer](MoodleAssistant.Logic.Processing.IAnalyzer.md 'MoodleAssistant.Logic.Processing.IAnalyzer'). |
| [CreateMerger(object, IEnumerable&lt;string[]&gt;)](MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateMerger(object,System.Collections.Generic.IEnumerable_string[]_).md 'MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateMerger(object, System.Collections.Generic.IEnumerable<string[]>)') | Creates a new instance of [IMerger](MoodleAssistant.Logic.Processing.IMerger.md 'MoodleAssistant.Logic.Processing.IMerger'). |
| [CreateParameterHandler(object, int)](MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateParameterHandler(object,int).md 'MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateParameterHandler(object, int)') | Creates a new instance of [ParameterHandler](MoodleAssistant.Logic.Processing.ParameterHandler.md 'MoodleAssistant.Logic.Processing.ParameterHandler'). |
| [CreatePreviewHandler()](MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreatePreviewHandler().md 'MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreatePreviewHandler()') | Creates a new instance of [IPreviewHandler](MoodleAssistant.Logic.Processing.IPreviewHandler.md 'MoodleAssistant.Logic.Processing.IPreviewHandler'). |
| [CreateTemplateModel(IBrowserFile)](MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateTemplateModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile).md 'MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateTemplateModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile)') | Creates a new instance of [ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel'). |
