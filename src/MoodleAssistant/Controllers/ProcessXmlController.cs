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
            const string pathToSummaryPageView = "~/Views/Home/SummaryPage.cshtml";

            var xmlFileModel = new UploadXmlFileModel {XmlQuestion = file};
            if (null == file)
                return SetErrorAndReturnToView(xmlFileModel, Error.NullFile, pathToRandomQuestionView);

            if (!xmlFileModel.IsXml())
                return SetErrorAndReturnToView(xmlFileModel, Error.NonXmlFile, pathToRandomQuestionView);
            
            if(xmlFileModel.IsEmpty())
                return SetErrorAndReturnToView(xmlFileModel, Error.EmptyFile, pathToRandomQuestionView);

            if(!xmlFileModel.IsWellFormattedXml())
                return SetErrorAndReturnToView(xmlFileModel, Error.MalFormatted, pathToRandomQuestionView);

            if(!xmlFileModel.HasOnlyOneQuestion())
                return SetErrorAndReturnToView(xmlFileModel, Error.ZeroOrMoreQuestions, pathToRandomQuestionView);

            if(!xmlFileModel.HasQuestionText())
                return SetErrorAndReturnToView(xmlFileModel, Error.ZeroOrMoreQuestions, pathToRandomQuestionView);
            
            if(!xmlFileModel.QuestionHasParameters())
                return SetErrorAndReturnToView(xmlFileModel, Error.NoParameters, pathToRandomQuestionView);
            
            if(!xmlFileModel.HasAnswer())
                return SetErrorAndReturnToView(xmlFileModel, Error.ZeroAnswers, pathToRandomQuestionView);

            xmlFileModel.TakeAnswerParameters();
            
            var summaryModel = new SummaryModel
            {
                QuestionParametersList = xmlFileModel.QuestionParametersList,
                AnswerParametersList = xmlFileModel.AnswerParametersList
            };
            return View(pathToSummaryPageView, summaryModel);
        }

        

        private IActionResult SetErrorAndReturnToView(UploadXmlFileModel model, Error error, string pathToRandomQuestionView)
        {
            model.Error = error;
            return View(pathToRandomQuestionView, model);
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