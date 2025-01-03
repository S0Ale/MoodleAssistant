using System.Xml;
using MoodleAssistant.Logic.Models;

namespace MoodleAssistant.Services;

/// <summary>
/// Represents the current state of the program, during the current user session.
/// </summary>
public class ReplicatorState : IDisposable{
    public PreviewModel? Preview{ get; set; }
    public ParameterModel? Parameters{ get; set; }

    public IEnumerable<string[]> CsvAsList{ get; set; } = [];

    public XmlDocument Template{ get; set; } = new XmlDocument();
    public XmlDocument? Merged{ get; set; }
    
    public int AnswerCount { get; set; }

    public void Reset(){
        Preview = null;
        Parameters = null;
        CsvAsList = [];
        Merged = null;
    }

    public void Dispose(){
        Reset();
    }
}