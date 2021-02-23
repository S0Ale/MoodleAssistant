using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers
{
    public class CsvController : Controller
    {
        private const string PathToUploadCsvView = "~/Views/Csv/Upload.cshtml";
        private IEnumerable<string> _questionParametersList;
        private IEnumerable<string> _answersParametersList;


        public IActionResult Upload(UploadCsvFileModel model)
        {
            if (null == model)
                model = new UploadCsvFileModel() {Error = Error.NoErrors};
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upload(IFormFile file, string questionParametersList, string answersParametersList)
        {
            var csvFileModel = new UploadCsvFileModel
            {
                CsvAnswers = file,
                QuestionParametersList = JsonSerializer.Deserialize<IEnumerable<string>>(questionParametersList),
                AnswersParametersList = JsonSerializer.Deserialize<IEnumerable<string>>(answersParametersList)
            };
            
            if (null == file)
                return SetErrorAndReturnToView(csvFileModel, Error.NullFile);

            if (!csvFileModel.IsCsv())
                return SetErrorAndReturnToView(csvFileModel, Error.NonCsvFile);

            if (csvFileModel.IsEmpty())
                return SetErrorAndReturnToView(csvFileModel, Error.EmptyFile);

            if (!csvFileModel.HasHeader())
                return SetErrorAndReturnToView(csvFileModel, Error.CsvWithoutHeaders);

            return Content("ciao");
        }

        private IActionResult SetErrorAndReturnToView(UploadCsvFileModel model, Error error)
        {
            model.Error = error;
            return View(PathToUploadCsvView, model);
        }
    }
}
