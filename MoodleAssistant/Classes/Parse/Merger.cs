using System.Xml;
using MoodleAssistant.Classes.Parse;
using MoodleAssistant.Services;

namespace MoodleAssistant.Classes.Models;

public class Merger(ReplicatorState state, FileService fileService){
    private readonly XmlDocument _xmlDoc;
    
    public XmlDocument XmlFile{
        init => _xmlDoc = value.Clone() as XmlDocument ?? new XmlDocument();
    }
    public IEnumerable<string[]> CsvAsList{ get; init; }
    
    
    private void LookForCData(){
        //get all nodes that contain a file parameter
        var allNodes = _xmlDoc.SelectNodes("//*[text()]"); // get all nodes that contain text
        if (allNodes == null) return;
        var nodes = allNodes.Cast<XmlNode>();
        var fileNodes = nodes.Where(n =>
            n.InnerText.Contains("[*[[FILE-")
            && n.InnerText.Contains("]]*]")
        ).ToList();
        
        // for each node, replace the text with a CDATA section
        foreach (var node in fileNodes){
            if (node is{ NodeType: XmlNodeType.CDATA }) continue;
            var cdata = _xmlDoc.CreateCDataSection(node.InnerText);
            node.ParentNode?.ReplaceChild(cdata, node);
        }
    }
    
    private XmlElement CreateFileTag(string name, string base64){
        var tag = _xmlDoc!.CreateElement("file");
        tag.SetAttribute("name", name);
        tag.SetAttribute("path", "/");
        tag.SetAttribute("encoding", "base64");
        tag.InnerText = base64;
        return tag;
    }
    
    // I need to look for CDATA tags in the question text
    // when I get a FileParameter:
    // 1. I have to add a file tag in the xml
    // 2. Replace - DONE the FileParameter class already does this
    public void MergeQuestion()
    {
        LookForCData();
        // create new question nodes
        var headerRow = CsvAsList.ElementAt(0); // first row contains parameter names
        for (var j = 1; j < CsvAsList.Count(); j++)
        {
            var xmlQuestionNode = _xmlDoc.GetElementsByTagName("question").Item(0)?.Clone();

            // Get Parameters
            var parser = new ParameterParser(xmlQuestionNode.InnerXml);
            var parameters = parser.Match() as List<Parameter>;
            for (var i = 0; i < headerRow.Length; i++){
                parameters[i].Replacement = CsvAsList.ElementAt(j)[i]; // put replacements for each parameter
                if(parameters[i] is FileParameter fileParam){ 
                    // add the file tag (the replacement is the file name)
                    var base64 = fileService.GetBase64(fileParam.Replacement);
                    var tag = CreateFileTag(fileParam.Replacement, base64);
                    xmlQuestionNode.AppendChild(tag);
                }
            }
            
            parser.Str = xmlQuestionNode.InnerXml; // update the string
            xmlQuestionNode.InnerXml = parser.Replace(parameters);
            _xmlDoc.DocumentElement?.AppendChild(xmlQuestionNode.Clone());
        }

        // remove template question
        while(_xmlDoc.DocumentElement?.FirstChild?.NodeType == XmlNodeType.Comment)
            _xmlDoc.DocumentElement.RemoveChild(_xmlDoc.DocumentElement.FirstChild);
        _xmlDoc.DocumentElement?.RemoveChild(_xmlDoc.DocumentElement.FirstChild);
        
        state.Merged = _xmlDoc;
    }
}