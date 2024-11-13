using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers;

public class MainController : Controller{

    private MainModel _m = new(){ Error = Error.NoErrors };

    public MainController() {
        _m.RenderParameters = false;
    }

    public IActionResult Index(){
        return View(_m);
    }

    // Gets xml and csv files, saves them in the session and creates their models
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult UploadFiles(){
        var files = HttpContext.Request.Form.Files;
        _m.RenderParameters = false;

        if (files.Count < 2){
            _m.Error = Error.NoFiles;
            return View("Index", _m); // the url is not index anymore
        }

        // XML file
        XmlFileModel xmlModel;
        var xmlFile = files.GetFile("xml_upload");
        try{ xmlModel = LoadXml(xmlFile); }
        catch (ValidationException e){
            _m.Error = e.Error;
            return View("Index", _m);
        }

        // CSV file
        IEnumerable<string[]> list;
        var csvFile = files.GetFile("csv_upload");
        try{ list = LoadCsv(csvFile, xmlModel);}
        catch (ValidationException e) {
            _m.Error = e.Error;
            return View("Index", _m);
        }

        // Save in session
        //HttpContext.Session.SetObjectAsJson(SessionNameFieldConst.SessionXmlFile, xmlModel);
        HttpContext.Session.SetString(SessionNameFieldConst.SessionXmlDocument, xmlModel.XmlFile.OuterXml);
        HttpContext.Session.SetObjectAsJson(SessionNameFieldConst.SessionCsvFile, list);

        _m.XmlModel = xmlModel;
        _m.CsvList = list;

        _m.RenderParameters = true;
        return View("Index", _m);
    }

    private XmlFileModel LoadXml(IFormFile file){
        var model = new XmlFileModel{ XmlQuestion = file };

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

    private IEnumerable<string[]> LoadCsv(IFormFile file, XmlFileModel xmlModel){
        var model = new CsvFileModel{
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
