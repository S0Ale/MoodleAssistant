#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Parse](MoodleAssistant.Logic.Parse.md 'MoodleAssistant.Logic.Parse')

## Parameter Class

Represents a parameter in a template question.

```csharp
public class Parameter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Parameter

Derived  
&#8627; [FileParameter](MoodleAssistant.Logic.Parse.FileParameter.md 'MoodleAssistant.Logic.Parse.FileParameter')

| Constructors | |
| :--- | :--- |
| [Parameter(Match, string)](MoodleAssistant.Logic.Parse.Parameter.Parameter(System.Text.RegularExpressions.Match,string).md 'MoodleAssistant.Logic.Parse.Parameter.Parameter(System.Text.RegularExpressions.Match, string)') | Initializes a new instance of the [Parameter](MoodleAssistant.Logic.Parse.Parameter.md 'MoodleAssistant.Logic.Parse.Parameter') class with the specified match and name. |
| [Parameter(Match)](MoodleAssistant.Logic.Parse.Parameter.Parameter(System.Text.RegularExpressions.Match).md 'MoodleAssistant.Logic.Parse.Parameter.Parameter(System.Text.RegularExpressions.Match)') | Represents a parameter in a template question. |

| Properties | |
| :--- | :--- |
| [Match](MoodleAssistant.Logic.Parse.Parameter.Match.md 'MoodleAssistant.Logic.Parse.Parameter.Match') | Gets the match object containing the regex match information. |
| [Name](MoodleAssistant.Logic.Parse.Parameter.Name.md 'MoodleAssistant.Logic.Parse.Parameter.Name') | Gets or sets the name of the parameter. |
| [Replacement](MoodleAssistant.Logic.Parse.Parameter.Replacement.md 'MoodleAssistant.Logic.Parse.Parameter.Replacement') | Gets or sets the replacement value for the parameter. |

| Methods | |
| :--- | :--- |
| [Replace(StringBuilder)](MoodleAssistant.Logic.Parse.Parameter.Replace(System.Text.StringBuilder).md 'MoodleAssistant.Logic.Parse.Parameter.Replace(System.Text.StringBuilder)') | Replaces the matched text in the provided [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder') with a replacement value. |
