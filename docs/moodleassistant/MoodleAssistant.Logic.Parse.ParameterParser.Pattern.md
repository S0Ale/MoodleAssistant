#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Parse](MoodleAssistant.Logic.Parse.md 'MoodleAssistant.Logic.Parse').[ParameterParser](MoodleAssistant.Logic.Parse.ParameterParser.md 'MoodleAssistant.Logic.Parse.ParameterParser')

## ParameterParser.Pattern Field

The pattern used to match parameters in the string.

```csharp
private const string Pattern = \[\*\[\[((?!FILE-|IMAGE-)[^\]*\]]+?)\]\]\*\]|\[\*\[\[FILE-([^\]*\]]+?)\]\]\*\]|\[\*\[\[IMAGE-([^\]*\]]+?)\]\]\*\];
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')