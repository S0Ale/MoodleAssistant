using System.Text.RegularExpressions;
using System.Xml;

namespace MoodleAssistant.Logic.Processing.XML;

/// <summary>
/// Analyzes a template question document in XML format.
/// </summary>
public class XmlAnalyzer : IAnalyzer{
    /// <summary>
    /// The parameters' regex pattern.
    /// </summary>
    private const string Pattern = @"(\[\*\[\[)([^\]\*\]\]]+)(\]\]\*\])";
    
    /// <summary>
    /// Checks if the XML file has a question text.
    /// </summary>
    /// <param name="file">The XML file.</param>
    /// <returns><c>true</c> if question text is present; otherwise <c>false</c>.</returns>
    private bool HasQuestionText(XmlDocument file){                                                                                                                                                        
        var questionTextNodeList = file.GetElementsByTagName("questiontext");                                                                             
        return questionTextNodeList is {Count: 1};                                                                                                              
    }
    
    /// <summary>
    /// Checks if the XML file has at least one answer.
    /// </summary>
    /// <param name="file">The XML file.</param>
    /// <returns><c>true</c> if one or more answers are present; otherwise <c>false</c>.</returns>
    private bool HasAnswer(XmlDocument file){                                                                                                                                                        
        var answerList = file.GetElementsByTagName("answer");                                                                                             
        return answerList is {Count: > 0};                                                                                                                         
    }
    
    /// <inheritdoc/>
    public string GetFormattedQuestionText(object doc){
        if(doc is not XmlDocument file || !HasQuestionText(file))                                                                                                                       
            return string.Empty;  
        
        var questionTextNode = file.GetElementsByTagName("questiontext").Item(0);                                                                         
        if (questionTextNode == null)                                                                                                                        
            return string.Empty;                                                                                                                             
                                                                                                                                                             
        var htmlFormatted = "";
        var questionText = questionTextNode.SelectSingleNode("text")?.InnerText ?? "";
        foreach (Match match in Regex.Matches(questionText, Pattern))                                                                                                   
            questionText = questionText.Replace(match.Value, "<span class=\"code\">" + System.Web.HttpUtility.HtmlEncode(match.Value) + "</span>");          
        htmlFormatted += questionText;                                                                                                                       
        return htmlFormatted; 
    }

    /// <inheritdoc/>
    public string GetFormattedAnswers(object doc){
        if (doc is not XmlDocument file || !HasAnswer(file))                                                                                                                                    
            return string.Empty;
        
        var htmlFormatted = "";                                                                                                                              
        var answerTextNodeList = file.GetElementsByTagName("answer");
        foreach (XmlNode answerTextNode in answerTextNodeList){
            if (answerTextNode == null)
                continue;
            htmlFormatted += "<p>";
            foreach (XmlNode node in answerTextNode.SelectNodes("text")!){
                var answerText = node.InnerText;
                foreach (Match match in Regex.Matches(answerText, Pattern))
                    answerText = answerText.Replace(match.Value,
                        "<span class=\"code\">" + System.Web.HttpUtility.HtmlEncode(match.Value) + "</span>");
                htmlFormatted += answerText;
            }

            htmlFormatted += "</p>";
        }

        return htmlFormatted;
    }
}