using System.Collections.Generic;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Models;

public class MainModel{
    public XmlFileModel XmlModel { get; set; }
    public IEnumerable<string[]> CsvList { get; set; }

    private Dictionary<string, bool> _sections = new() { // section list
        { "RenderParameters", false }
    };

    public Error Error { get; set; } // page error

    public bool RenderParameters{
        get => _sections["RenderParameters"];
        set{
            ResetSections();
            _sections["RenderParameters"] = value;
        }
    }

    private void ResetSections() {
        foreach (var key in _sections.Keys)
            _sections[key] = false;
    }
}
