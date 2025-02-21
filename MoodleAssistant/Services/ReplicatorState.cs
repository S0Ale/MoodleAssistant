using System.Xml;
using MoodleAssistant.Logic.Processing;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Services;

/// <summary>
/// Represents the current state of the program, during the current user session.
/// </summary>
public class ReplicatorState : IDisposable{
    /// <summary>
    /// Gets or sets the factory for the replicator components.
    /// </summary>
    public IReplicatorFactory? Factory;
    
    /// <summary>
    /// Gets or sets the format of the current template question.
    /// </summary>
    public Format Format{ get; set; } = Format.Xml;

    /// <summary>
    /// Gets or sets the preview model of the current merged question (if any).
    /// </summary>
    public IPreviewHandler? Preview{ get; set; }
    
    /// <summary>
    /// Gets or sets the parameters model of the current merged question (if any).
    /// </summary>
    public IParameterHandler? Parameters{ get; set; }
    
    /// <summary>
    /// Gets or sets the CSV file as a list of string arrays.
    /// </summary>
    public IEnumerable<string[]> CsvAsList{ get; set; } = [];
    
    /// <summary>
    /// Gets or sets the template document.
    /// </summary>
    public object Template{ get; set; } = null!;

    /// <summary>
    /// Gets or sets the merged document.
    /// </summary>
    public object? Merged{ get; set; }

    /// <summary>
    /// Resets the state of the program.
    /// </summary>
    public void Reset(){
        Preview = null;
        Parameters = null;
        CsvAsList = [];
        Merged = null;
    }

    /// <summary>
    /// Disposes the current state of the program.
    /// </summary>
    public void Dispose(){
        Reset();
    }
}