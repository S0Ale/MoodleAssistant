using System.Text;
using AikenDoc;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Parse;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Manages the validation of a Aiken template file and its parameters.
/// </summary>
public class AikenModel(IBrowserFile file, IBrowserFileService fileService) : ITemplateModel{
    
    /// <summary>
    /// Gets the Aiken template document.
    /// </summary>
    private AikenDocument _aikenFile = new AikenDocument();
    
    /// <inheritdoc/>
    public object TemplateDocument{ 
        get => _aikenFile;
        set => _aikenFile = (AikenDocument)value; 
    }

    /// <inheritdoc/>
    public IEnumerable<string> QuestionParametersList{ get; set; } = [];
    
    /// <inheritdoc/>
    public IEnumerable<string> AnswerParametersList{ get; set; } = [];
    
    /// <summary>
    /// Checks if the <see cref="IBrowserFile.ContentType"/> of a file is plain text.
    /// </summary>
    /// <param name="file">An instance of <see cref="IBrowserFile"/> representing the file.</param>
    /// <returns><c>true</c> if the file is plain text; otherwise <c>false</c>.</returns>
    private static bool IsText(IBrowserFile file){
        return System.Net.Mime.MediaTypeNames.Text.Plain == file.ContentType;
    }

    /// <summary>
    /// Checks if the file with the <see cref="AikenModel"/>'s file name is well formatted Aiken.
    /// </summary>
    /// <returns><c>true</c> if the file is well formatted; otherwise <c>false</c>.</returns>
    private bool IsWellFormattedAiken(){
        var stream = fileService.GetFile("TEMPLATE");
        using var reader = new StreamReader(stream, Encoding.UTF8);
                                                                                                
        try{                                                                                       
            _aikenFile.LoadText(reader.ReadToEnd());                                         
            return true;                                                                       
        }                                                                                      
        catch (Exception){                                                                                      
            return false;                                                                      
        }                                                                                      
    }
    
    /// <summary>
    /// Gets the parameters from an Aiken element.
    /// </summary>
    /// <param name="el">An instance of <see cref="AikenElement"/></param>
    /// <returns>The list of parameters contained into the element.</returns>
    private List<string> GetParametersFromAikenElement(AikenElement el){
        var paramList = new ParameterParser(el.Text).Match();
        return paramList.Select(parameter => parameter.Name).ToList();
    }
    
    /// <inheritdoc/>
    public void TakeParameters(){
        QuestionParametersList = _aikenFile.Questions.SelectMany(GetParametersFromAikenElement).Distinct();
        
        var answerParametersList = new List<string>();
        var options = _aikenFile.Questions.SelectMany(question => question.Options);
        foreach (var option in options)
            answerParametersList.AddRange(GetParametersFromAikenElement(option));
        AnswerParametersList = answerParametersList.Distinct();
    }
    
    /// <inheritdoc/>
    public void Validate(){
        if(!IsText(file) || !IsWellFormattedAiken()){
            throw new ReplicatorException(Error.NonAikenFile);
        }
    }
}