#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.Aiken](MoodleAssistant.Logic.Processing.Aiken.md 'MoodleAssistant.Logic.Processing.Aiken').[AikenMerger](MoodleAssistant.Logic.Processing.Aiken.AikenMerger.md 'MoodleAssistant.Logic.Processing.Aiken.AikenMerger')

## AikenMerger.ReplaceParameters(string, bool, int) Method

Replace the parameters in the input string with the values from the CSV file.

```csharp
private string ReplaceParameters(string input, bool previewMode, int rowIndex);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenMerger.ReplaceParameters(string,bool,int).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The input string to replace the parameters in.

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenMerger.ReplaceParameters(string,bool,int).previewMode'></a>

`previewMode` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Weather the method is in preview mode or not.

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenMerger.ReplaceParameters(string,bool,int).rowIndex'></a>

`rowIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The index of the row in the CSV file to use.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The input string with the parameters replaced.