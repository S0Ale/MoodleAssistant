using MoodleAssistant.Logic.Parse;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Manager for the parameters of the template document.
/// </summary>
public interface IParameterModel{
    /// <summary>
    /// Gets the number of needed files.
    /// </summary>
    public int NeededFiles{ get; }
    
    /// <summary>
    /// Gets the file-type parameters in the template document.
    /// </summary>
    /// <returns>A list of the file-type parameters.</returns>
    public List<Parameter> GetFileParameters();
}