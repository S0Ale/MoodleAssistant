using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Models;

namespace MoodleAssistant.Services;

public class ReplicatorState{
    //public IBrowserFile FormXml{ get; set; }
    //public IBrowserFile FormCsv{ get; set; }
    public IDictionary<string, IBrowserFile?> MainFiles{ get; private set; } = new Dictionary<string, IBrowserFile?>();
    public IDictionary<string, IBrowserFile[]> ParamFiles{ get; private set; } = new Dictionary<string, IBrowserFile[]>();
    
    public PreviewModel? Preview{ get; private set; }
    public FileParameterModel? FileParam{ get; set; }
    public XmlFileModel? XmlModel{ get; set; }
    public IEnumerable<string[]>? CsvAsList{ get; set; }
    
    public XmlDocument? Merged{ get; set; }

    public void Clear(){
        MainFiles = new Dictionary<string, IBrowserFile?>();
        ParamFiles = new Dictionary<string, IBrowserFile[]>();
        
        Preview = null;
        FileParam = null;
        XmlModel = null;
        CsvAsList = null;
        Merged = null;
    }
}