using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Services;

namespace MoodleAssistant.Classes.Models;

public partial class XmlFileModel(IBrowserFileService fileService){
    public static string FileName => "XML";
    private const string Pattern = @"(\[\*\[\[)([^\]\*\]\]]+)(\]\]\*\])";
    [GeneratedRegex(Pattern)]
    private static partial Regex ParameterRegex();
    
    public XmlDocument? XmlFile{ get; private set; }
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
        var questionList = XmlFile?.GetElementsByTagName("question");                                                                                         
        return questionList is {Count: 1};                                                                                                                      
    }  
    
    public bool HasQuestionText(){                                                                                                                                                        
        var questionTextNodeList = XmlFile?.GetElementsByTagName("questiontext");                                                                             
        return questionTextNodeList is {Count: 1};                                                                                                              
    } 
    
    public string GetFormattedQuestionText(){                                                                                                                                                        
        if(!HasQuestionText())                                                                                                                               
            return string.Empty;                                                                                                                             
        var questionTextNode = XmlFile?.GetElementsByTagName("questiontext").Item(0);                                                                         
        if (questionTextNode == null)                                                                                                                        
            return string.Empty;                                                                                                                             
                                                                                                                                                             
        var htmlFormatted = "";
        var questionText = questionTextNode.SelectSingleNode("text")?.InnerText ?? "";
        var rgx = ParameterRegex();                                                                                                                        
        foreach (Match match in rgx.Matches(questionText))                                                                                                   
            questionText = questionText.Replace(match.Value, "<span class=\"code\">" + System.Web.HttpUtility.HtmlEncode(match.Value) + "</span>");          
        htmlFormatted += questionText;                                                                                                                       
        return htmlFormatted;                                                                                                                       
                                                                                                                                                             
    }
    
    public string GetFormattedAnswers(){                                                                                                                                                        
        if (!HasAnswer())                                                                                                                                    
            return string.Empty;                                                                                                                             
        var htmlFormatted = "";                                                                                                                              
        var answerTextNodeList = XmlFile?.GetElementsByTagName("answer");                                                                                     
        var rgx = ParameterRegex();
        if (answerTextNodeList == null) return htmlFormatted;
        foreach (XmlNode answerTextNode in answerTextNodeList){
            if (answerTextNode == null)
                continue;
            htmlFormatted += "<p>";
            foreach (XmlNode node in answerTextNode.SelectNodes("text")!){
                var answerText = node.InnerText;
                foreach (Match match in rgx.Matches(answerText))
                    answerText = answerText.Replace(match.Value,
                        "<span class=\"code\">" + System.Web.HttpUtility.HtmlEncode(match.Value) + "</span>");
                htmlFormatted += answerText;
            }

            htmlFormatted += "</p>";
        }

        return htmlFormatted;                                                                                                                                
    }

    private bool HasAnswer(){                                                                                                                                                        
        var answerList = XmlFile?.GetElementsByTagName("answer");                                                                                             
        return answerList is {Count: > 0};                                                                                                                         
    }   
    
    public void TakeParameters(){                                                                                                                                                        
        var questionTextNodeList = XmlFile?.GetElementsByTagName("questiontext");
        if (questionTextNodeList != null)
            QuestionParametersList = GetParametersFromXmlNode(questionTextNodeList.Item(0)!).Distinct();

        //for matching questions                                                                                                                             
        var subQuestionNodeList = XmlFile?.GetElementsByTagName("subquestion");                                                                               
        if (subQuestionNodeList != null && subQuestionNodeList.Count != 0)                                                                                                                  
        {                                                                                                                                                    
            var subQuestionParametersList = new List<string>();                                                                                              
            foreach (XmlNode subQuestion in subQuestionNodeList)                                                                                             
                subQuestionParametersList.AddRange(GetParametersFromXmlNode(subQuestion));                                                                   
            subQuestionParametersList.AddRange(QuestionParametersList);                                                                                      
            QuestionParametersList = subQuestionParametersList;                                                                                              
        }                                                                                                                                                    
                                                                                                                                                             
        var answerParametersList = new List<string>();                                                                                                       
        var answerList = XmlFile?.GetElementsByTagName("answer");                                                                                             
        AnswerCount = answerList?.Count ?? 0;
        if (answerList != null)
            foreach (XmlNode answer in answerList) answerParametersList.AddRange(GetParametersFromXmlNode(answer));
        AnswerParametersList = answerParametersList.Distinct();                                                                                              
    }
    
    private static IEnumerable<string> GetParametersFromXmlNode(XmlNode textNode){
        var questionText = textNode.InnerText;                                                                                                               
        var rgx = ParameterRegex();                                                                                                                        
        var parametersList = new List<string>();                                                                                                             
        foreach (Match match in rgx.Matches(questionText))                                                                                                   
            parametersList.Add(match.Groups[2].Value);                                                                                                       
        return parametersList;                                                                                                                               
                                                                                                                                                             
    }
}