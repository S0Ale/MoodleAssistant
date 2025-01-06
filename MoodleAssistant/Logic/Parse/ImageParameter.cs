using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Logic.Parse;

/// <summary>
/// Represents an image-type parameter in a template question.
/// </summary>
public class ImageParameter : FileParameter{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageParameter"/> class.
    /// </summary>
    /// <param name="m">The <see cref="System.Text.RegularExpressions.Match"/> object containing the regex match information.</param>
    public ImageParameter(Match m) : base(m){
        Name = $"IMAGE-{m.Groups[3].Value}";
    }
    
    /// <summary>
    /// Replace the matched text in the provided <see cref="StringBuilder"/> with a replacement value.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> containing the text to be replaced.</param>
    /// <returns>The modified <see cref="StringBuilder"/> with the replacement text.</returns>
    public override StringBuilder Replace(StringBuilder builder){
        builder = builder.Remove(Match.Index, Match.Length);
        builder = builder.Insert(Match.Index, $"<img src=\"@@PLUGINFILE@@/{Replacement}\" />");
        return builder;
    }
}