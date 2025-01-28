#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic](MoodleAssistant.Logic.md 'MoodleAssistant.Logic').[Loader](MoodleAssistant.Logic.Loader.md 'MoodleAssistant.Logic.Loader')

## Loader.LoadXml(IBrowserFile) Method

Loads the XML file and validates it.

```csharp
public System.Threading.Tasks.Task<MoodleAssistant.Logic.Models.XmlModel> LoadXml(Microsoft.AspNetCore.Components.Forms.IBrowserFile file);
```
#### Parameters

<a name='MoodleAssistant.Logic.Loader.LoadXml(Microsoft.AspNetCore.Components.Forms.IBrowserFile).file'></a>

`file` [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')

An instance of [Microsoft.AspNetCore.Components.Forms.IBrowserFile](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile 'Microsoft.AspNetCore.Components.Forms.IBrowserFile')representing the XML file.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An instance of [XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel') to manage the file.

#### Exceptions

[ReplicatorException](MoodleAssistant.Logic.Utils.ReplicatorException.md 'MoodleAssistant.Logic.Utils.ReplicatorException')  
Thrown when a validation error occurs.