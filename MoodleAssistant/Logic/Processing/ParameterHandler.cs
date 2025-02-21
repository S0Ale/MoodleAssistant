using MoodleAssistant.Logic.Parse;

namespace MoodleAssistant.Logic.Processing;

/// <summary>
/// Manager for the parameters of the template document.
/// </summary>
public abstract class ParameterHandler(int csvRows){
    /// <summary>
    /// The parameters of the XML document.
    /// </summary>
    protected List<Parameter>? Param;
    
    /// <summary>
    /// Gets the number of needed files.
    /// </summary>
    public int NeededFiles{ get; } = csvRows;

    /// <summary>
    /// Gets the file-type parameters in the template document.
    /// </summary>
    /// <returns>A list of the file-type parameters.</returns>
    public List<Parameter> GetFileParameters(){
        var fileParams = (Param ?? []).Where(p => p is FileParameter or ImageParameter).ToList();
        return fileParams;
    }
}