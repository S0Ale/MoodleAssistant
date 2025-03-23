#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing](MoodleAssistant.Logic.Processing.md 'MoodleAssistant.Logic.Processing').[IReplicatorFactory](MoodleAssistant.Logic.Processing.IReplicatorFactory.md 'MoodleAssistant.Logic.Processing.IReplicatorFactory')

## IReplicatorFactory.CreateParameterHandler(object, int) Method

Creates a new instance of [ParameterHandler](MoodleAssistant.Logic.Processing.ParameterHandler.md 'MoodleAssistant.Logic.Processing.ParameterHandler').

```csharp
MoodleAssistant.Logic.Processing.ParameterHandler CreateParameterHandler(object doc, int csvRows);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateParameterHandler(object,int).doc'></a>

`doc` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The template document.

<a name='MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateParameterHandler(object,int).csvRows'></a>

`csvRows` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of csv rows in the CSV file.

#### Returns
[ParameterHandler](MoodleAssistant.Logic.Processing.ParameterHandler.md 'MoodleAssistant.Logic.Processing.ParameterHandler')  
An instance of [ParameterHandler](MoodleAssistant.Logic.Processing.ParameterHandler.md 'MoodleAssistant.Logic.Processing.ParameterHandler').