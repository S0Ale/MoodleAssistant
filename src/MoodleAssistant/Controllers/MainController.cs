using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers;

public class MainController : Controller{
    public IActionResult Main(){
        return View();
    }

    // Gets xml and csv files, saves them in the session and creates their models
    [HttpPost]
    public IActionResult UploadFiles(IFormFile file){
        var xmlModel = new UploadXmlFileModel{ XmlQuestion = file };
        if (file == null || file.Length == 0 || !xmlModel.IsXml()) {
            return BadRequest("Invalid file. Please upload an XML file.");
        }

        HttpContext.Session.SetString(SessionNameFieldConst.SessionXmlDocument, xmlModel.XmlFile.OuterXml);

        return Ok("File uploaded and saved in session successfully.");
    }
}
