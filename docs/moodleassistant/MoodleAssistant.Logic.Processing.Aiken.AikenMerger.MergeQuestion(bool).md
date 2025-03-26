#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.Aiken](MoodleAssistant.Logic.Processing.Aiken.md 'MoodleAssistant.Logic.Processing.Aiken').[AikenMerger](MoodleAssistant.Logic.Processing.Aiken.AikenMerger.md 'MoodleAssistant.Logic.Processing.Aiken.AikenMerger')

## AikenMerger.MergeQuestion(bool) Method

Creates a document with the replicated questions using the template file and the CSV file to find the parameter values.

```csharp
public object MergeQuestion(bool previewMode=false);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenMerger.MergeQuestion(bool).previewMode'></a>

`previewMode` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the merge process is executing in preview mode or not.

Implements [MergeQuestion(bool)](MoodleAssistant.Logic.Processing.IMerger.MergeQuestion(bool).md 'MoodleAssistant.Logic.Processing.IMerger.MergeQuestion(bool)')

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The merged document.