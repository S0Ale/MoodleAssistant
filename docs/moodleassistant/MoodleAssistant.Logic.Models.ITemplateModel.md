#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Models](MoodleAssistant.Logic.Models.md 'MoodleAssistant.Logic.Models')

## ITemplateModel Interface

Manages the validation process of the template question.

```csharp
public interface ITemplateModel
```

Derived  
&#8627; [AikenModel](MoodleAssistant.Logic.Models.AikenModel.md 'MoodleAssistant.Logic.Models.AikenModel')  
&#8627; [XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel')

| Properties | |
| :--- | :--- |
| [AnswerParametersList](MoodleAssistant.Logic.Models.ITemplateModel.AnswerParametersList.md 'MoodleAssistant.Logic.Models.ITemplateModel.AnswerParametersList') | Gets the parameters found in the answers. |
| [QuestionParametersList](MoodleAssistant.Logic.Models.ITemplateModel.QuestionParametersList.md 'MoodleAssistant.Logic.Models.ITemplateModel.QuestionParametersList') | Gets the parameters found in the question text. |
| [TemplateDocument](MoodleAssistant.Logic.Models.ITemplateModel.TemplateDocument.md 'MoodleAssistant.Logic.Models.ITemplateModel.TemplateDocument') | Gets the template document. |

| Methods | |
| :--- | :--- |
| [TakeParameters()](MoodleAssistant.Logic.Models.ITemplateModel.TakeParameters().md 'MoodleAssistant.Logic.Models.ITemplateModel.TakeParameters()') | Gets the parameters from the template file and puts them in the [QuestionParametersList](MoodleAssistant.Logic.Models.ITemplateModel.QuestionParametersList.md 'MoodleAssistant.Logic.Models.ITemplateModel.QuestionParametersList') and [AnswerParametersList](MoodleAssistant.Logic.Models.ITemplateModel.AnswerParametersList.md 'MoodleAssistant.Logic.Models.ITemplateModel.AnswerParametersList'). |
| [Validate()](MoodleAssistant.Logic.Models.ITemplateModel.Validate().md 'MoodleAssistant.Logic.Models.ITemplateModel.Validate()') | Validates the template file contained in the model. |
