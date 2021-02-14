using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers
{
    public class ProcessXmlController : Controller
    {
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ProcessXmlQuestion(IFormFile file)
        {
            const string pathToRandomQuestionView = "~/Views/Home/RandomQuestions.cshtml";
            var xmlFileModel = new UploadXmlFileModel {XmlQuestion = file};
            if (null == file)
                return SetErrorAndReturnToView(xmlFileModel, Errors.NullFile, pathToRandomQuestionView);
            
            if(System.Net.Mime.MediaTypeNames.Text.Xml != file.ContentType)
                return SetErrorAndReturnToView(xmlFileModel, Errors.NonXmlFile, pathToRandomQuestionView);
            
            var xmlFile = new XmlDocument();
            using (var streamReader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
            {
                if (streamReader.EndOfStream)
                    return SetErrorAndReturnToView(xmlFileModel, Errors.EmptyFile, pathToRandomQuestionView);
                try
                {
                    xmlFile.LoadXml(streamReader.ReadToEnd());
                }
                catch (XmlException)
                {
                    return SetErrorAndReturnToView(xmlFileModel, Errors.MalFormatted, pathToRandomQuestionView);
                }
            }
            //looking for number of question in file.
            var questionList = xmlFile.GetElementsByTagName("question");
            if (questionList.Count != 1)
                return SetErrorAndReturnToView(xmlFileModel, Errors.ZeroOrMoreQuestions, pathToRandomQuestionView);
            //looking for the question text.
            var questionTextList = xmlFile.GetElementsByTagName("questiontext");
            if (questionTextList.Count != 1)
                return SetErrorAndReturnToView(xmlFileModel, Errors.ZeroOrMoreQuestions, pathToRandomQuestionView);

            var questionParametersList = getQuestionParameters(questionTextList);
            if(!questionParametersList.Any())
                return SetErrorAndReturnToView(xmlFileModel, Errors.NoParameters, pathToRandomQuestionView);
            xmlFileModel.Error = Errors.NoErrors;
            return Content("Hello world");
        }

        private IActionResult SetErrorAndReturnToView(UploadXmlFileModel model, string error, string pathToRandomQuestionView)
        {
            model.Error = error;
            return View(pathToRandomQuestionView, model);
        }

        private IEnumerable<string> getQuestionParameters(XmlNodeList questionTextList)
        {
            //\[\*\[\[([^\]\*\]\]]+)\]\]\*\]
            var questionTextNode = questionTextList.Item(0);
            if (null == questionTextNode)
                return new List<string>();
            
            var questionText = questionTextNode.InnerText;
            const string pattern = @"(\[\*\[\[)([^\]\*\]\]]+)(\]\]\*\])";
            var rgx = new Regex(pattern);
            var parametersList = new List<string>();
            foreach (Match match in rgx.Matches(questionText))
                parametersList.Add(match.Groups[2].Value);
            return parametersList;
            
        }
    }
}