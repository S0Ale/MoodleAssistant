#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Components.Sections](MoodleAssistant.Components.Sections.md 'MoodleAssistant.Components.Sections')

## FileParam Class

Represents a section of the page that handles file uploads for file-type paarameters.

```csharp
public class FileParam : Microsoft.AspNetCore.Components.ComponentBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; FileParam

| Fields | |
| :--- | :--- |
| [_dialog](MoodleAssistant.Components.Sections.FileParam._dialog.md 'MoodleAssistant.Components.Sections.FileParam._dialog') | The error dialog of the section. |
| [_inputs](MoodleAssistant.Components.Sections.FileParam._inputs.md 'MoodleAssistant.Components.Sections.FileParam._inputs') | The file inputs of this section. |

| Properties | |
| :--- | :--- |
| [ErrorMsg](MoodleAssistant.Components.Sections.FileParam.ErrorMsg.md 'MoodleAssistant.Components.Sections.FileParam.ErrorMsg') | The error of the section. |
| [OnSuccess](MoodleAssistant.Components.Sections.FileParam.OnSuccess.md 'MoodleAssistant.Components.Sections.FileParam.OnSuccess') | The event callback invoked when the submit process is successful. |

| Methods | |
| :--- | :--- |
| [ClearForm()](MoodleAssistant.Components.Sections.FileParam.ClearForm().md 'MoodleAssistant.Components.Sections.FileParam.ClearForm()') | Clears the form. |
| [SetError(Error)](MoodleAssistant.Components.Sections.FileParam.SetError(MoodleAssistant.Logic.Utils.Error).md 'MoodleAssistant.Components.Sections.FileParam.SetError(MoodleAssistant.Logic.Utils.Error)') | Sets the error message of the section. |
| [Submit()](MoodleAssistant.Components.Sections.FileParam.Submit().md 'MoodleAssistant.Components.Sections.FileParam.Submit()') | Submits the uploaded files |
