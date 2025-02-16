#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Services](MoodleAssistant.Services.md 'MoodleAssistant.Services').[IBrowserFileService](MoodleAssistant.Services.IBrowserFileService.md 'MoodleAssistant.Services.IBrowserFileService')

## IBrowserFileService.SaveFile(XmlDocument) Method

Saves the specified [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument').

```csharp
System.Threading.Tasks.Task<bool> SaveFile(System.Xml.XmlDocument doc);
```
#### Parameters

<a name='MoodleAssistant.Services.IBrowserFileService.SaveFile(System.Xml.XmlDocument).doc'></a>

`doc` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

The [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument') to save.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
`true` if the operation is successful; otherwise `false`.