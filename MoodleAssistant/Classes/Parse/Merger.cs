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
    
    /// <summary>
    /// Searches the specified <c>question</c> node for CDATA sections and if not found, creates them
    /// and adds a file tag for each file parameter.
    /// </summary>
    /// <param name="questionNode">The XML <c>questionNode</c> node.</param>
    private void LookForCData(XmlNode questionNode){
        //get all nodes containing a file parameter
        var allNodes = questionNode.SelectNodes("//*[text()]");
        if (allNodes == null) return;
        var nodes = allNodes.Cast<XmlNode>();
        var fileNodes = nodes.Where(n =>
            n.InnerText.Contains("[*[[FILE-")
            && n.InnerText.Contains("]]*]")
        ).ToList();
        
        // for each node, replace the text with a CDATA section
        foreach (var node in fileNodes){
            AddFileTags(node); // append a file tag to its parent
            
            if (node.FirstChild is{ NodeType: XmlNodeType.CDATA }) continue;
            var cdata = _xmlDoc.CreateCDataSection(node.InnerText);
            node.RemoveAll();
            node.AppendChild(cdata);
        }
    }
    
    /// <summary>
    /// Creates a XML file tag with the specified name attribute.
    /// </summary>
    /// <param name="name">The name attribute value.</param>
    /// <returns>A new file tag with the specified name.</returns>
    private XmlElement CreateFileTag(string name){
        var tag = _xmlDoc!.CreateElement("file");
        tag.SetAttribute("name", name);
        tag.SetAttribute("path", "/");
        tag.SetAttribute("encoding", "base64");
        tag.InnerText = "";
        return tag;
    }

    /// <summary>
    /// Given a text node containing file parameters, add a file tag for each file parameter to its parent.
    /// </summary>
    /// <param name="textNode">The XML node containing file parameters.</param>
    private void AddFileTags(XmlNode textNode){
        var parser = new ParameterParser(textNode.OuterXml);
        var parameters = parser.Match() as List<Parameter>;
        var fileParams = parameters.Where(p => p is FileParameter).ToList();
        foreach (var fileParam in fileParams){
            var tag = CreateFileTag(fileParam.Name); // I can then find the correct tag later
            textNode.ParentNode?.AppendChild(tag);
        }
    }

    /// <summary>
    /// This function creates a XML file with the replicated questions using the XML file as the template and the CSV file
    /// to find the parameter values.
    /// </summary>

    // File names need to be equal to the names inside the CSV file
    // The CSV column order must be the same as the XML parameter order
    public void MergeQuestion(){
        XmlFileParamPhase();
        ReplaceParameters();

        // remove template question
        while(_xmlDoc.DocumentElement?.FirstChild?.NodeType == XmlNodeType.Comment)
            _xmlDoc.DocumentElement.RemoveChild(_xmlDoc.DocumentElement.FirstChild);
        _xmlDoc.DocumentElement?.RemoveChild(_xmlDoc.DocumentElement.FirstChild);
        state.Merged = _xmlDoc;
    }

    /// <summary>
    /// First phase of the XML file merging process. This function provides the correct values for the file tags
    /// and clones the question node for each row in the CSV file.
    /// </summary>
    private void XmlFileParamPhase(){
        var headerRow = CsvAsList.ElementAt(0); // first row contains parameter names

        for (var j = 1; j < CsvAsList.Count(); j++){
            // CDATA replace, add file tag Phase
            var xmlQuestionNode = _xmlDoc.GetElementsByTagName("question").Item(0)?.Clone(); // not appending the node to the document
            if (xmlQuestionNode == null) continue;
            LookForCData(xmlQuestionNode);

            // Tag Replace Phase
            var parser = new ParameterParser(xmlQuestionNode.InnerXml);
            var parameters = parser.Match() as List<Parameter>;
            for (var i = 0; i < headerRow.Length; i++){
                var param = parameters[i];
                if (param is FileParameter fileParam){
                    var filename = CsvAsList.ElementAt(j)[i];
                    var base64 = fileService.GetBase64(filename);
                    var tag = xmlQuestionNode.SelectSingleNode(
                        $"//file[@name='{fileParam.Name}']"); // select the correct file tag
                    tag.Attributes["name"].Value = filename;
                    tag.InnerText = base64;
                }
            }
            _xmlDoc.DocumentElement?.AppendChild(xmlQuestionNode.Clone());
        }
    }

    /// <summary>
    /// Second phase of the XML file merging process. This function replaces the parameters in the XML file with their correct values.
    /// </summary>
    private void ReplaceParameters(){
        var headerRow = CsvAsList.ElementAt(0); // first row contains parameter names
        
        var xmlQuestionNodes = _xmlDoc.GetElementsByTagName("question").Cast<XmlNode>().ToArray();
        for (var j = 1; j < CsvAsList.Count(); j++){
            var xmlQuestionNode = xmlQuestionNodes[j];

            // Get Parameters
            var parser = new ParameterParser(xmlQuestionNode.InnerXml);
            var parameters = parser.Match() as List<Parameter>;
            for (var i = 0; i < headerRow.Length; i++){
                var param = parameters[i];
                param.Replacement = CsvAsList.ElementAt(j)[i]; // put replacements for each parameter
            }
            
            xmlQuestionNode.InnerXml = parser.Replace(parameters);
        }
    }
}