using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Models;

namespace MoodleAssistant.Services;

public class ReplicatorState{
    public Dictionary<string, IBrowserFile> MainFiles{ get; private set; } = new Dictionary<string, IBrowserFile>();
    public Dictionary<string, IBrowserFile[]> ParamFiles{ get; private set; } = new Dictionary<string, IBrowserFile[]>();
    
    public PreviewModel? Preview{ get; set; }
    public ParameterModel? FileParam{ get; set; }
    public XmlFileModel? XmlModel{ get; set; }

    public IEnumerable<string[]> CsvAsList{ get; set; } = [];
    
    public XmlDocument? Merged{ get; set; }
}