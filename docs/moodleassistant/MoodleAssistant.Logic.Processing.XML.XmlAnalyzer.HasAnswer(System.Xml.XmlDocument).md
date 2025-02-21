#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.XML](MoodleAssistant.Logic.Processing.XML.md 'MoodleAssistant.Logic.Processing.XML').[XmlAnalyzer](MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.md 'MoodleAssistant.Logic.Processing.XML.XmlAnalyzer')

## XmlAnalyzer.HasAnswer(XmlDocument) Method

Checks if the XML file has at least one answer.

```csharp
private bool HasAnswer(System.Xml.XmlDocument file);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.HasAnswer(System.Xml.XmlDocument).file'></a>

`file` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

The XML file.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if one or more answers are present; otherwise `false`.