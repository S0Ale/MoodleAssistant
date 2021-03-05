using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers
{
    public class XmlController : Controller
    {
        private const string PathToRandomQuestionView = "~/Views/Xml/Upload.cshtml";
        private const string PathToSummaryPageView = "~/Views/Xml/SummaryPage.cshtml";
        
        public IActionResult Upload(UploadXmlFileModel model)
        {
            if (null == model)
                model = new UploadXmlFileModel { Error = Error.NoErrors };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upload(IFormFile file)
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

            if(!xmlFileModel.HasAnswer())
                return SetErrorAndReturnToView(xmlFileModel, Error.ZeroAnswers);

            xmlFileModel.TakeParameters();
            
            HttpContext.Session.SetString(SessionNameFieldConst.SessionXmlDocument, xmlFileModel.XmlFile.OuterXml);
            HttpContext.Session.SetObjectAsJson(SessionNameFieldConst.SessionQuestionList, xmlFileModel.QuestionParametersList);
            HttpContext.Session.SetObjectAsJson(SessionNameFieldConst.SessionAnswerList, xmlFileModel.AnswerParametersList);

            return View(PathToSummaryPageView, xmlFileModel);
        }

        public IActionResult Download()
        {
            var xmlFileString = HttpContext.Session.GetString(SessionNameFieldConst.SessionXmlDocument);
            var csvFilePath = HttpContext.Session.GetString(SessionNameFieldConst.SessionCsvFile);

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(xmlFileString);

            var xmlModel = new DownloadModel{
               XmlFile = xmlFile,
               CsvFilePath = csvFilePath
            };

            xmlFile = xmlModel.CreateQuestion(csvFilePath, xmlFile);
            return File(xmlModel.GetFile(xmlFile.OuterXml), "text/xml", "questions.xml");
        }

        
        private IActionResult SetErrorAndReturnToView(UploadXmlFileModel model, Error error)
        {
            model.Error = error;
            return View(PathToRandomQuestionView, model);
        }

        
    }
}