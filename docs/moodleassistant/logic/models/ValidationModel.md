# ValidationModel `Public class`

## Description


## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MoodleAssistant.Logic.Models
  MoodleAssistant.Logic.Models.ValidationModel[[ValidationModel]]
  end
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `bool` | [`IsEmpty`](#isempty)()<br>Checks if the file is empty. |

## Details
### Summary


### Constructors
#### ValidationModel
[*Source code*](https://github.com///blob//MoodleAssistant/Logic/Models/ValidationModel.cs#L16707566)
```csharp
public ValidationModel(IBrowserFile file)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `IBrowserFile` | file | The instance of IBrowserFile representing the file to validate. |

##### Summary


### Methods
#### IsEmpty
[*Source code*](https://github.com///blob//MoodleAssistant/Logic/Models/ValidationModel.cs#L14)
```csharp
public bool IsEmpty()
```
##### Summary
Checks if the file is empty.

##### Returns
`true` if the file is empty; otherwise `false`

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
