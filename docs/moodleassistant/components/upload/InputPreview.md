# InputPreview `Public class`

## Description
Code-behind for the [InputPreview](moodleassistant/components/upload/InputPreview.md) component.
            Represents a preview of the uploaded file.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph MoodleAssistant.Components.Upload
  MoodleAssistant.Components.Upload.InputPreview[[InputPreview]]
  end
  subgraph Microsoft.AspNetCore.Components
Microsoft.AspNetCore.Components.ComponentBase[[ComponentBase]]
  end
Microsoft.AspNetCore.Components.ComponentBase --> MoodleAssistant.Components.Upload.InputPreview
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| `string` | [`FileName`](#filename)<br>The name of the file. | `get, set` |
| `EventCallback`&lt;`string`&gt; | [`OnClose`](#onclose)<br>Event callback for closing the preview. | `get, set` |

### Methods
#### Protected  methods
| Returns | Name |
| --- | --- |
| `void` | [`BuildRenderTree`](#buildrendertree)(`RenderTreeBuilder` __builder) |

## Details
### Summary
Code-behind for the [InputPreview](moodleassistant/components/upload/InputPreview.md) component.
            Represents a preview of the uploaded file.

### Inheritance
 - `ComponentBase`

### Constructors
#### InputPreview
```csharp
public InputPreview()
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

### Properties
#### FileName
```csharp
public string FileName { get; set; }
```
##### Summary
The name of the file.

#### OnClose
```csharp
public EventCallback<string> OnClose { get; set; }
```
##### Summary
Event callback for closing the preview.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
