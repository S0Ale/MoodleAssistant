# ErrorPage `Public class`

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MoodleAssistant.Components.Pages
  MoodleAssistant.Components.Pages.ErrorPage[[ErrorPage]]
  end
  subgraph Microsoft.AspNetCore.Components
Microsoft.AspNetCore.Components.ComponentBase[[ComponentBase]]
  end
Microsoft.AspNetCore.Components.ComponentBase --> MoodleAssistant.Components.Pages.ErrorPage
```

## Members
### Methods
#### Protected  methods
| Returns | Name |
| --- | --- |
| `void` | [`BuildRenderTree`](#buildrendertree)(`RenderTreeBuilder` __builder) |
| `void` | [`OnInitialized`](#oninitialized)() |

## Details
### Inheritance
 - `ComponentBase`

### Constructors
#### ErrorPage
```csharp
public ErrorPage()
```

### Methods
#### BuildRenderTree
[*Source code*](https://github.com///blob//MoodleAssistant/Components/Pages/ErrorPage.razor#L16707566)
```csharp
protected override void BuildRenderTree(RenderTreeBuilder __builder)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `RenderTreeBuilder` | __builder |   |

#### OnInitialized
[*Source code*](https://github.com///blob//MoodleAssistant/Components/Pages/ErrorPage.razor#L35)
```csharp
protected override void OnInitialized()
```

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
