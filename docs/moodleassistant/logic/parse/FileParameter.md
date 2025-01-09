# FileParameter `Public class`

## Description
Represents a file-type parameter in a template question.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MoodleAssistant.Logic.Parse
  MoodleAssistant.Logic.Parse.FileParameter[[FileParameter]]
  MoodleAssistant.Logic.Parse.Parameter[[Parameter]]
  end
MoodleAssistant.Logic.Parse.Parameter --> MoodleAssistant.Logic.Parse.FileParameter
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `StringBuilder` | [`Replace`](#replace)(`StringBuilder` builder)<br>Replaces the matched text in the provided StringBuilder with a replacement value. |

## Details
### Summary
Represents a file-type parameter in a template question.

### Inheritance
 - [
`Parameter`
](./Parameter.md)

### Constructors
#### FileParameter
[*Source code*](https://github.com///blob//MoodleAssistant/Logic/Parse/FileParameter.cs#L14)
```csharp
public FileParameter(Match m)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `Match` | m | The Match object containing the regex match information. |

##### Summary
Initializes a new instance of the [FileParameter](moodleassistant/logic/parse/FileParameter.md) class.

### Methods
#### Replace
[*Source code*](https://github.com///blob//MoodleAssistant/Logic/Parse/FileParameter.cs#L19)
```csharp
public override StringBuilder Replace(StringBuilder builder)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `StringBuilder` | builder | The StringBuilder containing the text to be replaced. |

##### Summary
Replaces the matched text in the provided StringBuilder with a replacement value.

##### Returns
The modified StringBuilder with the replacement text.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)