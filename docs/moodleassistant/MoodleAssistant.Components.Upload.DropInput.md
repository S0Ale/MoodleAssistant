#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Components.Upload](MoodleAssistant.Components.Upload.md 'MoodleAssistant.Components.Upload')

## DropInput Class

The component for uploading one or multiple files.

```csharp
public class DropInput : Microsoft.AspNetCore.Components.ComponentBase,
System.IAsyncDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; DropInput

Implements [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')

| Fields | |
| :--- | :--- |
| [_current](MoodleAssistant.Components.Upload.DropInput._current.md 'MoodleAssistant.Components.Upload.DropInput._current') | The current index of the uploaded files. |
| [_module](MoodleAssistant.Components.Upload.DropInput._module.md 'MoodleAssistant.Components.Upload.DropInput._module') | A JavaScript module reference. |

| Properties | |
| :--- | :--- |
| [ChildContent](MoodleAssistant.Components.Upload.DropInput.ChildContent.md 'MoodleAssistant.Components.Upload.DropInput.ChildContent') | The [Microsoft.AspNetCore.Components.RenderFragment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.RenderFragment 'Microsoft.AspNetCore.Components.RenderFragment') representing the child content. |
| [InputName](MoodleAssistant.Components.Upload.DropInput.InputName.md 'MoodleAssistant.Components.Upload.DropInput.InputName') | The name of the input element. |
| [MaxFiles](MoodleAssistant.Components.Upload.DropInput.MaxFiles.md 'MoodleAssistant.Components.Upload.DropInput.MaxFiles') | The maximum number of files that can be uploaded. |
| [MaxSize](MoodleAssistant.Components.Upload.DropInput.MaxSize.md 'MoodleAssistant.Components.Upload.DropInput.MaxSize') | The maximum size of the files that can be uploaded. |
| [UploadedFiles](MoodleAssistant.Components.Upload.DropInput.UploadedFiles.md 'MoodleAssistant.Components.Upload.DropInput.UploadedFiles') | The uploaded files. |

| Methods | |
| :--- | :--- |
| [ClearFiles()](MoodleAssistant.Components.Upload.DropInput.ClearFiles().md 'MoodleAssistant.Components.Upload.DropInput.ClearFiles()') | Clears the uploaded files. |
| [FindNext()](MoodleAssistant.Components.Upload.DropInput.FindNext().md 'MoodleAssistant.Components.Upload.DropInput.FindNext()') | Finds the next available index for the uploaded files. |
| [OnAfterRenderAsync(bool)](MoodleAssistant.Components.Upload.DropInput.OnAfterRenderAsync(bool).md 'MoodleAssistant.Components.Upload.DropInput.OnAfterRenderAsync(bool)') | Function invoked when the component has been rendered. |
| [RemoveFile(int)](MoodleAssistant.Components.Upload.DropInput.RemoveFile(int).md 'MoodleAssistant.Components.Upload.DropInput.RemoveFile(int)') | Removes a file from the uploaded files. |
| [UploadFile(InputFileChangeEventArgs)](MoodleAssistant.Components.Upload.DropInput.UploadFile(Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs).md 'MoodleAssistant.Components.Upload.DropInput.UploadFile(Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs)') | Uploads the files. |

| Explicit Interface Implementations | |
| :--- | :--- |
| [System.IAsyncDisposable.DisposeAsync()](MoodleAssistant.Components.Upload.DropInput.System.IAsyncDisposable.DisposeAsync().md 'MoodleAssistant.Components.Upload.DropInput.System.IAsyncDisposable.DisposeAsync()') | Disposes the component asynchronously. |
