using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Logic.Parse;

/// <summary>
/// Represents a parameter in a template question.
/// </summary>
/// <param name="m">The match (of a Regular expression) of the parameter in the template question.</param>
public class Parameter(Match m){
    /// <summary>
    /// Gets or sets the name of the parameter.
    /// </summary>
    public string Name{ get; protected init; } = m.Groups[1].Value;
    
    /// <summary>
    /// Gets the match object containing the regex match information.
    /// </summary>
    public Match Match { get; } = m;
    
    /// <summary>
    /// Gets or sets the replacement value for the parameter.
    /// </summary>
    public string Replacement{ get; set; } = string.Empty;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Parameter"/> class with the specified match and name.
    /// </summary>
    /// <param name="m">The <see cref="System.Text.RegularExpressions.Match"/> object containing the regex match information.</param>
    /// <param name="name">The name of the parameter.</param>
    public Parameter(Match m, string name) : this(m){
        Name = name;
    }
    
    /// <summary>
    /// Replaces the matched text in the provided <see cref="StringBuilder"/> with a replacement value.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> containing the text to be replaced.</param>
    /// <returns>The modified <see cref="StringBuilder"/> with the replacement text.</returns>
    public virtual StringBuilder Replace(StringBuilder builder){
        builder = builder.Remove(Match.Index, Match.Length);
        builder = builder.Insert(Match.Index, Replacement);
        return builder;
    }
} 