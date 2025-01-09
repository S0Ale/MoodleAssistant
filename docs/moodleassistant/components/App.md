# App `Public class`

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MoodleAssistant.Components
  MoodleAssistant.Components.App[[App]]
  end
  subgraph Microsoft.AspNetCore.Components
Microsoft.AspNetCore.Components.ComponentBase[[ComponentBase]]
  end
Microsoft.AspNetCore.Components.ComponentBase --> MoodleAssistant.Components.App
```

## Members
### Methods
#### Protected  methods
| Returns | Name |
| --- | --- |
| `void` | [`BuildRenderTree`](#buildrendertree)(`RenderTreeBuilder` __builder) |

## Details
### Inheritance
 - `ComponentBase`

### Constructors
#### App
```csharp
public App()
```

### Methods
#### BuildRenderTree
```csharp
protected override void BuildRenderTree(RenderTreeBuilder __builder)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `RenderTreeBuilder` | __builder |   |

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
