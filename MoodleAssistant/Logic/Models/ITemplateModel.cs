namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Represents a validation model for the template question.
/// </summary>
public interface ITemplateModel{
    
    /// <summary>
    /// Gets the parameters found in the question text.
    /// </summary>
    public IEnumerable<string> QuestionParametersList{ get; protected set; }
    
    /// <summary>
    /// Gets the parameters found in the answers.
    /// </summary>
    public IEnumerable<string> AnswerParametersList{ get; protected set; }
    
    /// <summary>
    /// Gets the parameters from the XML file and puts them in the <see cref="QuestionParametersList"/> and <see cref="AnswerParametersList"/>.
    /// </summary>
    public void TakeParameters();
}