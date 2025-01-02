using System.Xml;
using MoodleAssistant.Classes.Models;

namespace MoodleAssistant.Services;

/// <summary>
/// Represents the current state of the program, during the current user session.
/// </summary>
public class ReplicatorState : IDisposable{
    public PreviewModel? Preview{ get; set; }
    public ParameterModel? Parameters{ get; set; }
    public XmlFileModel? XmlModel{ get; set; }

    public IEnumerable<string[]> CsvAsList{ get; set; } = [];
    
    public XmlDocument? Merged{ get; set; }

    public void Reset(){
        Preview = null;
        Parameters = null;
        XmlModel = null;
        CsvAsList = [];
        Merged = null;
    }

    public void Dispose(){
        Reset();
    }
}