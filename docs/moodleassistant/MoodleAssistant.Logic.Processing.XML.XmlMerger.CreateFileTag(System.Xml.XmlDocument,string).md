#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.XML](MoodleAssistant.Logic.Processing.XML.md 'MoodleAssistant.Logic.Processing.XML').[XmlMerger](MoodleAssistant.Logic.Processing.XML.XmlMerger.md 'MoodleAssistant.Logic.Processing.XML.XmlMerger')

## XmlMerger.CreateFileTag(XmlDocument, string) Method

Creates a XML file tag with the specified name attribute.

```csharp
private static System.Xml.XmlElement CreateFileTag(System.Xml.XmlDocument doc, string name);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.CreateFileTag(System.Xml.XmlDocument,string).doc'></a>

`doc` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

The [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument') instance you are working on.

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.CreateFileTag(System.Xml.XmlDocument,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name attribute value.

#### Returns
[System.Xml.XmlElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlElement 'System.Xml.XmlElement')  
A new [System.Xml.XmlElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlElement 'System.Xml.XmlElement') instance, representing the file tag with the specified name.