using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Logic.Parse;

/// <summary>
/// Represents a file-type parameter in a template question.
/// </summary>
public class FileParameter : Parameter{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileParameter"/> class.
    /// </summary>
    /// <param name="m">The <see cref="System.Text.RegularExpressions.Match"/> object containing the regex match information.</param>
    public FileParameter(Match m) : base(m){
        Name = $"FILE-{m.Groups[2].Value}";
    }
    
    /// <summary>
    /// Replaces the matched text in the provided <see cref="StringBuilder"/> with a replacement value.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> containing the text to be replaced.</param>
    /// <returns>The modified <see cref="StringBuilder"/> with the replacement text.</returns>
    public override StringBuilder Replace(StringBuilder builder){
        builder = builder.Remove(Match.Index, Match.Length);
        builder = builder.Insert(Match.Index, $"<a href=\"@@PLUGINFILE@@/{Replacement}\">{Replacement}</a>");
        return builder;
    }
}