﻿using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Models;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic.Processing.XML;

/// <summary>
/// Factory implementation for XML template types.
/// </summary>
/// <param name="fileService"></param>
public class XmlFactory(IBrowserFileService fileService) : IReplicatorFactory{
    
    /// <inheritdoc/>
    public ITemplateModel CreateTemplateModel(IBrowserFile file){
        return new XmlModel(file, fileService);
    }

    /// <inheritdoc/>
    public IAnalyzer CreateAnalyzer(){
        return new XmlAnalyzer();
    }

    /// <inheritdoc/>
    public IMerger CreateMerger(object template, IEnumerable<string[]> csvAsList){
        return new XmlMerger(fileService, (XmlDocument)template, csvAsList);
    }

    /// <inheritdoc/>
    public ParameterHandler CreateParameterHandler(object doc, int csvRows){
        return new XmlParameterHandler((XmlDocument)doc, csvRows);
    }

    /// <inheritdoc/>
    public IPreviewHandler CreatePreviewHandler(){
        return new XmlPreviewHandler();
    }
}