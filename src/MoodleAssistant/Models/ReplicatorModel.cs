using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Models;

public class ReplicatorModel{
    public XmlFileModel XmlModel { get; set; }
    public PreviewModel Preview{ get; set; }

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
