﻿using System;
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
        private const string PathToRandomQuestionView = "~/Views/Home/RandomQuestions.cshtml";
        private const string PathToSummaryPageView = "~/Views/Home/SummaryPage.cshtml";

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ProcessXmlQuestion(IFormFile file)
        {
            var xmlFileModel = new UploadXmlFileModel {XmlQuestion = file};
            if (null == file)
                return SetErrorAndReturnToView(xmlFileModel, Error.NullFile);

            if (!xmlFileModel.IsXml())
                return SetErrorAndReturnToView(xmlFileModel, Error.NonXmlFile);
            
            if(xmlFileModel.IsEmpty())
                return SetErrorAndReturnToView(xmlFileModel, Error.EmptyFile);

            if(!xmlFileModel.IsWellFormattedXml())
                return SetErrorAndReturnToView(xmlFileModel, Error.MalFormatted);

            if(!xmlFileModel.HasOnlyOneQuestion())
                return SetErrorAndReturnToView(xmlFileModel, Error.ZeroOrMoreQuestions);

            if(!xmlFileModel.HasQuestionText())
                return SetErrorAndReturnToView(xmlFileModel, Error.ZeroOrMoreQuestions);
            
            if(!xmlFileModel.QuestionHasParameters())
                return SetErrorAndReturnToView(xmlFileModel, Error.NoParameters);
            
            if(!xmlFileModel.HasAnswer())
                return SetErrorAndReturnToView(xmlFileModel, Error.ZeroAnswers);

            xmlFileModel.TakeAnswerParameters();
            
            var summaryModel = new SummaryModel
            {
                QuestionParametersList = xmlFileModel.QuestionParametersList,
                AnswerParametersList = xmlFileModel.AnswerParametersList
            };
            return View(PathToSummaryPageView, summaryModel);
        }

        private IActionResult SetErrorAndReturnToView(UploadXmlFileModel model, Error error)
        {
            model.Error = error;
            return View(PathToRandomQuestionView, model);
        }

    }
}