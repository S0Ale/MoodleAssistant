# FileModel `Public class`

## Description
Manage the validation of a uploaded file.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MoodleAssistant.Logic.Models
  MoodleAssistant.Logic.Models.FileModel[[FileModel]]
  MoodleAssistant.Logic.Models.ValidationModel[[ValidationModel]]
  end
MoodleAssistant.Logic.Models.ValidationModel --> MoodleAssistant.Logic.Models.FileModel
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `bool` | [`IsImage`](#isimage)(`IBrowserFile` file)<br>Checks if the IBrowserFile.ContentType of a file is an image. |
| `bool` | [`IsOfficeFile`](#isofficefile)(`IBrowserFile` file)<br>Checks if the IBrowserFile.ContentType of a file is a Microsoft Office file. |

## Details
### Summary
Manage the validation of a uploaded file.

### Inheritance
 - [
`ValidationModel`
](./ValidationModel.md)

### Constructors
#### FileModel
[*Source code*](https://github.com///blob//MoodleAssistant/Logic/Models/FileModel.cs#L11)
```csharp
public FileModel(IBrowserFile file)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `IBrowserFile` | file | The instance of IBrowserFile representing the file to validate. |

##### Summary
Manage the validation of a uploaded file.

### Methods
#### IsImage
[*Source code*](https://github.com///blob//MoodleAssistant/Logic/Models/FileModel.cs#L57)
```csharp
public bool IsImage(IBrowserFile file)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `IBrowserFile` | file | An instance of IBrowserFile representing the file. |

##### Summary
Checks if the IBrowserFile.ContentType of a file is an image.

##### Returns
if the file is an image; otherwise .

#### IsOfficeFile
[*Source code*](https://github.com///blob//MoodleAssistant/Logic/Models/FileModel.cs#L66)
```csharp
public bool IsOfficeFile(IBrowserFile file)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `IBrowserFile` | file | An instance of IBrowserFile representing the file. |

##### Summary
Checks if the IBrowserFile.ContentType of a file is a Microsoft Office file.

##### Returns
if the file is a MS Office file; otherwise .

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
