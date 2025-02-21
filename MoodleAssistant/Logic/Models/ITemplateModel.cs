using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Manages the validation process of the template question.
/// </summary>
public interface ITemplateModel{
    /// <summary>
    /// Gets the template document.
    /// </summary>
    public object TemplateDocument{ get; }
    
    /// <summary>
    /// Gets the parameters found in the question text.
    /// </summary>
    public IEnumerable<string> QuestionParametersList{ get; protected set; }
    
    /// <summary>
    /// Gets the parameters found in the answers.
    /// </summary>
    public IEnumerable<string> AnswerParametersList{ get; protected set; }
    
    /// <summary>
    /// Validates the template file contained in the model.
    /// </summary>
    /// <exception cref="ReplicatorException">Thrown when a validation error occurs.</exception>
    public Task Validate();
    
    /// <summary>
    /// Gets the parameters from the XML file and puts them in the <see cref="QuestionParametersList"/> and <see cref="AnswerParametersList"/>.
    /// </summary>
    public void TakeParameters();
}