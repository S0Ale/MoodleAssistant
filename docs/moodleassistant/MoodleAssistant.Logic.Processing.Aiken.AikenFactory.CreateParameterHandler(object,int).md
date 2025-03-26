#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.Aiken](MoodleAssistant.Logic.Processing.Aiken.md 'MoodleAssistant.Logic.Processing.Aiken').[AikenFactory](MoodleAssistant.Logic.Processing.Aiken.AikenFactory.md 'MoodleAssistant.Logic.Processing.Aiken.AikenFactory')

## AikenFactory.CreateParameterHandler(object, int) Method

Creates a new instance of [ParameterHandler](MoodleAssistant.Logic.Processing.ParameterHandler.md 'MoodleAssistant.Logic.Processing.ParameterHandler').

```csharp
public MoodleAssistant.Logic.Processing.ParameterHandler CreateParameterHandler(object doc, int csvRows);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateParameterHandler(object,int).doc'></a>

`doc` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The template document.

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateParameterHandler(object,int).csvRows'></a>

`csvRows` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of csv rows in the CSV file.

Implements [CreateParameterHandler(object, int)](MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateParameterHandler(object,int).md 'MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateParameterHandler(object, int)')

#### Returns
[ParameterHandler](MoodleAssistant.Logic.Processing.ParameterHandler.md 'MoodleAssistant.Logic.Processing.ParameterHandler')  
An instance of [ParameterHandler](MoodleAssistant.Logic.Processing.ParameterHandler.md 'MoodleAssistant.Logic.Processing.ParameterHandler').