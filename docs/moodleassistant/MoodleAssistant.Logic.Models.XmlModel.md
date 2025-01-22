#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Models](MoodleAssistant.Logic.Models.md 'MoodleAssistant.Logic.Models')

## XmlModel Class

Manages the validation of a XML template file and its parameters.

```csharp
public class XmlModel : MoodleAssistant.Logic.Models.ValidationModel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ValidationModel](MoodleAssistant.Logic.Models.ValidationModel.md 'MoodleAssistant.Logic.Models.ValidationModel') &#129106; XmlModel

| Constructors | |
| :--- | :--- |
| [XmlModel(IBrowserFile, IBrowserFileService)](MoodleAssistant.Logic.Models.XmlModel.XmlModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile,MoodleAssistant.Services.IBrowserFileService).md 'MoodleAssistant.Logic.Models.XmlModel.XmlModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile, MoodleAssistant.Services.IBrowserFileService)') | Manages the validation of a XML template file and its parameters. |

| Fields | |
| :--- | :--- |
| [Pattern](MoodleAssistant.Logic.Models.XmlModel.Pattern.md 'MoodleAssistant.Logic.Models.XmlModel.Pattern') | The pattern to match the parameters in the XML file. |

| Properties | |
| :--- | :--- |
| [AnswerCount](MoodleAssistant.Logic.Models.XmlModel.AnswerCount.md 'MoodleAssistant.Logic.Models.XmlModel.AnswerCount') | Gets the number of answers in the XML file. |
| [AnswerParametersList](MoodleAssistant.Logic.Models.XmlModel.AnswerParametersList.md 'MoodleAssistant.Logic.Models.XmlModel.AnswerParametersList') | Gets the parameters found in the answers. |
| [FileName](MoodleAssistant.Logic.Models.XmlModel.FileName.md 'MoodleAssistant.Logic.Models.XmlModel.FileName') | The standard name of the XML file managed by the [XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel'). |
| [QuestionParametersList](MoodleAssistant.Logic.Models.XmlModel.QuestionParametersList.md 'MoodleAssistant.Logic.Models.XmlModel.QuestionParametersList') | Gets the parameters found in the question text. |
| [XmlFile](MoodleAssistant.Logic.Models.XmlModel.XmlFile.md 'MoodleAssistant.Logic.Models.XmlModel.XmlFile') | Gets the XML template document. |

| Methods | |
| :--- | :--- |
| [GetParametersFromXmlNode(XmlNode)](MoodleAssistant.Logic.Models.XmlModel.GetParametersFromXmlNode(System.Xml.XmlNode).md 'MoodleAssistant.Logic.Models.XmlModel.GetParametersFromXmlNode(System.Xml.XmlNode)') | Gets the parameters from a XML node. |
| [HasOnlyOneQuestion()](MoodleAssistant.Logic.Models.XmlModel.HasOnlyOneQuestion().md 'MoodleAssistant.Logic.Models.XmlModel.HasOnlyOneQuestion()') | Checks if the file with the [XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel')'s file name has only one question tag. |
| [HasQuestionText()](MoodleAssistant.Logic.Models.XmlModel.HasQuestionText().md 'MoodleAssistant.Logic.Models.XmlModel.HasQuestionText()') | Checks if the file with the [XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel')'s file name has a question text. |
| [IsWellFormattedXml()](MoodleAssistant.Logic.Models.XmlModel.IsWellFormattedXml().md 'MoodleAssistant.Logic.Models.XmlModel.IsWellFormattedXml()') | Checks if the file with the [XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel')'s file name is well formatted XML. |
| [IsXml(IBrowserFile)](MoodleAssistant.Logic.Models.XmlModel.IsXml(Microsoft.AspNetCore.Components.Forms.IBrowserFile).md 'MoodleAssistant.Logic.Models.XmlModel.IsXml(Microsoft.AspNetCore.Components.Forms.IBrowserFile)') | Checks if the [Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType 'Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType') of a file is XML. |
| [TakeParameters()](MoodleAssistant.Logic.Models.XmlModel.TakeParameters().md 'MoodleAssistant.Logic.Models.XmlModel.TakeParameters()') | Gets the parameters from the XML file and puts them in the [QuestionParametersList](MoodleAssistant.Logic.Models.XmlModel.QuestionParametersList.md 'MoodleAssistant.Logic.Models.XmlModel.QuestionParametersList') and [AnswerParametersList](MoodleAssistant.Logic.Models.XmlModel.AnswerParametersList.md 'MoodleAssistant.Logic.Models.XmlModel.AnswerParametersList'). |
