#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.Aiken](MoodleAssistant.Logic.Processing.Aiken.md 'MoodleAssistant.Logic.Processing.Aiken').[AikenMerger](MoodleAssistant.Logic.Processing.Aiken.AikenMerger.md 'MoodleAssistant.Logic.Processing.Aiken.AikenMerger')

## AikenMerger(AikenDocument, IEnumerable<string[]>) Constructor

Represents a class that merges the template Aiken file with the CSV file to create a new Aiken file.

```csharp
public AikenMerger(AikenDoc.AikenDocument template, System.Collections.Generic.IEnumerable<string[]> csvAsList);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenMerger.AikenMerger(AikenDoc.AikenDocument,System.Collections.Generic.IEnumerable_string[]_).template'></a>

`template` [AikenDoc.AikenDocument](https://docs.microsoft.com/en-us/dotnet/api/AikenDoc.AikenDocument 'AikenDoc.AikenDocument')

The [AikenDoc.AikenDocument](https://docs.microsoft.com/en-us/dotnet/api/AikenDoc.AikenDocument 'AikenDoc.AikenDocument') of the template question.

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenMerger.AikenMerger(AikenDoc.AikenDocument,System.Collections.Generic.IEnumerable_string[]_).csvAsList'></a>

`csvAsList` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The CSV file as a list of string arrays.