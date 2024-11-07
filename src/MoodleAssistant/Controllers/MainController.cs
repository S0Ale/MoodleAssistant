using System;
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
    public IActionResult UploadFiles(){
        var files = HttpContext.Request.Form.Files;
        if(files.Count < 2)
            return BadRequest("Missing files. Please fill all fields.");

        // XML file
        var xmlFile = files.GetFile("xml_upload");
        var xmlModel = new UploadXmlFileModel { XmlQuestion = xmlFile };
        if (xmlFile == null || xmlFile.Length == 0 || !xmlModel.IsXml()) {
            return BadRequest("Invalid file. Please upload an XML file.");
        }

        // CSV file
        var csvFile = files.GetFile("csv_upload");
        var csvModel = new UploadCsvFileModel { CsvAnswers = csvFile };
        if (csvFile == null || csvFile.Length == 0 || !csvModel.IsCsv()) {
            return BadRequest("Invalid file. Please upload a CSV file.");
        }

        //HttpContext.Session.SetString(SessionNameFieldConst.SessionXmlDocument, xmlModel.XmlFile.OuterXml);
        //var csvAsList = csvModel.ConvertCsvToListOfArrayString();
        //HttpContext.Session.SetObjectAsJson(SessionNameFieldConst.SessionCsvFile, csvAsList);

        return Ok("File uploaded and saved in session successfully.");
    }
}
