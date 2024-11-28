using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Models;

namespace MoodleAssistant.States;

public class ReplicatorState{
    public IDictionary<string, IBrowserFile?> Files{ get; } = new Dictionary<string, IBrowserFile?>();
    
    public PreviewModel Preview{ get; set; }
    public XmlFileModel XmlModel{ get; set; }
    public IEnumerable<string[]> CsvAsList{ get; set; }
    
    public XmlDocument Merged{ get; set; }
}