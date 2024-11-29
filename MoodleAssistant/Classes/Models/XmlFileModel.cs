using System.IO.Pipelines;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Services;

namespace MoodleAssistant.Classes.Models;

public class XmlFileModel(FileService fileService){
    private const string Pattern = @"(\[\*\[\[)([^\]\*\]\]]+)(\]\]\*\])";
    public IBrowserFile XmlQuestion{ get; init; }

    public XmlDocument XmlFile{ get; set; }
    public IEnumerable<string> QuestionParametersList{ get; private set; }
    public IEnumerable<string> AnswerParametersList{ get; private set; }
    public int AnswerCount { get; private set; }
    
    public async Task<bool> SaveFile(){
        return await fileService.SaveFile(XmlQuestion, "XML");
    }

    public bool IsXml()
    {
        return System.Net.Mime.MediaTypeNames.Text.Xml == XmlQuestion.ContentType;
    }
    public bool IsEmpty(){
        var info = fileService.GetFileInfo("XML");
        return info.Length == 0;
    }
    public bool IsWellFormattedXml(){
        var stream = fileService.GetFile("XML");
        using var reader = new StreamReader(stream, Encoding.UTF8);
                                                                                               
        try                                                                                    
        {                                                                                      
            XmlFile = new XmlDocument();                                                       
            XmlFile.LoadXml(reader.ReadToEnd());                                         
            return true;                                                                       
        }                                                                                      
        catch (XmlException)                                                                   
        {                                                                                      
            return false;                                                                      
        }                                                                                      
    }                                                                                          
    public bool HasOnlyOneQuestion()                                                                                                                         
    {                                                                                                                                                        
        var questionList = XmlFile.GetElementsByTagName("question");                                                                                         
        return questionList.Count == 1;                                                                                                                      
    }                                                                                                                                                        
    public bool HasQuestionText()                                                                                                                            
    {                                                                                                                                                        
        var questiontextNodeList = XmlFile.GetElementsByTagName("questiontext");                                                                             
        return questiontextNodeList.Count == 1;                                                                                                              
    }                                                                                                                                                        
    public string GetFormattedQuestionText()                                                                                                                 
    {                                                                                                                                                        
        if(!HasQuestionText())                                                                                                                               
            return string.Empty;                                                                                                                             
        var questiontextNode = XmlFile.GetElementsByTagName("questiontext").Item(0);                                                                         
        if (questiontextNode == null)                                                                                                                        
            return string.Empty;                                                                                                                             
                                                                                                                                                             
        var htmlFormatted = "";
        var questiontext = questiontextNode.SelectSingleNode("text").InnerText;
        var rgx = new Regex(Pattern);                                                                                                                        
        foreach (Match match in rgx.Matches(questiontext))                                                                                                   
            questiontext = questiontext.Replace(match.Value, "<span class=\"code\">" + System.Web.HttpUtility.HtmlEncode(match.Value) + "</span>");          
        htmlFormatted += questiontext;                                                                                                                       
        return htmlFormatted;                                                                                                                                
                                                                                                                                                             
    }                                                                                                                                                        
    public string GetFormattedAnswers()                                                                                                                      
    {                                                                                                                                                        
        if (!HasAnswer())                                                                                                                                    
            return string.Empty;                                                                                                                             
        var htmlFormatted = "";                                                                                                                              
        var answerTextNodeList = XmlFile.GetElementsByTagName("answer");                                                                                     
        var rgx = new Regex(Pattern);                                                                                                                        
        foreach (XmlNode answerTextNode in answerTextNodeList)                                                                                               
        {                                                                                                                                                    
            if (answerTextNode == null)                                                                                                                      
                continue;                                                                                                                                    
            htmlFormatted += "<p>";                                                                                                                          
            foreach (XmlNode node in answerTextNode.SelectNodes("text"))                                                                                     
            {                                                                                                                                                
                var answerText = node.InnerText;                                                                                                             
                foreach (Match match in rgx.Matches(answerText))                                                                                             
                    answerText = answerText.Replace(match.Value, "<span class=\"code\">" + System.Web.HttpUtility.HtmlEncode(match.Value) + "</span>");      
                htmlFormatted += answerText;                                                                                                                 
            }                                                                                                                                                
            htmlFormatted += "</p>";                                                                                                                         
        }                                                                                                                                                    
        return htmlFormatted;                                                                                                                                
    }                                                                                                                                                        
    public bool HasAnswer()                                                                                                                                  
    {                                                                                                                                                        
        var answerList = XmlFile.GetElementsByTagName("answer");                                                                                             
        return answerList.Count > 0;                                                                                                                         
    }                                                                                                                                                        
    public void TakeParameters()                                                                                                                             
    {                                                                                                                                                        
        var questiontextNodeList = XmlFile.GetElementsByTagName("questiontext");                                                                             
        QuestionParametersList = GetParametersFromXmlNode(questiontextNodeList.Item(0)).Distinct();                                                          
                                                                                                                                                             
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
    private static IEnumerable<string> GetParametersFromXmlNode(XmlNode textNode)                                                                            
    {                                                                                                                                                        
        if (null == textNode)                                                                                                                                
            return new List<string>();                                                                                                                       
                                                                                                                                                             
        var questionText = textNode.InnerText;                                                                                                               
        var rgx = new Regex(Pattern);                                                                                                                        
        var parametersList = new List<string>();                                                                                                             
        foreach (Match match in rgx.Matches(questionText))                                                                                                   
            parametersList.Add(match.Groups[2].Value);                                                                                                       
        return parametersList;                                                                                                                               
                                                                                                                                                             
    }                                                                                                                                                        
}