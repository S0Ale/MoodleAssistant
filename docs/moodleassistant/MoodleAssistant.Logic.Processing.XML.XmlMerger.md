#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.XML](MoodleAssistant.Logic.Processing.XML.md 'MoodleAssistant.Logic.Processing.XML')

## XmlMerger Class

Represents a class that merges the template XML file with the CSV file to create a new XML file.

```csharp
public class XmlMerger :
MoodleAssistant.Logic.Processing.IMerger
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; XmlMerger

Implements [IMerger](MoodleAssistant.Logic.Processing.IMerger.md 'MoodleAssistant.Logic.Processing.IMerger')

| Constructors | |
| :--- | :--- |
| [XmlMerger(IBrowserFileService, XmlDocument, IEnumerable&lt;string[]&gt;)](MoodleAssistant.Logic.Processing.XML.XmlMerger.XmlMerger(MoodleAssistant.Services.IBrowserFileService,System.Xml.XmlDocument,System.Collections.Generic.IEnumerable_string[]_).md 'MoodleAssistant.Logic.Processing.XML.XmlMerger.XmlMerger(MoodleAssistant.Services.IBrowserFileService, System.Xml.XmlDocument, System.Collections.Generic.IEnumerable<string[]>)') | Represents a class that merges the template XML file with the CSV file to create a new XML file. |

| Methods | |
| :--- | :--- |
| [CreateFileTag(XmlDocument, string)](MoodleAssistant.Logic.Processing.XML.XmlMerger.CreateFileTag(System.Xml.XmlDocument,string).md 'MoodleAssistant.Logic.Processing.XML.XmlMerger.CreateFileTag(System.Xml.XmlDocument, string)') | Creates a XML file tag with the specified name attribute. |
| [FindInCsv(IEnumerable&lt;string[]&gt;, int, string)](MoodleAssistant.Logic.Processing.XML.XmlMerger.FindInCsv(System.Collections.Generic.IEnumerable_string[]_,int,string).md 'MoodleAssistant.Logic.Processing.XML.XmlMerger.FindInCsv(System.Collections.Generic.IEnumerable<string[]>, int, string)') | Finds the value of a parameter in the CSV file. |
| [MergeQuestion(bool)](MoodleAssistant.Logic.Processing.XML.XmlMerger.MergeQuestion(bool).md 'MoodleAssistant.Logic.Processing.XML.XmlMerger.MergeQuestion(bool)') | Creates a document with the replicated questions using the template file and the CSV file to find the parameter values. |
| [PrepareFileTags(XmlDocument, List&lt;XmlNode&gt;)](MoodleAssistant.Logic.Processing.XML.XmlMerger.PrepareFileTags(System.Xml.XmlDocument,System.Collections.Generic.List_System.Xml.XmlNode_).md 'MoodleAssistant.Logic.Processing.XML.XmlMerger.PrepareFileTags(System.Xml.XmlDocument, System.Collections.Generic.List<System.Xml.XmlNode>)') | Prepares the template question by adding a file tags for each file parameter. |
| [ScanForCdata(XmlDocument, bool)](MoodleAssistant.Logic.Processing.XML.XmlMerger.ScanForCdata(System.Xml.XmlDocument,bool).md 'MoodleAssistant.Logic.Processing.XML.XmlMerger.ScanForCdata(System.Xml.XmlDocument, bool)') | Scans the template question for nodes that contain text and a file parameter, and creates a CDATA section if not found.<br/>If the preview mode flag is set to false, the function will create a CDATA node for all parameter nodes. |
