using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers;

public class MainController : Controller{

    private MainModel m = new();
    public IActionResult Index(){
        return View("Main", m);
    }

    // Gets xml and csv files, saves them in the session and creates their models
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult UploadFiles(){
        var files = HttpContext.Request.Form.Files;
        if (files.Count < 2)
            return BadRequest("Missing files. Please fill all fields.");

        // XML file
        UploadXmlFileModel xmlModel;
        var xmlFile = files.GetFile("xml_upload");
        try{ xmlModel = LoadXml(xmlFile); }
        catch (ValidationException e){
            return BadRequest(e.Message);
        }

        // CSV file
        IEnumerable<string[]> list;
        var csvFile = files.GetFile("csv_upload");
        try{ list = LoadCsv(csvFile, xmlModel);}
        catch (ValidationException e) {
            return BadRequest(e.Message);
        }

        // Save in session
        HttpContext.Session.SetObjectAsJson(SessionNameFieldConst.SessionXmlFile, xmlModel);
        HttpContext.Session.SetObjectAsJson(SessionNameFieldConst.SessionCsvFile, list);

        m.RenderParameters = true;
        return View("Main", m);
    }

    private UploadXmlFileModel LoadXml(IFormFile file){
        var model = new UploadXmlFileModel{ XmlQuestion = file };

        if (null == file)
            throw new ValidationException(Error.NullFile);
        if (!model.IsXml())
            throw new ValidationException(Error.NonXmlFile);
        if (model.IsEmpty())
            throw new ValidationException(Error.EmptyFile);
        if (!model.IsWellFormattedXml())
            throw new ValidationException(Error.XmlBadFormed);
        if (!model.HasOnlyOneQuestion())
            throw new ValidationException(Error.ZeroOrMoreQuestions);
        if (!model.HasQuestionText())
            throw new ValidationException(Error.ZeroOrMoreQuestions);

        model.TakeParameters();
        return model;
    }

    private IEnumerable<string[]> LoadCsv(IFormFile file, UploadXmlFileModel xmlModel){
        var model = new UploadCsvFileModel{
            CsvAnswers = file,
            QuestionParametersList = xmlModel.QuestionParametersList,
            AnswersParametersList = xmlModel.AnswerParametersList
        };

        if (null == file)
            throw new ValidationException(Error.NullFile);
        if (!model.IsCsv())
            throw new ValidationException(Error.NonCsvFile);
        if (model.IsEmpty())
            throw new ValidationException(Error.EmptyFile);
        if (!model.HasValidHeader())
            throw new ValidationException(Error.CsvInvalidHeader);
        if (!model.IsWellFormed())
            throw new ValidationException(Error.CsvBadFormed);

        return model.ConvertCsvToListOfArrayString();
    }
}
