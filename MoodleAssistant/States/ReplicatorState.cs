using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Models;

namespace MoodleAssistant.Services;

public class ReplicatorState{
    //public IBrowserFile FormXml{ get; set; }
    //public IBrowserFile FormCsv{ get; set; }
    public IDictionary<string, IBrowserFile?> Files{ get; } = new Dictionary<string, IBrowserFile?>();
    
    public XmlFileModel XmlModel{ get; set; }
    public IEnumerable<string[]> CsvAsList{ get; set; }
}