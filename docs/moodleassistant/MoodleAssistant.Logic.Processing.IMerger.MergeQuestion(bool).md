#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing](MoodleAssistant.Logic.Processing.md 'MoodleAssistant.Logic.Processing').[IMerger](MoodleAssistant.Logic.Processing.IMerger.md 'MoodleAssistant.Logic.Processing.IMerger')

## IMerger.MergeQuestion(bool) Method

Creates a document with the replicated questions using the template file and the CSV file to find the parameter values.

```csharp
object MergeQuestion(bool previewMode=false);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.IMerger.MergeQuestion(bool).previewMode'></a>

`previewMode` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the merge process is executing in preview mode or not.

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The merged document.