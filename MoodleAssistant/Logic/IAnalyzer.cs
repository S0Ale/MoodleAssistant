namespace MoodleAssistant.Logic;

/// <summary>
/// Manages the analysis of the template question document.
/// </summary>
public interface IAnalyzer{
    
    /// <summary>
    /// Gets the HTML formatted question text from the document.
    /// </summary>
    /// <param name="doc">The template question document.</param>
    /// <returns>The HTML formatted string.</returns>
    public string GetFormattedQuestionText(object doc);
    
    /// <summary>
    /// Gets the HTML formatted answers from the document.
    /// </summary>
    /// <param name="doc">The template question document.</param>
    /// <returns>The HTML formatted string.</returns>
    public string GetFormattedAnswers(object doc);
}