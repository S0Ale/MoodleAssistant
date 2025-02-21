#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing](MoodleAssistant.Logic.Processing.md 'MoodleAssistant.Logic.Processing')

## IReplicatorFactory Interface

Defines the factory for the logic components.

```csharp
public interface IReplicatorFactory
```

Derived  
&#8627; [XmlFactory](MoodleAssistant.Logic.Processing.XML.XmlFactory.md 'MoodleAssistant.Logic.Processing.XML.XmlFactory')

| Methods | |
| :--- | :--- |
| [CreateAnalyzer()](MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateAnalyzer().md 'MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateAnalyzer()') | Creates a new instance of [IAnalyzer](MoodleAssistant.Logic.Processing.IAnalyzer.md 'MoodleAssistant.Logic.Processing.IAnalyzer'). |
| [CreateMerger(object, IEnumerable&lt;string[]&gt;)](MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateMerger(object,System.Collections.Generic.IEnumerable_string[]_).md 'MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateMerger(object, System.Collections.Generic.IEnumerable<string[]>)') | Creates a new instance of [IMerger](MoodleAssistant.Logic.Processing.IMerger.md 'MoodleAssistant.Logic.Processing.IMerger'). |
| [CreateParameterHandler(object, int)](MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateParameterHandler(object,int).md 'MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateParameterHandler(object, int)') | Creates a new instance of [IParameterHandler](MoodleAssistant.Logic.Processing.IParameterHandler.md 'MoodleAssistant.Logic.Processing.IParameterHandler'). |
| [CreatePreviewHandler()](MoodleAssistant.Logic.Processing.IReplicatorFactory.CreatePreviewHandler().md 'MoodleAssistant.Logic.Processing.IReplicatorFactory.CreatePreviewHandler()') | Creates a new instance of [IPreviewHandler](MoodleAssistant.Logic.Processing.IPreviewHandler.md 'MoodleAssistant.Logic.Processing.IPreviewHandler'). |
| [CreateTemplateModel(IBrowserFile)](MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateTemplateModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile).md 'MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateTemplateModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile)') | Creates a new instance of [ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel'). |
