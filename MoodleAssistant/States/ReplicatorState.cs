using System.Xml;

namespace MoodleAssistant.Services;

public class ReplicatorState{
    public XmlDocument TemplateQuestion{ get; set; }
    public IEnumerable<string[]> CsvAsList{ get; set; }
}