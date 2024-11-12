using System.Collections.Generic;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers
{
    public class XmlController : Controller
    {
        //public IActionResult AnalizeXml(){
            //var model = HttpContext.Session.GetObjectFromJson<XmlFileModel>(SessionNameFieldConst.SessionXmlFile);
            //return PartialView("_Analysis", model);
        //}

        public IActionResult Download()
        {
            var xmlFileString = HttpContext.Session.GetString(SessionNameFieldConst.SessionXmlDocument);
            var csvAsList = HttpContext.Session.GetObjectFromJson<List<string[]>>(SessionNameFieldConst.SessionCsvFile);

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(xmlFileString);

            var downloadModel = new DownloadModel{
               XmlFile = xmlFile,
               CsvAsList = csvAsList
            };

            xmlFile = downloadModel.CreateQuestion();
            return File(downloadModel.GetFile(xmlFile.OuterXml), "text/xml", "questions.xml");
        }

    }
}