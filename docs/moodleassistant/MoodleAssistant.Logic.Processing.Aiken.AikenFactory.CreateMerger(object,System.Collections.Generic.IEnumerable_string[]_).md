#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Processing.Aiken](MoodleAssistant.Logic.Processing.Aiken.md 'MoodleAssistant.Logic.Processing.Aiken').[AikenFactory](MoodleAssistant.Logic.Processing.Aiken.AikenFactory.md 'MoodleAssistant.Logic.Processing.Aiken.AikenFactory')

## AikenFactory.CreateMerger(object, IEnumerable<string[]>) Method

Creates a new instance of [IMerger](MoodleAssistant.Logic.Processing.IMerger.md 'MoodleAssistant.Logic.Processing.IMerger').

```csharp
public MoodleAssistant.Logic.Processing.IMerger CreateMerger(object template, System.Collections.Generic.IEnumerable<string[]> csvAsList);
```
#### Parameters

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateMerger(object,System.Collections.Generic.IEnumerable_string[]_).template'></a>

`template` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The template document.

<a name='MoodleAssistant.Logic.Processing.Aiken.AikenFactory.CreateMerger(object,System.Collections.Generic.IEnumerable_string[]_).csvAsList'></a>

`csvAsList` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The csv file contained in a [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

Implements [CreateMerger(object, IEnumerable&lt;string[]&gt;)](MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateMerger(object,System.Collections.Generic.IEnumerable_string[]_).md 'MoodleAssistant.Logic.Processing.IReplicatorFactory.CreateMerger(object, System.Collections.Generic.IEnumerable<string[]>)')

#### Returns
[IMerger](MoodleAssistant.Logic.Processing.IMerger.md 'MoodleAssistant.Logic.Processing.IMerger')  
An instance of [IMerger](MoodleAssistant.Logic.Processing.IMerger.md 'MoodleAssistant.Logic.Processing.IMerger').