using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;

namespace MoodleAssistant.Models
{
    public class DownloadModel
    {
        public XmlDocument XmlFile;

        public string CsvFilePath;

        public XmlDocument CreateQuestion(string csvFilePath, XmlDocument xmlFile)
        {
            using var fileReader = new StreamReader(csvFilePath);
            using var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            var headerRow = csv.HeaderRecord;
            while (csv.Read())
            {
                var xmlQuestionNode = xmlFile.GetElementsByTagName("question").Item(0)?.Clone();
                var questionString = xmlQuestionNode.InnerXml;
                for (var i = 0; i < csv.Parser.Count; i++)
                    questionString = questionString.Replace("[*[[" + headerRow[i] + "]]*]", csv.GetField<string>(i));

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
