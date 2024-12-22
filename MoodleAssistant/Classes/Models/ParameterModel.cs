using System.Xml;
using MoodleAssistant.Classes.Parse;

namespace MoodleAssistant.Classes.Models;

public class ParameterModel(XmlDocument doc, int csvRows){
    private readonly List<Parameter>? _param = new ParameterParser(doc.OuterXml).Match() as List<Parameter>;
    public int NeededFiles{ get; init; } = csvRows;

    public List<Parameter> GetFileParameters(){
        var fileParams = (_param ?? []).Where(p => p is FileParameter or ImageParameter).ToList();
        return fileParams;
    }
}