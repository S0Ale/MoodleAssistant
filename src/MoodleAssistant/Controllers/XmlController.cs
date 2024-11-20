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
        public IActionResult Download()
        {
            var xmlFileString = HttpContext.Session.GetString(SessionNameFieldConst.SessionXmlMergedDocument);

            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(xmlFileString);
            var model = new MergeModel(){
                XmlFile = xmlFile,
            };
            
            return File(model.GetMergedFile(), "text/xml", "questions.xml");
        }

    }
}