using System.Text.RegularExpressions;
using AikenDoc;

namespace MoodleAssistant.Logic.Processing.Aiken;

/// <summary>
/// Analyzes a template question document in Aiken format.
/// </summary>
public class AikenAnalyzer : IAnalyzer{
    /// <summary>
    /// The parameters' regex pattern.
    /// </summary>
    private const string Pattern = @"(\[\*\[\[)([^\]\*\]\]]+)(\]\]\*\])";

    /// <summary>
    /// Checks if the Aiken file has questions.
    /// </summary>
    /// <param name="doc"> The Aiken file.</param>
    /// <returns><c>true</c> if questions are present; otherwise <c>false</c>.</returns>
    private static bool HasQuestion(AikenDocument doc){
        return doc.Questions.Count > 0;
    }

    /// <inheritdoc/>
    public string GetFormattedQuestionText(object doc){
        if(doc is not AikenDocument file || !HasQuestion(file))
            return string.Empty;
        
        var htmlFormatted = "";
        var questionText = file.Questions[0].Text;
        foreach (Match match in Regex.Matches(questionText, Pattern))
            questionText = questionText.Replace(match.Value, "<span class=\"code\">" + System.Web.HttpUtility.HtmlEncode(match.Value) + "</span>");
        htmlFormatted += questionText;

        return htmlFormatted;
    }

    /// <inheritdoc/>
    public string GetFormattedAnswers(object doc){
        if(doc is not AikenDocument file || !HasQuestion(file))
            return string.Empty;
        
        var htmlFormatted = "";
        var question = file.Questions.First();
        foreach (var option in question.Options){
            var answerText = option.Text;
            foreach (Match match in Regex.Matches(answerText, Pattern))
                answerText = answerText.Replace(match.Value, "<span class=\"code\">" + System.Web.HttpUtility.HtmlEncode(match.Value) + "</span>");
            htmlFormatted += $"<p>{option.Letter}) {answerText}</p>";
        }

        return htmlFormatted;
    }
}