﻿using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Logic.Parse;

/// <summary>
/// Represents an image-type parameter in a template question.
/// </summary>
public class ImageParameter : FileParameter{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageParameter"/> class.
    /// </summary>
    /// <inheritdoc/>
    public ImageParameter(Match m) : base(m){
        Name = $"IMAGE-{m.Groups[3].Value}";
    }
    
    /// <inheritdoc/>
    public override StringBuilder Replace(StringBuilder builder){
        builder = builder.Remove(Match.Index, Match.Length);
        builder = builder.Insert(Match.Index, $"<img src=\"@@PLUGINFILE@@/{Replacement}\" />");
        return builder;
    }
}