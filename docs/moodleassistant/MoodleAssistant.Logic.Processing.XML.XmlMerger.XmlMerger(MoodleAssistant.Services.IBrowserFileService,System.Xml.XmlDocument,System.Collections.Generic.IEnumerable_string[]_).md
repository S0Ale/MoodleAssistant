#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.XML](MoodleAssistant.Logic.Processing.XML.md 'MoodleAssistant.Logic.Processing.XML').[XmlMerger](MoodleAssistant.Logic.Processing.XML.XmlMerger.md 'MoodleAssistant.Logic.Processing.XML.XmlMerger')

## XmlMerger(IBrowserFileService, XmlDocument, IEnumerable<string[]>) Constructor

Represents a class that merges the template XML file with the CSV file to create a new XML file.

```csharp
public XmlMerger(MoodleAssistant.Services.IBrowserFileService fileService, System.Xml.XmlDocument template, System.Collections.Generic.IEnumerable<string[]> csvAsList);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.XmlMerger(MoodleAssistant.Services.IBrowserFileService,System.Xml.XmlDocument,System.Collections.Generic.IEnumerable_string[]_).fileService'></a>

`fileService` [IBrowserFileService](MoodleAssistant.Services.IBrowserFileService.md 'MoodleAssistant.Services.IBrowserFileService')

An instance of [IBrowserFileService](MoodleAssistant.Services.IBrowserFileService.md 'MoodleAssistant.Services.IBrowserFileService') to manage saved files.

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.XmlMerger(MoodleAssistant.Services.IBrowserFileService,System.Xml.XmlDocument,System.Collections.Generic.IEnumerable_string[]_).template'></a>

`template` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

The [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument') of the template question.

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.XmlMerger(MoodleAssistant.Services.IBrowserFileService,System.Xml.XmlDocument,System.Collections.Generic.IEnumerable_string[]_).csvAsList'></a>

`csvAsList` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The CSV file as a list of string arrays.