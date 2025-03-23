#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.Aiken](MoodleAssistant.Logic.Processing.Aiken.md 'MoodleAssistant.Logic.Processing.Aiken')

## AikenAnalyzer Class

Analyzes a template question document in Aiken format.

```csharp
public class AikenAnalyzer :
MoodleAssistant.Logic.Processing.IAnalyzer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AikenAnalyzer

Implements [IAnalyzer](MoodleAssistant.Logic.Processing.IAnalyzer.md 'MoodleAssistant.Logic.Processing.IAnalyzer')

| Fields | |
| :--- | :--- |
| [Pattern](MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.Pattern.md 'MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.Pattern') | The parameters' regex pattern. |

| Methods | |
| :--- | :--- |
| [GetFormattedAnswers(object)](MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.GetFormattedAnswers(object).md 'MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.GetFormattedAnswers(object)') | Gets the HTML formatted answers from the document. |
| [GetFormattedQuestionText(object)](MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.GetFormattedQuestionText(object).md 'MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.GetFormattedQuestionText(object)') | Gets the HTML formatted question text from the document. |
| [HasQuestion(AikenDocument)](MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.HasQuestion(AikenDoc.AikenDocument).md 'MoodleAssistant.Logic.Processing.Aiken.AikenAnalyzer.HasQuestion(AikenDoc.AikenDocument)') | Checks if the Aiken file has questions. |
