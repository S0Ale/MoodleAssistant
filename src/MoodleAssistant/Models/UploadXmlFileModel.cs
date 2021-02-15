using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Models
{
    public class UploadXmlFileModel
    {
        public IFormFile XmlQuestion;

        public Error Error;

        public XmlDocument XmlFile;

        public IEnumerable<string> QuestionParametersList;

        public IEnumerable<string> AnswerParametersList;

        public bool IsXml()
        {
            return System.Net.Mime.MediaTypeNames.Text.Xml == XmlQuestion.ContentType;
        }

        public bool IsEmpty()
        {
            using var streamReader = new StreamReader(XmlQuestion.OpenReadStream(), Encoding.UTF8);
            return streamReader.EndOfStream;
        }

        public bool IsWellFormattedXml()
        {
            using var streamReader = new StreamReader(XmlQuestion.OpenReadStream(), Encoding.UTF8);

            try
            {
                XmlFile = new XmlDocument();
                XmlFile.LoadXml(streamReader.ReadToEnd());
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
        }

        public bool HasOnlyOneQuestion()
        {
            var questionList = XmlFile.GetElementsByTagName("question");
            return questionList.Count == 1;
        }

        public bool HasQuestionText()
        {
            var questiontextNodeList = XmlFile.GetElementsByTagName("questiontext");
            return questiontextNodeList.Count == 1;
        }

        public bool QuestionHasParameters()
        {
            var questiontextNodeList = XmlFile.GetElementsByTagName("questiontext");
            var questionParametersList = GetParametersFromXmlNode(questiontextNodeList.Item(0));
            QuestionParametersList = questionParametersList;
            return questionParametersList.Any();
        }

        public bool HasAnswer()
        {
            var answerList = XmlFile.GetElementsByTagName("answer");
            return answerList.Count > 0;
        }

        public void TakeAnswerParameters()
        {
            var answerParametersList = new List<string>();
            var answerList = XmlFile.GetElementsByTagName("answer");
            foreach (XmlNode answer in answerList)
                answerParametersList.AddRange(GetParametersFromXmlNode(answer));
        }

        private static IEnumerable<string> GetParametersFromXmlNode(XmlNode textNode)
        {
            if (null == textNode)
                return new List<string>();

            var questionText = textNode.InnerText;
            const string pattern = @"(\[\*\[\[)([^\]\*\]\]]+)(\]\]\*\])";
            var rgx = new Regex(pattern);
            var parametersList = new List<string>();
            foreach (Match match in rgx.Matches(questionText))
                parametersList.Add(match.Groups[2].Value);
            return parametersList;

        }

    }

}
