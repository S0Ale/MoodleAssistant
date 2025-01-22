#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Services](MoodleAssistant.Services.md 'MoodleAssistant.Services')

## ReplicatorState Class

Represents the current state of the program, during the current user session.

```csharp
public class ReplicatorState :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ReplicatorState

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [AnswerCount](MoodleAssistant.Services.ReplicatorState.AnswerCount.md 'MoodleAssistant.Services.ReplicatorState.AnswerCount') | Gets or sets the number of answers in the template question. |
| [CsvAsList](MoodleAssistant.Services.ReplicatorState.CsvAsList.md 'MoodleAssistant.Services.ReplicatorState.CsvAsList') | Gets or sets the CSV file as a list of string arrays. |
| [Merged](MoodleAssistant.Services.ReplicatorState.Merged.md 'MoodleAssistant.Services.ReplicatorState.Merged') | Gets or sets the merged XML document. |
| [Parameters](MoodleAssistant.Services.ReplicatorState.Parameters.md 'MoodleAssistant.Services.ReplicatorState.Parameters') | Gets or sets the parameters model of the current merged question (if any). |
| [Preview](MoodleAssistant.Services.ReplicatorState.Preview.md 'MoodleAssistant.Services.ReplicatorState.Preview') | Gets or sets the preview model of the current merged question (if any). |
| [Template](MoodleAssistant.Services.ReplicatorState.Template.md 'MoodleAssistant.Services.ReplicatorState.Template') | Gets or sets the template XML document. |

| Methods | |
| :--- | :--- |
| [Dispose()](MoodleAssistant.Services.ReplicatorState.Dispose().md 'MoodleAssistant.Services.ReplicatorState.Dispose()') | Disposes the current state of the program. |
| [Reset()](MoodleAssistant.Services.ReplicatorState.Reset().md 'MoodleAssistant.Services.ReplicatorState.Reset()') | Resets the state of the program. |
