# MainLayout `Public class`

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MoodleAssistant.Components.Layout
  MoodleAssistant.Components.Layout.MainLayout[[MainLayout]]
  end
  subgraph Microsoft.AspNetCore.Components
Microsoft.AspNetCore.Components.LayoutComponentBase[[LayoutComponentBase]]
  end
Microsoft.AspNetCore.Components.LayoutComponentBase --> MoodleAssistant.Components.Layout.MainLayout
```

## Members
### Methods
#### Protected  methods
| Returns | Name |
| --- | --- |
| `void` | [`BuildRenderTree`](#buildrendertree)(`RenderTreeBuilder` __builder) |

## Details
### Inheritance
 - `LayoutComponentBase`

### Constructors
#### MainLayout
```csharp
public MainLayout()
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