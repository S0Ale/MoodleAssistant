using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace MoodleAssistant.Models
{
    public class DownloadModel
    {
        public XmlDocument XmlFile;

        public IEnumerable<string[]> CsvAsList;

        public XmlDocument CreateQuestion()
        {
            var headerRow = CsvAsList.ElementAt(0);
            for (var j = 1; j < CsvAsList.Count(); j++)
            {
                var xmlQuestionNode = XmlFile.GetElementsByTagName("question").Item(0)?.Clone();
                var questionString = xmlQuestionNode.InnerXml;
                
                for (var i = 0; i < headerRow.Length; i++)
                {
                    questionString = questionString.Replace("[*[[" + headerRow[i] + "]]*]", CsvAsList.ElementAt(j)[i]);
                }
                xmlQuestionNode.InnerXml = questionString;
                XmlFile.DocumentElement?.AppendChild(xmlQuestionNode.Clone());
            }
            
            while(XmlFile.DocumentElement.FirstChild.NodeType == XmlNodeType.Comment)
                XmlFile.DocumentElement.RemoveChild(XmlFile.DocumentElement.FirstChild);
            XmlFile.DocumentElement.RemoveChild(XmlFile.DocumentElement.FirstChild);

            return XmlFile;
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
