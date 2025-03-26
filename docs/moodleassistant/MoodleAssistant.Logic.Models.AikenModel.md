#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Models](MoodleAssistant.Logic.Models.md 'MoodleAssistant.Logic.Models')

## AikenModel Class

Manages the validation of a Aiken template file and its parameters.

```csharp
public class AikenModel :
MoodleAssistant.Logic.Models.ITemplateModel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AikenModel

Implements [ITemplateModel](MoodleAssistant.Logic.Models.ITemplateModel.md 'MoodleAssistant.Logic.Models.ITemplateModel')

| Constructors | |
| :--- | :--- |
| [AikenModel(IBrowserFile, IBrowserFileService)](MoodleAssistant.Logic.Models.AikenModel.AikenModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile,MoodleAssistant.Services.IBrowserFileService).md 'MoodleAssistant.Logic.Models.AikenModel.AikenModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile, MoodleAssistant.Services.IBrowserFileService)') | Manages the validation of a Aiken template file and its parameters. |

| Fields | |
| :--- | :--- |
| [_aikenFile](MoodleAssistant.Logic.Models.AikenModel._aikenFile.md 'MoodleAssistant.Logic.Models.AikenModel._aikenFile') | Gets the Aiken template document. |

| Properties | |
| :--- | :--- |
| [AnswerParametersList](MoodleAssistant.Logic.Models.AikenModel.AnswerParametersList.md 'MoodleAssistant.Logic.Models.AikenModel.AnswerParametersList') | Gets the parameters found in the answers. |
| [QuestionParametersList](MoodleAssistant.Logic.Models.AikenModel.QuestionParametersList.md 'MoodleAssistant.Logic.Models.AikenModel.QuestionParametersList') | Gets the parameters found in the question text. |
| [TemplateDocument](MoodleAssistant.Logic.Models.AikenModel.TemplateDocument.md 'MoodleAssistant.Logic.Models.AikenModel.TemplateDocument') | Gets the template document. |

| Methods | |
| :--- | :--- |
| [AnswerHasOnlyOneParameter()](MoodleAssistant.Logic.Models.AikenModel.AnswerHasOnlyOneParameter().md 'MoodleAssistant.Logic.Models.AikenModel.AnswerHasOnlyOneParameter()') | Checks if the correct section of the Aiken file has only one parameter. |
| [GetParametersFromAikenElement(AikenElement)](MoodleAssistant.Logic.Models.AikenModel.GetParametersFromAikenElement(AikenDoc.AikenElement).md 'MoodleAssistant.Logic.Models.AikenModel.GetParametersFromAikenElement(AikenDoc.AikenElement)') | Gets the parameters from an Aiken element. |
| [HasFileParameters()](MoodleAssistant.Logic.Models.AikenModel.HasFileParameters().md 'MoodleAssistant.Logic.Models.AikenModel.HasFileParameters()') | Checks if the Aiken file has at least one file parameter. |
| [HasOnlyOneQuestion()](MoodleAssistant.Logic.Models.AikenModel.HasOnlyOneQuestion().md 'MoodleAssistant.Logic.Models.AikenModel.HasOnlyOneQuestion()') | Checks if the Aiken file has only one question. |
| [IsText(IBrowserFile)](MoodleAssistant.Logic.Models.AikenModel.IsText(Microsoft.AspNetCore.Components.Forms.IBrowserFile).md 'MoodleAssistant.Logic.Models.AikenModel.IsText(Microsoft.AspNetCore.Components.Forms.IBrowserFile)') | Checks if the [Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType 'Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType') of a file is plain text. |
| [IsWellFormattedAiken()](MoodleAssistant.Logic.Models.AikenModel.IsWellFormattedAiken().md 'MoodleAssistant.Logic.Models.AikenModel.IsWellFormattedAiken()') | Checks if the file with the [AikenModel](MoodleAssistant.Logic.Models.AikenModel.md 'MoodleAssistant.Logic.Models.AikenModel')'s file name is well formatted Aiken. |
| [TakeParameters()](MoodleAssistant.Logic.Models.AikenModel.TakeParameters().md 'MoodleAssistant.Logic.Models.AikenModel.TakeParameters()') | Gets the parameters from the template file and puts them in the [QuestionParametersList](MoodleAssistant.Logic.Models.ITemplateModel.QuestionParametersList.md 'MoodleAssistant.Logic.Models.ITemplateModel.QuestionParametersList') and [AnswerParametersList](MoodleAssistant.Logic.Models.ITemplateModel.AnswerParametersList.md 'MoodleAssistant.Logic.Models.ITemplateModel.AnswerParametersList'). |
| [Validate()](MoodleAssistant.Logic.Models.AikenModel.Validate().md 'MoodleAssistant.Logic.Models.AikenModel.Validate()') | Validates the template file contained in the model. |
