﻿using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Classes.Parse;

public class FileParameter : Parameter{
    public FileParameter(Match m) : base(m){
        Name = m.Groups[2].Value;
    }
    
    public override StringBuilder Replace(StringBuilder builder){
        builder = builder.Remove(Match.Index, Match.Length);
        builder = builder.Insert(Match.Index, $"<a href=\"@@PLUGINFILE@@/{Replacement}\">{Replacement}</a>");
        return builder;
    }
}