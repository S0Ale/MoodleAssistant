#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic](MoodleAssistant.Logic.md 'MoodleAssistant.Logic').[Merger](MoodleAssistant.Logic.Merger.md 'MoodleAssistant.Logic.Merger')

## Merger.MergeQuestion(bool) Method

This function creates a XML file with the replicated questions using the XML file as the template and the CSV file  
to find the parameter values.

```csharp
public System.Xml.XmlDocument MergeQuestion(bool previewMode=false);
```
#### Parameters

<a name='MoodleAssistant.Logic.Merger.MergeQuestion(bool).previewMode'></a>

`previewMode` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the merge process is executing in preview mode or not.

#### Returns
[System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')  
The merged [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument').