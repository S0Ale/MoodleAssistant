#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Models](MoodleAssistant.Logic.Models.md 'MoodleAssistant.Logic.Models')

## FileModel Class

Manage the validation of a uploaded file.

```csharp
public class FileModel : MoodleAssistant.Logic.Models.ValidationModel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ValidationModel](MoodleAssistant.Logic.Models.ValidationModel.md 'MoodleAssistant.Logic.Models.ValidationModel') &#129106; FileModel

| Constructors | |
| :--- | :--- |
| [FileModel(IBrowserFile)](MoodleAssistant.Logic.Models.FileModel.FileModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile).md 'MoodleAssistant.Logic.Models.FileModel.FileModel(Microsoft.AspNetCore.Components.Forms.IBrowserFile)') | Manage the validation of a uploaded file. |

| Fields | |
| :--- | :--- |
| [ImageMimeTypes](MoodleAssistant.Logic.Models.FileModel.ImageMimeTypes.md 'MoodleAssistant.Logic.Models.FileModel.ImageMimeTypes') | A list of supported image MIME types. |
| [MsMimeTypes](MoodleAssistant.Logic.Models.FileModel.MsMimeTypes.md 'MoodleAssistant.Logic.Models.FileModel.MsMimeTypes') | A list of supported Microsoft Office MIME types. |

| Methods | |
| :--- | :--- |
| [IsImage(IBrowserFile)](MoodleAssistant.Logic.Models.FileModel.IsImage(Microsoft.AspNetCore.Components.Forms.IBrowserFile).md 'MoodleAssistant.Logic.Models.FileModel.IsImage(Microsoft.AspNetCore.Components.Forms.IBrowserFile)') | Checks if the [Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType 'Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType') of a file is an image. |
| [IsOfficeFile(IBrowserFile)](MoodleAssistant.Logic.Models.FileModel.IsOfficeFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile).md 'MoodleAssistant.Logic.Models.FileModel.IsOfficeFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile)') | Checks if the [Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType 'Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType') of a file is a Microsoft Office file. |
