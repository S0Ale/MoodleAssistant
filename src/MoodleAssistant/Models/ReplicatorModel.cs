using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Models;

public class ReplicatorModel{
    public XmlFileModel XmlModel { get; set; }
    public PreviewModel Preview{ get; set; }
    public FileParameterModel FileParameters{ get; set; }

    private readonly Dictionary<string, bool> _sections = new() { // section list
        { "RenderParameters", false },
        { "RenderPreview", false },
        { "RenderFilePrompt", false},
        { "RenderDownloadBtn", false }
    };

    public Error Error { get; set; } // page error

    public bool RenderParameters{
        get => _sections["RenderParameters"];
        set{
            ResetSections();
            _sections["RenderParameters"] = value;
        }
    }
    public bool RenderPreview{
        get => _sections["RenderPreview"];
        set => _sections["RenderPreview"] = value;
    }
    public bool RenderFilePrompt{
        get => _sections["RenderFilePrompt"];
        set => _sections["RenderFilePrompt"] = value;
    }
    public bool RenderDownloadBtn{
        get => _sections["RenderDownloadBtn"];
        set => _sections["RenderDownloadBtn"] = value;
    }

    private void ResetSections() {
        foreach (var key in _sections.Keys)
            _sections[key] = false;
    }
}
