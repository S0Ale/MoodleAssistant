# Replicator `Public class`

## Description
Code-behind for the Replicator page.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MoodleAssistant.Components.Pages
  MoodleAssistant.Components.Pages.Replicator[[Replicator]]
  end
  subgraph Microsoft.AspNetCore.Components
Microsoft.AspNetCore.Components.ComponentBase[[ComponentBase]]
  end
Microsoft.AspNetCore.Components.ComponentBase --> MoodleAssistant.Components.Pages.Replicator
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| [`Error`](../../logic/utils/Error.md) | [`ErrorMsg`](#errormsg)<br>The error message of the page. | `get, private set` |
| `bool` | [`IsUploading`](#isuploading) | `get` |
| `bool` | [`ShowFileParams`](#showfileparams) | `get` |
| `bool` | [`SuccessUpload`](#successupload) | `get` |

### Methods
#### Protected  methods
| Returns | Name |
| --- | --- |
| `void` | [`BuildRenderTree`](#buildrendertree)(`RenderTreeBuilder` __builder) |

## Details
### Summary
Code-behind for the Replicator page.

### Inheritance
 - `ComponentBase`

### Constructors
#### Replicator
[*Source code*](https://github.com///blob//MoodleAssistant/Components/Pages/Replicator.razor.cs#L16)
```csharp
public Replicator()
```

### Methods
#### BuildRenderTree
[*Source code*](https://github.com///blob//MoodleAssistant/Components/Pages/Replicator.razor#L16707566)
```csharp
protected override void BuildRenderTree(RenderTreeBuilder __builder)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `RenderTreeBuilder` | __builder |   |

### Properties
#### ErrorMsg
```csharp
public Error ErrorMsg { get; private set; }
```
##### Summary
The error message of the page.

#### SuccessUpload
```csharp
public bool SuccessUpload { get; }
```

#### IsUploading
```csharp
public bool IsUploading { get; }
```

#### ShowFileParams
```csharp
public bool ShowFileParams { get; }
```

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
