#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Services](MoodleAssistant.Services.md 'MoodleAssistant.Services').[FileService](MoodleAssistant.Services.FileService.md 'MoodleAssistant.Services.FileService')

## FileService.SaveFile(XmlDocument) Method

Saves the specified [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument').

```csharp
public System.Threading.Tasks.Task<bool> SaveFile(System.Xml.XmlDocument doc);
```
#### Parameters

<a name='MoodleAssistant.Services.FileService.SaveFile(System.Xml.XmlDocument).doc'></a>

`doc` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

The [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument') to save.

Implements [SaveFile(XmlDocument)](MoodleAssistant.Services.IBrowserFileService.SaveFile(System.Xml.XmlDocument).md 'MoodleAssistant.Services.IBrowserFileService.SaveFile(System.Xml.XmlDocument)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
`true` if the operation is successful; otherwise `false`.