using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Classes.Parse;

public class Parameter(Match m){
    public string Name{ get; protected init; } = m.Groups[1].Value;
    public Match Match { get; } = m;
    public string Replacement{ get; set; } = string.Empty;
    
    public Parameter(Match m, string name) : this(m){
        Name = name;
    }
    
    public virtual StringBuilder Replace(StringBuilder builder){
        builder = builder.Remove(Match.Index, Match.Length);
        builder = builder.Insert(Match.Index, Replacement);
        return builder;
    }
} 