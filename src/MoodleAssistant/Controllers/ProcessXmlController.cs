using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers
{
    public class ProcessXmlController : Controller
    {
        [HttpPost, ValidateAntiForgeryToken]

        //public IActionResult ProcessXmlQuestion(UploadXmlFileModel xmlFileModel)
        public IActionResult ProcessXmlQuestion(IFormFile xmlFile)
        {
            const string pathToRandomQuestionView = "~/Views/Home/RandomQuestions.cshtml";
            var xmlFileModel = new UploadXmlFileModel {XmlQuestion = xmlFile};
            if (null == xmlFile)
            {
                xmlFileModel.Error = Errors.NullFile;
                return View(pathToRandomQuestionView, xmlFileModel);
            }
            if(System.Net.Mime.MediaTypeNames.Text.Xml != xmlFileModel.XmlQuestion.ContentType)
            {
                xmlFileModel.Error = Errors.NonXmlFile;
                return View(pathToRandomQuestionView, xmlFileModel);
            }
            

            xmlFileModel.Error = Errors.NoErrors;
            return Content("Hello world");
        }
    }
}