using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers
{
    public class CsvController : Controller
    {
        private const string PathToUploadCsvView = "~/Views/Csv/Upload.cshtml";
        private const string PathToDownloadView = "~/Views/Xml/Download.cshtml";

        public IActionResult Upload(UploadCsvFileModel model)
        {
            if (null == model)
                model = new UploadCsvFileModel() {Error = Error.NoErrors};
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upload(IFormFile file, bool firstAccess)
        {
            var csvFileModel = new UploadCsvFileModel
            {
                CsvAnswers = file,
                Error = Error.NoErrors,
                QuestionParametersList = HttpContext.Session.GetObjectFromJson<IEnumerable<string>>(SessionNameFieldConst.SessionQuestionList),
                AnswersParametersList = HttpContext.Session.GetObjectFromJson<IEnumerable<string>>(SessionNameFieldConst.SessionAnswerList)
            };

            if (firstAccess)
                return View(csvFileModel);

            if (null == file)
                return SetErrorAndReturnToView(csvFileModel, Error.NullFile);

            if (!csvFileModel.IsCsv())
                return SetErrorAndReturnToView(csvFileModel, Error.NonCsvFile);

            if (csvFileModel.IsEmpty())
                return SetErrorAndReturnToView(csvFileModel, Error.EmptyFile);

            if (!csvFileModel.HasValidHeader())
                return SetErrorAndReturnToView(csvFileModel, Error.CsvInvalidHeader);

            if (!csvFileModel.IsWellFormed())
                return SetErrorAndReturnToView(csvFileModel, Error.CsvBadFormed);

            
            var csvAsList = csvFileModel.ConvertCsvToListOfArrayString();

            HttpContext.Session.SetObjectAsJson(SessionNameFieldConst.SessionCsvFile, csvAsList);
            return View(PathToDownloadView);
        }

        private IActionResult SetErrorAndReturnToView(UploadCsvFileModel model, Error error)
        {
            model.Error = error;
            return View(PathToUploadCsvView, model);
        }
    }
}
