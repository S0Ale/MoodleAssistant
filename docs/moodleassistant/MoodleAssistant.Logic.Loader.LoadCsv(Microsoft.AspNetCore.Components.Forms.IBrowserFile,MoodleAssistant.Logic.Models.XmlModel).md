#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic](MoodleAssistant.Logic.md 'MoodleAssistant.Logic').[Loader](MoodleAssistant.Logic.Loader.md 'MoodleAssistant.Logic.Loader')

## Loader.LoadCsv(IBrowserFile, XmlModel) Method

Loads the CSV file and validates it.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string[]>> LoadCsv(Microsoft.AspNetCore.Components.Forms.IBrowserFile file, MoodleAssistant.Logic.Models.XmlModel xmlModel);
```
#### Parameters

<a name='MoodleAssistant.Logic.Loader.LoadCsv(Microsoft.AspNetCore.Components.Forms.IBrowserFile,MoodleAssistant.Logic.Models.XmlModel).file'></a>

`file` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')

An instance of [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile') representing the CSV file.

<a name='MoodleAssistant.Logic.Loader.LoadCsv(Microsoft.AspNetCore.Components.Forms.IBrowserFile,MoodleAssistant.Logic.Models.XmlModel).xmlModel'></a>

`xmlModel` [XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel')

An instance of [XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel') representing the template XML file.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A list of string arrays representing the CSV file.

#### Exceptions

[ReplicatorException](MoodleAssistant.Logic.Utils.ReplicatorException.md 'MoodleAssistant.Logic.Utils.ReplicatorException')  
Thrown when a validation error occurs.