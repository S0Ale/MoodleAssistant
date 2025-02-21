#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.XML](MoodleAssistant.Logic.Processing.XML.md 'MoodleAssistant.Logic.Processing.XML')

## XmlAnalyzer Class

Analyzes a template question document in XML format.

```csharp
public class XmlAnalyzer :
MoodleAssistant.Logic.Processing.IAnalyzer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; XmlAnalyzer

Implements [IAnalyzer](MoodleAssistant.Logic.Processing.IAnalyzer.md 'MoodleAssistant.Logic.Processing.IAnalyzer')

| Fields | |
| :--- | :--- |
| [Pattern](MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.Pattern.md 'MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.Pattern') | The parameters' regex pattern. |

| Methods | |
| :--- | :--- |
| [GetFormattedAnswers(object)](MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.GetFormattedAnswers(object).md 'MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.GetFormattedAnswers(object)') | Gets the HTML formatted answers from the document. |
| [GetFormattedQuestionText(object)](MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.GetFormattedQuestionText(object).md 'MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.GetFormattedQuestionText(object)') | Gets the HTML formatted question text from the document. |
| [HasAnswer(XmlDocument)](MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.HasAnswer(System.Xml.XmlDocument).md 'MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.HasAnswer(System.Xml.XmlDocument)') | Checks if the XML file has at least one answer. |
| [HasQuestionText(XmlDocument)](MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.HasQuestionText(System.Xml.XmlDocument).md 'MoodleAssistant.Logic.Processing.XML.XmlAnalyzer.HasQuestionText(System.Xml.XmlDocument)') | Checks if the XML file has a question text. |
