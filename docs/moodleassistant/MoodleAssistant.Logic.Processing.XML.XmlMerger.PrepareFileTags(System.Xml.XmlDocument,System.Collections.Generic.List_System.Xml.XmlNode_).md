#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.XML](MoodleAssistant.Logic.Processing.XML.md 'MoodleAssistant.Logic.Processing.XML').[XmlMerger](MoodleAssistant.Logic.Processing.XML.XmlMerger.md 'MoodleAssistant.Logic.Processing.XML.XmlMerger')

## XmlMerger.PrepareFileTags(XmlDocument, List<XmlNode>) Method

Prepares the template question by adding a file tags for each file parameter.

```csharp
private static void PrepareFileTags(System.Xml.XmlDocument doc, System.Collections.Generic.List<System.Xml.XmlNode> fileNodes);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.PrepareFileTags(System.Xml.XmlDocument,System.Collections.Generic.List_System.Xml.XmlNode_).doc'></a>

`doc` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

The [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument') instance representing the template question.

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.PrepareFileTags(System.Xml.XmlDocument,System.Collections.Generic.List_System.Xml.XmlNode_).fileNodes'></a>

`fileNodes` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Xml.XmlNode](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlNode 'System.Xml.XmlNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

A list of [System.Xml.XmlNode](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlNode 'System.Xml.XmlNode') instances containing at least one file parameter.