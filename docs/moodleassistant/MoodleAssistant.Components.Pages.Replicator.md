#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Components.Pages](MoodleAssistant.Components.Pages.md 'MoodleAssistant.Components.Pages')

## Replicator Class

Code-behind for the Replicator page.

```csharp
public class Replicator : Microsoft.AspNetCore.Components.ComponentBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; Replicator

| Fields | |
| :--- | :--- |
| [_csvInput](MoodleAssistant.Components.Pages.Replicator._csvInput.md 'MoodleAssistant.Components.Pages.Replicator._csvInput') | The [DropInput](MoodleAssistant.Components.Upload.DropInput.md 'MoodleAssistant.Components.Upload.DropInput') component for the CSV file upload. |
| [_dialog](MoodleAssistant.Components.Pages.Replicator._dialog.md 'MoodleAssistant.Components.Pages.Replicator._dialog') | The message dialog on the page. |
| [_formatSelect](MoodleAssistant.Components.Pages.Replicator._formatSelect.md 'MoodleAssistant.Components.Pages.Replicator._formatSelect') | The [MoodleAssistant.Components.FormatSelect](https://docs.microsoft.com/en-us/dotnet/api/MoodleAssistant.Components.FormatSelect 'MoodleAssistant.Components.FormatSelect') component for selecting the format of the uploaded files. |
| [_templateInput](MoodleAssistant.Components.Pages.Replicator._templateInput.md 'MoodleAssistant.Components.Pages.Replicator._templateInput') | The [DropInput](MoodleAssistant.Components.Upload.DropInput.md 'MoodleAssistant.Components.Upload.DropInput') component for the XML file upload. |

| Properties | |
| :--- | :--- |
| [ErrorMsg](MoodleAssistant.Components.Pages.Replicator.ErrorMsg.md 'MoodleAssistant.Components.Pages.Replicator.ErrorMsg') | The error message of the page. |

| Methods | |
| :--- | :--- |
| [ClearForm()](MoodleAssistant.Components.Pages.Replicator.ClearForm().md 'MoodleAssistant.Components.Pages.Replicator.ClearForm()') | Clears the form. |
| [Download()](MoodleAssistant.Components.Pages.Replicator.Download().md 'MoodleAssistant.Components.Pages.Replicator.Download()') | Downloads the merged file. |
| [Reset()](MoodleAssistant.Components.Pages.Replicator.Reset().md 'MoodleAssistant.Components.Pages.Replicator.Reset()') | Resets the page. |
| [ResetSections()](MoodleAssistant.Components.Pages.Replicator.ResetSections().md 'MoodleAssistant.Components.Pages.Replicator.ResetSections()') | Resets the sections of the page. |
| [SetError(Error)](MoodleAssistant.Components.Pages.Replicator.SetError(MoodleAssistant.Logic.Utils.Error).md 'MoodleAssistant.Components.Pages.Replicator.SetError(MoodleAssistant.Logic.Utils.Error)') | Sets the error message of the page. |
| [Submit()](MoodleAssistant.Components.Pages.Replicator.Submit().md 'MoodleAssistant.Components.Pages.Replicator.Submit()') | Submits the uploaded files. |
