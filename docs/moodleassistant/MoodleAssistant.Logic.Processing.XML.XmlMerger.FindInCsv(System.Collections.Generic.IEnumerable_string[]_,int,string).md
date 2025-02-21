#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.XML](MoodleAssistant.Logic.Processing.XML.md 'MoodleAssistant.Logic.Processing.XML').[XmlMerger](MoodleAssistant.Logic.Processing.XML.XmlMerger.md 'MoodleAssistant.Logic.Processing.XML.XmlMerger')

## XmlMerger.FindInCsv(IEnumerable<string[]>, int, string) Method

Finds the value of a parameter in the CSV file.

```csharp
private static string FindInCsv(System.Collections.Generic.IEnumerable<string[]> csv, int i, string paramName);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.FindInCsv(System.Collections.Generic.IEnumerable_string[]_,int,string).csv'></a>

`csv` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The contents of the csv file.

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.FindInCsv(System.Collections.Generic.IEnumerable_string[]_,int,string).i'></a>

`i` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of the corresponding csv line.

<a name='MoodleAssistant.Logic.Processing.XML.XmlMerger.FindInCsv(System.Collections.Generic.IEnumerable_string[]_,int,string).paramName'></a>

`paramName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the parameter.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The value associated with the specified parameter name.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Parameter name is not present in the csv.