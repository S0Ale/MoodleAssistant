using AikenDoc;
using MoodleAssistant.Logic.Parse;

namespace MoodleAssistant.Logic.Processing.Aiken;

/// <summary>
/// Manager for the parameters of the Aiken document.
/// </summary>
public class AikenParameterHandler : ParameterHandler{
    
    public AikenParameterHandler(AikenDocument doc, int csvRows) : base(csvRows){
        //Param = new ParameterParser(doc.OuterXml).Match() as List<Parameter>;
    }
}