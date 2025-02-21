#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Utils](MoodleAssistant.Logic.Utils.md 'MoodleAssistant.Logic.Utils').[FormatExtension](MoodleAssistant.Logic.Utils.FormatExtension.md 'MoodleAssistant.Logic.Utils.FormatExtension')

## FormatExtension.GetExtension(Format) Method

Returns the extension of the specified format.

```csharp
public static string GetExtension(MoodleAssistant.Logic.Utils.Format format);
```
#### Parameters

<a name='MoodleAssistant.Logic.Utils.FormatExtension.GetExtension(MoodleAssistant.Logic.Utils.Format).format'></a>

`format` [Format](MoodleAssistant.Logic.Utils.Format.md 'MoodleAssistant.Logic.Utils.Format')

The specified [Format](MoodleAssistant.Logic.Utils.Format.md 'MoodleAssistant.Logic.Utils.Format').

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The extension of the specified [Format](MoodleAssistant.Logic.Utils.Format.md 'MoodleAssistant.Logic.Utils.Format').

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when the specified format is not present.