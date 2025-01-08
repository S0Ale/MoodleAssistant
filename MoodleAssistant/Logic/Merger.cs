using System.Xml;
using MoodleAssistant.Logic.Parse;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic;

/// <summary>
/// Represents a class that merges the template XML file with the CSV file to create a new XML file.
/// </summary>
/// <param name="fileService">An instance of <see cref="IBrowserFileService"/> to manage saved files.</param>
public class Merger(IBrowserFileService fileService, XmlDocument template, IEnumerable<string[]> csvAsList){
    /// <summary>
    /// The XML file to be used as a template.
    /// </summary>
    private readonly XmlDocument _xmlDoc = (template.Clone() as XmlDocument)!;

    /// <summary>
    /// The CSV file to be used as a data source.
    /// </summary>
    private readonly IEnumerable<string[]> _csvAsList = csvAsList;

    /// <summary>
    /// This function creates a XML file with the replicated questions using the XML file as the template and the CSV file
    /// to find the parameter values.
    /// </summary>
    /// <param name="previewMode">Whether the merge process is executing in preview mode or not.</param>
    /// <returns>The merged <see cref="XmlDocument"/>.</returns>
    public XmlDocument MergeQuestion(bool previewMode = false){
        // File names need to be equal to the names inside the CSV file
        var merged = (_xmlDoc.Clone() as XmlDocument)!;
        
        // Prepare the template question
        // 1. Look for all the nodes that contain text and a file parameter, look for cdata sections and create them if not found
        // 2. For each file parameter, add a file tag to the parent node
        var fileNodes = ScanForCdata(merged, previewMode); // 1.
        if(!previewMode) PrepareFileTags(merged, fileNodes); // 2.

        var i = 1;
        // Create a new question for each row in the CSV file
        for (var j = 1; j < _csvAsList.Count(); j++){
            var xmlQuestionNode = merged.GetElementsByTagName("question").Item(0)?.Clone(); // 1. Clone the template question
            if (xmlQuestionNode == null) continue;
            
            var nameNode = xmlQuestionNode.SelectSingleNode("//name/text");
            if (!previewMode){
                if (nameNode != null){
                    nameNode.InnerText = $"{nameNode.InnerText}-{i}";
                    i++;
                }
            }

            // 2. Replace the parameters with the values from the CSV file
            var allNodes = xmlQuestionNode.SelectNodes("//text"); // Select all nodes of type text
            if (allNodes == null) continue;
            var nodes = allNodes.Cast<XmlNode>();
            var paramNodes = nodes.Where(n =>
                n.InnerText.Contains("[*[[") && n.InnerText.Contains("]]*]")
            ).ToList();
            foreach (var node in paramNodes){
                var parser = new ParameterParser(node.InnerXml, previewMode);
                var parameters = parser.Match() as List<Parameter> ?? [];
                foreach (var param in parameters){
                    param.Replacement = !previewMode ? FindInCsv(_csvAsList, j, param.Name) : 
                        $"<span class=\"code\">[{FindInCsv(_csvAsList, j, param.Name)}]</span>";
                }
                node.InnerXml = parser.Replace(parameters);
            }

            // 3. Replace the file tags with the base64 encoded file
            if (!previewMode){
                var allFileNodes = xmlQuestionNode.SelectNodes("//file");
                if (allFileNodes == null) continue;
                var fileTags = allFileNodes.Cast<XmlNode>();
                foreach (var tag in fileTags){
                    if(!string.IsNullOrEmpty(tag.InnerText)) continue;
                    var name = tag.Attributes!["name"]!.Value;
                    string filename;
                    try{ filename = FindInCsv(_csvAsList, j, name); }
                    catch (KeyNotFoundException){ continue; } // this tag is not the one I added in the previous steps
                    
                    tag.Attributes!["name"]!.Value = filename;
                    var base64 = fileService.GetBase64(filename);
                    tag.InnerText = base64;
                }
            }

            merged.DocumentElement?.AppendChild(xmlQuestionNode);
        }

        // remove template question
        while (merged.DocumentElement?.FirstChild?.NodeType == XmlNodeType.Comment)
            merged.DocumentElement.RemoveChild(merged.DocumentElement.FirstChild);
        if (merged.DocumentElement?.FirstChild != null)
            merged.DocumentElement?.RemoveChild(merged.DocumentElement.FirstChild);

        return merged;
    }

    /// <summary>
    /// Scans the template question for nodes that contain text and a file parameter, and creates a CDATA section if not found.
    /// If the preview mode flag is set to false, the function will create a CDATA node for all parameter nodes.
    /// </summary>
    /// <param name="doc">The <see cref="XmlDocument"/> instance representing the template question.</param>
    /// <param name="previewMode">Whether the merge process is executing in preview mode or not.</param>
    /// <returns>A list of <see cref="XmlNode"/> instances containing at least one file parameter.</returns>
    private static List<XmlNode> ScanForCdata(XmlDocument doc, bool previewMode = false){
        var allNodes = doc.SelectNodes("//*[text()]");
        if (allNodes == null) return [];
        var nodes = allNodes.Cast<XmlNode>();
        var fileNodes = nodes.Where(n =>
            (!previewMode && (n.InnerText.Contains("[*[[FILE-") || n.InnerText.Contains("[*[[IMAGE-"))) ||
            (previewMode && n.InnerText.Contains("[*[[") && n.InnerText.Contains("]]*]"))
        ).ToList();
        
        foreach (var node in fileNodes){
            if (node.FirstChild is{ NodeType: XmlNodeType.CDATA }) continue;
            var cdata = doc.CreateCDataSection(node.InnerText);
            node.RemoveAll();
            node.AppendChild(cdata);
        }

        return fileNodes;
    }

    /// <summary>
    /// Prepares the template question by adding a file tags for each file parameter.
    /// </summary>
    /// <param name="doc">The <see cref="XmlDocument"/> instance representing the template question.</param>
    /// <param name="fileNodes">A list of <see cref="XmlNode"/> instances containing at least one file parameter.</param>
    private static void PrepareFileTags(XmlDocument doc, List<XmlNode> fileNodes){
        foreach (var node in fileNodes){
            var parameters = new ParameterParser(node.OuterXml).Match() as List<Parameter> ??[];
            var fileParams = parameters.Where(p => p is FileParameter or ImageParameter).ToList();
            foreach (var tag in fileParams.Select(fileParam => CreateFileTag(doc, fileParam.Name))){
                node.ParentNode?.AppendChild(tag);
            }
        }
    }
    
    /// <summary>
    /// Finds the value of a parameter in the CSV file.
    /// </summary>
    /// <param name="csv">The contents of the csv file.</param>
    /// <param name="i">Index of the corresponding csv line.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>The value associated with the specified parameter name.</returns>
    /// <exception cref="KeyNotFoundException">Parameter name is not present in the csv.</exception>
    private static string FindInCsv(IEnumerable<string[]> csv, int i, string paramName){
        var stringsEnumerable = csv.ToList();
        var headerRow = stringsEnumerable.ElementAt(0);
        var index = Array.IndexOf(headerRow, paramName);
        if (index == -1) throw new KeyNotFoundException();
        return stringsEnumerable.ElementAt(i)[index];
    }
    
    /// <summary>
    /// Creates a XML file tag with the specified name attribute.
    /// </summary>
    /// <param name="doc">The <see cref="XmlDocument"/> instance you are working on.</param>
    /// <param name="name">The name attribute value.</param>
    /// <returns>A new <see cref="XmlElement"/> instance, representing the file tag with the specified name.</returns>
    private static XmlElement CreateFileTag(XmlDocument doc, string name){
        var tag = doc.CreateElement("file");
        tag.SetAttribute("name", name);
        tag.SetAttribute("path", "/");
        tag.SetAttribute("encoding", "base64");
        tag.InnerText = "";
        return tag;
    }
}
