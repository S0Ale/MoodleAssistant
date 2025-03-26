#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.Aiken](MoodleAssistant.Logic.Processing.Aiken.md 'MoodleAssistant.Logic.Processing.Aiken').[AikenAnalyzer](MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.md 'MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer')

## AikenAnalyzer.HasQuestion(AikenDocument) Method

Checks if the Aiken file has questions.

```csharp
private static bool HasQuestion(AikenDoc.AikenDocument doc);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.HasQuestion(AikenDoc.AikenDocument).doc'></a>

`doc` [AikenDoc.AikenDocument](https://docs.microsoft.com/en-us/dotnet/api/AikenDoc.AikenDocument 'AikenDoc.AikenDocument')

The Aiken file.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if questions are present; otherwise `false`.