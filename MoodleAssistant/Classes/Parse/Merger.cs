using System.Xml;
using MoodleAssistant.Classes.Parse;
using MoodleAssistant.Services;

namespace MoodleAssistant.Classes.Models;

public class Merger(ReplicatorState state){
    private readonly XmlDocument _xmlDoc;
    
    public XmlDocument XmlFile{
        init => _xmlDoc = value.Clone() as XmlDocument;
    }
    public IEnumerable<string[]> CsvAsList{ get; init; }
    
    public void MergeQuestion()
    {
        // create new question nodes
        var headerRow = CsvAsList.ElementAt(0); // first row contains parameter names
        for (var j = 1; j < CsvAsList.Count(); j++)
        {
            var xmlQuestionNode = _xmlDoc.GetElementsByTagName("question").Item(0)?.Clone();
            var questionString = xmlQuestionNode.InnerXml;

            // Get Parameters
            var parser = new ParameterParser(questionString);
            var parameters = parser.Match() as List<Parameter>;
            for (var i = 0; i < headerRow.Length; i++)
                parameters[i].Replacement = CsvAsList.ElementAt(j)[i]; // put replacements for each parameter

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