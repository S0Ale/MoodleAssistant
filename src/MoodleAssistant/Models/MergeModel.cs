using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using MoodleAssistant.Parse;

namespace MoodleAssistant.Models
{
    public class MergeModel
    {
        private readonly XmlDocument _xmlDoc;

        public XmlDocument XmlFile{
            get => _xmlDoc;
            init => _xmlDoc = value.Clone() as XmlDocument;
        }

        public IEnumerable<string[]> CsvAsList;

        public void MergeQuestion()
        {
            // create new question nodes
            var headerRow = CsvAsList.ElementAt(0); // first row contains parameter names
            for (var j = 1; j < CsvAsList.Count(); j++)
            {
                var xmlQuestionNode = XmlFile.GetElementsByTagName("question").Item(0)?.Clone();
                var questionString = xmlQuestionNode.InnerXml;

                // Get Parameters
                var parser = new ParameterParser(questionString);
                var parameters = parser.Match() as List<Parameter>;
                for (var i = 0; i < headerRow.Length; i++)
                {
                    //questionString = questionString.Replace("[*[[" + headerRow[i] + "]]*]", CsvAsList.ElementAt(j)[i]);
                    parameters[i].Replacement = CsvAsList.ElementAt(j)[i]; // put replacements for each parameter
                }

                xmlQuestionNode.InnerXml = parser.Replace(parameters);
                XmlFile.DocumentElement?.AppendChild(xmlQuestionNode.Clone());
            }

            // remove template question
            while(XmlFile.DocumentElement?.FirstChild?.NodeType == XmlNodeType.Comment)
                XmlFile.DocumentElement.RemoveChild(XmlFile.DocumentElement.FirstChild);
            XmlFile.DocumentElement?.RemoveChild(XmlFile.DocumentElement.FirstChild);
        }

        public MemoryStream GetMergedFile()
        {
            var newStream = new MemoryStream();
            var writer = new StreamWriter(newStream);
            writer.Write(_xmlDoc.OuterXml);
            writer.Flush();
            newStream.Position = 0;
            return newStream;
        }
    }
}
