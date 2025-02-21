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

| Fields | |
| :--- | :--- |
| [Factory](MoodleAssistant.Services.ReplicatorState.Factory.md 'MoodleAssistant.Services.ReplicatorState.Factory') | Gets or sets the factory for the replicator components. |

| Properties | |
| :--- | :--- |
| [CsvAsList](MoodleAssistant.Services.ReplicatorState.CsvAsList.md 'MoodleAssistant.Services.ReplicatorState.CsvAsList') | Gets or sets the CSV file as a list of string arrays. |
| [Format](MoodleAssistant.Services.ReplicatorState.Format.md 'MoodleAssistant.Services.ReplicatorState.Format') | Gets or sets the format of the current template question. |
| [Merged](MoodleAssistant.Services.ReplicatorState.Merged.md 'MoodleAssistant.Services.ReplicatorState.Merged') | Gets or sets the merged document. |
| [Parameters](MoodleAssistant.Services.ReplicatorState.Parameters.md 'MoodleAssistant.Services.ReplicatorState.Parameters') | Gets or sets the parameters model of the current merged question (if any). |
| [Preview](MoodleAssistant.Services.ReplicatorState.Preview.md 'MoodleAssistant.Services.ReplicatorState.Preview') | Gets or sets the preview model of the current merged question (if any). |
| [Template](MoodleAssistant.Services.ReplicatorState.Template.md 'MoodleAssistant.Services.ReplicatorState.Template') | Gets or sets the template document. |

| Methods | |
| :--- | :--- |
| [Dispose()](MoodleAssistant.Services.ReplicatorState.Dispose().md 'MoodleAssistant.Services.ReplicatorState.Dispose()') | Disposes the current state of the program. |
| [Reset()](MoodleAssistant.Services.ReplicatorState.Reset().md 'MoodleAssistant.Services.ReplicatorState.Reset()') | Resets the state of the program. |
