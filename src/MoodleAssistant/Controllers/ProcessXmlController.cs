using System.IO;
using System.Text;
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
                xmlFile.LoadXml(streamReader.ReadToEnd());
            }
            
            xmlFileModel.Error = Errors.NoErrors;
            return Content("Hello world");
        }

        private IActionResult SetErrorAndReturnToView(UploadXmlFileModel model, string error, string pathToRandomQuestionView)
        {
            model.Error = error;
            return View(pathToRandomQuestionView, model);
        }
    }
}