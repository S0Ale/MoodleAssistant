using System.Xml;
using MoodleAssistant.Logic;
using MoodleAssistant.Logic.Models;

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
    /// Gets or sets the preview model of the current merged question (if any).
    /// </summary>
    public PreviewModel? Preview{ get; set; }
    
    /// <summary>
    /// Gets or sets the parameters model of the current merged question (if any).
    /// </summary>
    public IParameterModel? Parameters{ get; set; }
    
    /// <summary>
    /// Gets or sets the CSV file as a list of string arrays.
    /// </summary>
    public IEnumerable<string[]> CsvAsList{ get; set; } = [];
    
    /// <summary>
    /// Gets or sets the template XML document.
    /// </summary>
    public XmlDocument Template{ get; set; } = new XmlDocument();
    
    /// <summary>
    /// Gets or sets the merged XML document.
    /// </summary>
    public XmlDocument? Merged{ get; set; }
    
    /// <summary>
    /// Gets or sets the number of answers in the template question.
    /// </summary>
    public int AnswerCount { get; set; }

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