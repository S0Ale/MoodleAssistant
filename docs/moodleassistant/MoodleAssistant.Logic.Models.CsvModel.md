#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Models](MoodleAssistant.Logic.Models.md 'MoodleAssistant.Logic.Models')

## CsvModel Class

Manages the validation of a CSV file and other operations.

```csharp
public class CsvModel :
MoodleAssistant.Logic.Models.IValidationModel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CsvModel

Implements [IValidationModel](MoodleAssistant.Logic.Models.IValidationModel.md 'MoodleAssistant.Logic.Models.IValidationModel')

| Constructors | |
| :--- | :--- |
| [CsvModel(IBrowserFile, IBrowserFileService)](MoodleAssistant.Logic.Models.CsvModel.CsvModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile,MoodleAssistant.Services.IBrowserFileService).md 'MoodleAssistant.Logic.Models.CsvModel.CsvModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile, MoodleAssistant.Services.IBrowserFileService)') | Manages the validation of a CSV file and other operations. |

| Fields | |
| :--- | :--- |
| [MimeTypes](MoodleAssistant.Logic.Models.CsvModel.MimeTypes.md 'MoodleAssistant.Logic.Models.CsvModel.MimeTypes') | A list of supported CSV MIME types. |

| Properties | |
| :--- | :--- |
| [AnswersParametersList](MoodleAssistant.Logic.Models.CsvModel.AnswersParametersList.md 'MoodleAssistant.Logic.Models.CsvModel.AnswersParametersList') | Gets the parameters found in the answers. |
| [FileName](MoodleAssistant.Logic.Models.CsvModel.FileName.md 'MoodleAssistant.Logic.Models.CsvModel.FileName') | The standard name of the XML file managed by the [CsvModel](MoodleAssistant.Logic.Models.CsvModel.md 'MoodleAssistant.Logic.Models.CsvModel'). |
| [QuestionParametersList](MoodleAssistant.Logic.Models.CsvModel.QuestionParametersList.md 'MoodleAssistant.Logic.Models.CsvModel.QuestionParametersList') | Gets the parameters found in the question text |

| Methods | |
| :--- | :--- |
| [ConvertCsvToListOfArrayString()](MoodleAssistant.Logic.Models.CsvModel.ConvertCsvToListOfArrayString().md 'MoodleAssistant.Logic.Models.CsvModel.ConvertCsvToListOfArrayString()') | Converts the CSV file to a list of string arrays. |
| [HasValidHeader()](MoodleAssistant.Logic.Models.CsvModel.HasValidHeader().md 'MoodleAssistant.Logic.Models.CsvModel.HasValidHeader()') | Checks if the file with the [CsvModel](MoodleAssistant.Logic.Models.CsvModel.md 'MoodleAssistant.Logic.Models.CsvModel')'s file name has a valid header. |
| [IsCsv(IBrowserFile)](MoodleAssistant.Logic.Models.CsvModel.IsCsv(Microsoft.AspNetCore.Components.Forms.IBrowserFile).md 'MoodleAssistant.Logic.Models.CsvModel.IsCsv(Microsoft.AspNetCore.Components.Forms.IBrowserFile)') | Checks if the [Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType 'Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType') of a file is CSV. |
| [IsWellFormed()](MoodleAssistant.Logic.Models.CsvModel.IsWellFormed().md 'MoodleAssistant.Logic.Models.CsvModel.IsWellFormed()') | Checks if the file with the [CsvModel](MoodleAssistant.Logic.Models.CsvModel.md 'MoodleAssistant.Logic.Models.CsvModel')'s file name is well-formed. |
| [Validate()](MoodleAssistant.Logic.Models.CsvModel.Validate().md 'MoodleAssistant.Logic.Models.CsvModel.Validate()') | Validates the file contained in the model. |
