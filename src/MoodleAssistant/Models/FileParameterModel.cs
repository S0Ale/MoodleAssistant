using System.Collections.Generic;
using System.Linq;
using System.Xml;
using MoodleAssistant.Parse;

namespace MoodleAssistant.Models;

public class FileParameterModel(XmlDocument doc){
    private List<Parameter> _param = new ParameterParser(doc.OuterXml).Match() as List<Parameter>;

    public List<Parameter> GetFileParameters(){
        var fileParams = _param.Where(p => p is FileParameter).ToList();
        return fileParams;
    }
    
}