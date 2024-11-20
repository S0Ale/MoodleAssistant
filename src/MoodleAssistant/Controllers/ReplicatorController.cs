﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Controllers;

public class ReplicatorController : Controller{

    private ReplicatorModel _m = new(){ Error = Error.NoErrors };

    public ReplicatorController() {
        _m.RenderParameters = false;
    }

    public IActionResult Index(){
        return View("Index", _m);
    }

    // Gets xml and csv files, saves them in the session and creates their models
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult UploadFiles(IFormCollection form){
        var files = form.Files;
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

        _m.XmlModel = xmlModel;
        
        var mergeModel = new MergeModel{
            XmlFile = xmlModel.XmlFile,
            CsvAsList = list
        };
        
        // replicate question
        mergeModel.MergeQuestion();
        _m.Preview = new PreviewModel(mergeModel.XmlFile, xmlModel.AnswerCount);
        
        // Save in session
        HttpContext.Session.SetString(SessionNameFieldConst.SessionXmlMergedDocument, mergeModel.XmlFile.OuterXml);

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
