#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.Aiken](MoodleAssistant.Logic.Processing.Aiken.md 'MoodleAssistant.Logic.Processing.Aiken')

## AikenMerger Class

Represents a class that merges the template Aiken file with the CSV file to create a new Aiken file.

```csharp
public class AikenMerger :
MoodleAssistant.Logic.Processing.IMerger
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AikenMerger

Implements [IMerger](MoodleAssistant.Logic.Processing.IMerger.md 'MoodleAssistant.Logic.Processing.IMerger')

| Constructors | |
| :--- | :--- |
| [AikenMerger(AikenDocument, IEnumerable&lt;string[]&gt;)](MoodleAssistant.Logic.Processing.Aiken.AikenMerger.AikenMerger(AikenDoc.AikenDocument,System.Collections.Generic.IEnumerable_string[]_).md 'MoodleAssistant.Logic.Processing.Aiken.AikenMerger.AikenMerger(AikenDoc.AikenDocument, System.Collections.Generic.IEnumerable<string[]>)') | Represents a class that merges the template Aiken file with the CSV file to create a new Aiken file. |

| Methods | |
| :--- | :--- |
| [FindInCsv(IEnumerable&lt;string[]&gt;, int, string)](MoodleAssistant.Logic.Processing.Aiken.AikenMerger.FindInCsv(System.Collections.Generic.IEnumerable_string[]_,int,string).md 'MoodleAssistant.Logic.Processing.Aiken.AikenMerger.FindInCsv(System.Collections.Generic.IEnumerable<string[]>, int, string)') | Finds the value of a parameter in the CSV file. |
| [MergeQuestion(bool)](MoodleAssistant.Logic.Processing.Aiken.AikenMerger.MergeQuestion(bool).md 'MoodleAssistant.Logic.Processing.Aiken.AikenMerger.MergeQuestion(bool)') | Creates a document with the replicated questions using the template file and the CSV file to find the parameter values. |
