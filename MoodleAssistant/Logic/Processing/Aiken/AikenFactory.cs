using AikenDoc;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Models;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic.Processing.Aiken;

/// <summary>
/// Factory implementation for Aiken template types.
/// </summary>
/// <param name="fileService"></param>
public class AikenFactory(IBrowserFileService fileService) : IReplicatorFactory{
    
    /// <inheritdoc/>
    public ITemplateModel CreateTemplateModel(IBrowserFile file){
        return new AikenModel(file, fileService);
    }

    /// <inheritdoc/>
    public IAnalyzer CreateAnalyzer(){
        return new AikenAnalyzer();
    }

    /// <inheritdoc/>
    public IMerger CreateMerger(object template, IEnumerable<string[]> csvAsList){
        return new AikenMerger((AikenDocument)template, csvAsList);
    }

    /// <inheritdoc/>
    public ParameterHandler CreateParameterHandler(object doc, int csvRows){
        return new AikenParameterHandler((AikenDocument)doc, csvRows);
    }

    /// <inheritdoc/>
    public IPreviewHandler CreatePreviewHandler(){
        throw new NotImplementedException();
    }
}