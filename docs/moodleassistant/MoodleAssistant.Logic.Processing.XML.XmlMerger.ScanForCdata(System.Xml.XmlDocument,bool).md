#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.XML](MoodleAssistant.Logic.Processing.XML.md 'MoodleAssistant.Logic.Processing.XML').[XmlMerger](MoodleAssistant.Logic.Processing.XML.XmlMerger.md 'MoodleAssistant.Logic.Processing.XML.XmlMerger')

## XmlMerger.ScanForCdata(XmlDocument, bool) Method

Scans the template question for nodes that contain text and a file parameter, and creates a CDATA section if not found.  
If the preview mode flag is set to false, the function will create a CDATA node for all parameter nodes.

```csharp
private static System.Collections.Generic.List<System.Xml.XmlNode> ScanForCdata(System.Xml.XmlDocument doc, bool previewMode=false);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.ScanForCdata(System.Xml.XmlDocument,bool).doc'></a>

`doc` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

The [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument') instance representing the template question.

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.ScanForCdata(System.Xml.XmlDocument,bool).previewMode'></a>

`previewMode` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the merge process is executing in preview mode or not.

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Xml.XmlNode](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlNode 'System.Xml.XmlNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
A list of [System.Xml.XmlNode](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlNode 'System.Xml.XmlNode') instances containing at least one file parameter.