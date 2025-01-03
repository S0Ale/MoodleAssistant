using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Logic.Parse;

/// <summary>
/// Represents a parameter in a template question.
/// </summary>
/// <param name="m">The match (of a Regular expression) of the parameter in the template question.</param>
public class Parameter(Match m){
    public string Name{ get; protected init; } = m.Groups[1].Value;
    public Match Match { get; } = m;
    public string Replacement{ get; set; } = string.Empty;
    
    public Parameter(Match m, string name) : this(m){
        Name = name;
    }
    
    /// <summary>
    /// Replace the parameter in the template question with the replacement value.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> instance used to replace the parameter.</param>
    /// <returns>The <see cref="StringBuilder"/> instance with the parameter replaced.</returns>
    public virtual StringBuilder Replace(StringBuilder builder){
        builder = builder.Remove(Match.Index, Match.Length);
        builder = builder.Insert(Match.Index, Replacement);
        return builder;
    }
} 