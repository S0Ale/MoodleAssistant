#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.XML](MoodleAssistant.Logic.Processing.XML.md 'MoodleAssistant.Logic.Processing.XML')

## XmlFactory Class

Factory implementation for XML template types.

```csharp
public class XmlFactory :
MoodleAssistant.Logic.Processing.IReplicatorFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; XmlFactory

Implements [IReplicatorFactory](MoodleAssistant.Logic.Processing.IReplicatorFactory.md 'MoodleAssistant.Logic.Processing.IReplicatorFactory')

| Constructors | |
| :--- | :--- |
| [XmlFactory(IBrowserFileService)](MoodleAssistant.Logic.Processing.XML.XmlFactory.XmlFactory(MoodleAssistant.Services.IBrowserFileService).md 'MoodleAssistant.Logic.Processing.XML.XmlFactory.XmlFactory(MoodleAssistant.Services.IBrowserFileService)') | Factory implementation for XML template types. |

| Methods | |
| :--- | :--- |
| [CreateAnalyzer()](MoodleAssistant.Logic.Processing.XML.XmlFactory.CreateAnalyzer().md 'MoodleAssistant.Logic.Processing.XML.XmlFactory.CreateAnalyzer()') | Creates a new instance of [IAnalyzer](MoodleAssistant.Logic.Processing.IAnalyzer.md 'MoodleAssistant.Logic.Processing.IAnalyzer'). |
| [CreateMerger(object, IEnumerable&lt;string[]&gt;)](MoodleAssistant.Logic.Processing.XML.XmlFactory.CreateMerger(object,System.Collections.Generic.IEnumerable_string[]_).md 'MoodleAssistant.Logic.Processing.XML.XmlFactory.CreateMerger(object, System.Collections.Generic.IEnumerable<string[]>)') | Creates a new instance of [IMerger](MoodleAssistant.Logic.Processing.IMerger.md 'MoodleAssistant.Logic.Processing.IMerger'). |
| [CreateParameterHandler(object, int)](MoodleAssistant.Logic.Processing.XML.XmlFactory.CreateParameterHandler(object,int).md 'MoodleAssistant.Logic.Processing.XML.XmlFactory.CreateParameterHandler(object, int)') | Creates a new instance of [ParameterHandler](MoodleAssistant.Logic.Processing.ParameterHandler.md 'MoodleAssistant.Logic.Processing.ParameterHandler'). |
| [CreatePreviewHandler()](MoodleAssistant.Logic.Processing.XML.XmlFactory.CreatePreviewHandler().md 'MoodleAssistant.Logic.Processing.XML.XmlFactory.CreatePreviewHandler()') | Creates a new instance of [IPreviewHandler](MoodleAssistant.Logic.Processing.IPreviewHandler.md 'MoodleAssistant.Logic.Processing.IPreviewHandler'). |
| [CreateTemplateModel(IBrowserFile)](MoodleAssistant.Logic.Processing.XML.XmlFactory.CreateTemplateModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile).md 'MoodleAssistant.Logic.Processing.XML.XmlFactory.CreateTemplateModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile)') | Creates a new instance of [ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel'). |
