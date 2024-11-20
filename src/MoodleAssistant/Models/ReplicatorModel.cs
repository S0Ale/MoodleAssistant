using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Models;

public class ReplicatorModel{
    public XmlFileModel XmlModel { get; set; }
    public PreviewModel Preview{ get; set; }
    public IEnumerable<string[]> CsvList { get; set; }

    public XmlDocument ReplicatedQuestion{ get; private set; }

    private Dictionary<string, bool> _sections = new() { // section list
        { "RenderParameters", false }
    };

    public Error Error { get; set; } // page error

    public bool RenderParameters{
        get => _sections["RenderParameters"];
        set{
            ResetSections();
            _sections["RenderParameters"] = value;
        }
    }

    private void ResetSections() {
        foreach (var key in _sections.Keys)
            _sections[key] = false;
    }

    public void CreateQuestion(){
        var xmlFile = XmlModel.XmlFile.Clone() as XmlDocument;

        // create new question nodes
        var headerRow = CsvList.ElementAt(0); // first row contains parameter names
        for (var j = 1; j < CsvList.Count(); j++) {
            var xmlQuestionNode = xmlFile.GetElementsByTagName("question").Item(0)?.Clone();
            var questionString = xmlQuestionNode.InnerXml;

            for (var i = 0; i < headerRow.Length; i++) {
                questionString = questionString.Replace("[*[[" + headerRow[i] + "]]*]", CsvList.ElementAt(j)[i]);
            }
            xmlQuestionNode.InnerXml = questionString;
            xmlFile.DocumentElement?.AppendChild(xmlQuestionNode.Clone());
        }

        // remove template question
        while (xmlFile.DocumentElement?.FirstChild?.NodeType == XmlNodeType.Comment)
            xmlFile.DocumentElement.RemoveChild(xmlFile.DocumentElement.FirstChild);
        xmlFile.DocumentElement?.RemoveChild(xmlFile.DocumentElement.FirstChild);

        ReplicatedQuestion = xmlFile;
    }
}
