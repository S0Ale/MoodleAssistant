using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Manages the validation of a XML template file and its parameters.
/// </summary>
/// <param name="file">The instance of <see cref="IBrowserFile"/> representing the file to validate.</param>
/// <param name="fileService">An instance of <see cref="IBrowserFileService"/> to manage saved files.</param>
public class XmlModel(IBrowserFile file, IBrowserFileService fileService) : ITemplateModel, IValidationModel{
    /// <summary>
    /// The standard name of the XML file managed by the <see cref="XmlModel"/>.
    /// </summary>
    public static string FileName => "XML";
    
    /// <summary>
    /// The pattern to match the parameters in the XML file.
    /// </summary>
    private const string Pattern = @"(\[\*\[\[)([^\]\*\]\]]+)(\]\]\*\])";
    
    /// <summary>
    /// Gets the XML template document.
    /// </summary>
    private XmlDocument _xmlFile = new XmlDocument();
    
    /// <summary>
    /// Gets the template document.
    /// </summary>
    public Object TemplateDocument{
        get => _xmlFile;
        set => _xmlFile = (XmlDocument)value;
    }

    /// <inheritdoc/>
    public IEnumerable<string> QuestionParametersList{ get; set; } = [];
    
    /// <inheritdoc/>
    public IEnumerable<string> AnswerParametersList{ get; set; } = [];

    /// <summary>
    /// Checks if the <see cref="IBrowserFile.ContentType"/> of a file is XML.
    /// </summary>
    /// <param name="file">An instance of <see cref="IBrowserFile"/> representing the file.</param>
    /// <returns><c>true</c> if the file is XML; otherwise <c>false</c>.</returns>
    private static bool IsXml(IBrowserFile file)
    {
        return System.Net.Mime.MediaTypeNames.Text.Xml == file.ContentType;
    }
    
    /// <summary>
    /// Checks if the file with the <see cref="XmlModel"/>'s file name is well formatted XML.
    /// </summary>
    /// <returns><c>true</c> if the file is well formatted; otherwise <c>false</c>.</returns>
    private bool IsWellFormattedXml(){
        var stream = fileService.GetFile(FileName);
        using var reader = new StreamReader(stream, Encoding.UTF8);
                                                                                               
        try{                                                                                       
            _xmlFile.LoadXml(reader.ReadToEnd());                                         
            return true;                                                                       
        }                                                                                      
        catch (XmlException){                                                                                      
            return false;                                                                      
        }                                                                                      
    }
    
    /// <summary>
    /// Checks if the file with the <see cref="XmlModel"/>'s file name has only one question tag.
    /// </summary>
    /// <returns><c>true</c> if the file has only one question; otherwise <c>false</c>.</returns>
    private bool HasOnlyOneQuestion(){                                                                                                                                                        
        var questionList = _xmlFile.GetElementsByTagName("question");                                                                                         
        return questionList is {Count: 1};                                                                                                                      
    }  
    
    /// <summary>
    /// Checks if the file with the <see cref="XmlModel"/>'s file name has a question text.
    /// </summary>
    /// <returns><c>true</c> if the file has question text; otherwise <c>false</c>.</returns>
    private bool HasQuestionText(){                                                                                                                                                        
        var questionTextNodeList = _xmlFile.GetElementsByTagName("questiontext");                                                                             
        return questionTextNodeList is {Count: 1};                                                                                                              
    } 
    
    /// <summary>
    /// Gets the parameters from a XML node.
    /// </summary>
    /// <param name="textNode">An instance of <see cref="XmlNode"/></param>
    /// <returns>The list of parameters contained into the node.</returns>
    private static List<string> GetParametersFromXmlNode(XmlNode textNode){
        var questionText = textNode.InnerText;                                                                                                               
        var parametersList = new List<string>();                                                                                                             
        foreach (Match match in Regex.Matches(questionText, Pattern))                                                                                                   
            parametersList.Add(match.Groups[2].Value);                                                                                                       
        return parametersList;                                                                                                                               
    }

    /// <inheritdoc/>
    public void TakeParameters(){                                                                                                                                                        
        var questionTextNodeList = _xmlFile.GetElementsByTagName("questiontext");
        QuestionParametersList = GetParametersFromXmlNode(questionTextNodeList.Item(0)!).Distinct();

        //for matching questions                                                                                                                             
        var subQuestionNodeList = _xmlFile.GetElementsByTagName("subquestion");                                                                               
        if (subQuestionNodeList.Count != 0)                                                                                                                  
        {                                                                                                                                                    
            var subQuestionParametersList = new List<string>();                                                                                              
            foreach (XmlNode subQuestion in subQuestionNodeList)                                                                                             
                subQuestionParametersList.AddRange(GetParametersFromXmlNode(subQuestion));                                                                   
            subQuestionParametersList.AddRange(QuestionParametersList);                                                                                      
            QuestionParametersList = subQuestionParametersList;                                                                                              
        }                                                                                                                                                    
                                                                                                                                                             
        var answerParametersList = new List<string>();                                                                                                       
        var answerList = _xmlFile.GetElementsByTagName("answer"); 
        foreach (XmlNode answer in answerList) 
            answerParametersList.AddRange(GetParametersFromXmlNode(answer));
        AnswerParametersList = answerParametersList.Distinct();                                                                                              
    }

    /// <inheritdoc cref="ITemplateModel.Validate" />
    public void Validate(){
        if (!IsXml(file))
            throw new ReplicatorException(Error.NonXmlFile);
        if (!IsWellFormattedXml())
            throw new ReplicatorException(Error.XmlBadFormed);
        if (!HasOnlyOneQuestion())
            throw new ReplicatorException(Error.ZeroOrMoreQuestions);
        if (!HasQuestionText())
            throw new ReplicatorException(Error.ZeroOrMoreQuestions);
    }
}