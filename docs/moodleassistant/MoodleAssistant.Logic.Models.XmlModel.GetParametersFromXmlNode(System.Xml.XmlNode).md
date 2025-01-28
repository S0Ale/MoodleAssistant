#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Models](MoodleAssistant.Logic.Models.md 'MoodleAssistant.Logic.Models').[XmlModel](MoodleAssistant.Logic.Models.XmlModel.md 'MoodleAssistant.Logic.Models.XmlModel')

## XmlModel.GetParametersFromXmlNode(XmlNode) Method

Gets the parameters from a XML node.

```csharp
private static System.Collections.Generic.List<string> GetParametersFromXmlNode(System.Xml.XmlNode textNode);
```
#### Parameters

<a name='MoodleAssistant.Logic.Models.XmlModel.GetParametersFromXmlNode(System.Xml.XmlNode).textNode'></a>

`textNode` [System.Xml.XmlNode](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlNode 'System.Xml.XmlNode')

An instance of [System.Xml.XmlNode](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlNode 'System.Xml.XmlNode')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
The list of parameters contained into the node.