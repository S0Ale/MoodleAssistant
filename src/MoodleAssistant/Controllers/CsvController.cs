using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers
{
    public class CsvController : Controller
    {
        private const string PathToUploadCsvView = "~/Views/Csv/Upload.cshtml";

        public IActionResult Upload(UploadCsvFileModel model)
        {
            if (null == model)
                model = new UploadCsvFileModel() {Error = Utils.Error.NoErrors};
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upload(IFormFile file)
        {
            var csvFileModel = new UploadCsvFileModel { CsvAnswers = file };
            if (null == file)
                return SetErrorAndReturnToView(csvFileModel, Error.NullFile);

            if (!csvFileModel.IsCsv())
                return SetErrorAndReturnToView(csvFileModel, Error.NonCsvFile);

            if (csvFileModel.IsEmpty())
                return SetErrorAndReturnToView(csvFileModel, Error.EmptyFile);

            return Content("ciao");
        }

        private IActionResult SetErrorAndReturnToView(UploadCsvFileModel model, Error error)
        {
            model.Error = error;
            return View(PathToUploadCsvView, model);
        }
    }
}
