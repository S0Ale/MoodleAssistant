using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Models;

public class MainModel{
    private Dictionary<string, bool> _sections = new() {
        { "RenderParameters", false }
    };

    public Error Error { get; set; }

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
