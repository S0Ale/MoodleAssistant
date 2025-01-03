using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic.Models;

// This class is used to manage the XML file uploaded by the user: format parts for analysis, validation.
public class XmlFileModel(IBrowserFileService fileService){
    public static string FileName => "XML";
    private const string Pattern = @"(\[\*\[\[)([^\]\*\]\]]+)(\]\]\*\])";

    public XmlDocument XmlFile{ get; private set; } = new();
    public IEnumerable<string> QuestionParametersList{ get; private set; } = [];
    public IEnumerable<string> AnswerParametersList{ get; private set; } = [];
    public int AnswerCount { get; private set; }

    public static bool IsXml(IBrowserFile file)
    {
        return System.Net.Mime.MediaTypeNames.Text.Xml == file.ContentType;
    }
    
    public bool IsEmpty(){
        return fileService.IsEmpty(FileName);
    }
    
    public bool IsWellFormattedXml(){
        var stream = fileService.GetFile(FileName);
        using var reader = new StreamReader(stream, Encoding.UTF8);
                                                                                               
        try{                                                                                      
            XmlFile = new XmlDocument();                                                       
            XmlFile.LoadXml(reader.ReadToEnd());                                         
            return true;                                                                       
        }                                                                                      
        catch (XmlException){                                                                                      
            return false;                                                                      
        }                                                                                      
    }
    
    public bool HasOnlyOneQuestion(){                                                                                                                                                        
        var questionList = XmlFile.GetElementsByTagName("question");                                                                                         
        return questionList is {Count: 1};                                                                                                                      
    }  
    
    public bool HasQuestionText(){                                                                                                                                                        
        var questionTextNodeList = XmlFile.GetElementsByTagName("questiontext");                                                                             
        return questionTextNodeList is {Count: 1};                                                                                                              
    } 
    
    public void TakeParameters(){                                                                                                                                                        
        var questionTextNodeList = XmlFile.GetElementsByTagName("questiontext");
        QuestionParametersList = GetParametersFromXmlNode(questionTextNodeList.Item(0)!).Distinct();

        //for matching questions                                                                                                                             
        var subQuestionNodeList = XmlFile.GetElementsByTagName("subquestion");                                                                               
        if (subQuestionNodeList.Count != 0)                                                                                                                  
        {                                                                                                                                                    
            var subQuestionParametersList = new List<string>();                                                                                              
            foreach (XmlNode subQuestion in subQuestionNodeList)                                                                                             
                subQuestionParametersList.AddRange(GetParametersFromXmlNode(subQuestion));                                                                   
            subQuestionParametersList.AddRange(QuestionParametersList);                                                                                      
            QuestionParametersList = subQuestionParametersList;                                                                                              
        }                                                                                                                                                    
                                                                                                                                                             
        var answerParametersList = new List<string>();                                                                                                       
        var answerList = XmlFile.GetElementsByTagName("answer");                                                                                             
        AnswerCount = answerList.Count;
        foreach (XmlNode answer in answerList) 
            answerParametersList.AddRange(GetParametersFromXmlNode(answer));
        AnswerParametersList = answerParametersList.Distinct();                                                                                              
    }
    
    private static List<string> GetParametersFromXmlNode(XmlNode textNode){
        var questionText = textNode.InnerText;                                                                                                               
        var parametersList = new List<string>();                                                                                                             
        foreach (Match match in Regex.Matches(questionText, Pattern))                                                                                                   
            parametersList.Add(match.Groups[2].Value);                                                                                                       
        return parametersList;                                                                                                                               
                                                                                                                                                             
    }
}