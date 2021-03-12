using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace MoodleAssistant.Models
{
    public class DownloadModel
    {
        public XmlDocument XmlFile;

        public List<string[]> CsvAsList;

        public XmlDocument CreateQuestion(List<string[]> csvAsList, XmlDocument xmlFile)
        {
            var headerRow = csvAsList.ElementAt(0);
            for (var j = 1; j < csvAsList.Count; j++)
            {
                var xmlQuestionNode = xmlFile.GetElementsByTagName("question").Item(0)?.Clone();
                var questionString = xmlQuestionNode.InnerXml;
                
                for (var i = 0; i < headerRow.Length; i++)
                {
                    questionString = questionString.Replace("[*[[" + headerRow[i] + "]]*]", csvAsList.ElementAt(j)[i]);
                }
                xmlQuestionNode.InnerXml = questionString;
                xmlFile.DocumentElement?.AppendChild(xmlQuestionNode.Clone());
            }
            
            while(xmlFile.DocumentElement.FirstChild.NodeType == XmlNodeType.Comment)
                xmlFile.DocumentElement.RemoveChild(xmlFile.DocumentElement.FirstChild);
            xmlFile.DocumentElement.RemoveChild(xmlFile.DocumentElement.FirstChild);

            return xmlFile;
        }

        public MemoryStream GetFile(string toWrite)
        {
            var newStream = new MemoryStream();
            var writer = new StreamWriter(newStream);
            writer.Write(toWrite);
            writer.Flush();
            newStream.Position = 0;
            return newStream;
        }
    }
}
