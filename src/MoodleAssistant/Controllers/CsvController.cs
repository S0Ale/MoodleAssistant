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
    }
}
