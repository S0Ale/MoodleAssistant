#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing](MoodleAssistant.Logic.Processing.md 'MoodleAssistant.Logic.Processing').[Loader](MoodleAssistant.Logic.Processing.Loader.md 'MoodleAssistant.Logic.Processing.Loader')

## Loader.LoadFiles(IBrowserFile[]) Method

Loads the files uploaded and validates them.

```csharp
public System.Threading.Tasks.Task LoadFiles(Microsoft.AspNetCore.Components.Forms.IBrowserFile[] files);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.Loader.LoadFiles(Microsoft.AspNetCore.Components.Forms.IBrowserFile[]).files'></a>

`files` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Sequence of [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile') instances representing the uploaded files.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[ReplicatorException](MoodleAssistant.Logic.Utils.ReplicatorException.md 'MoodleAssistant.Logic.Utils.ReplicatorException')  
Thrown when a validation error occurs.