using System.Text.RegularExpressions;

namespace MoodleAssistant.Classes.Parse;

public class Parameter(Match m){
    public string Name{ get; init; } = m.Groups[1].Value;
    public Match Match { get; init; } = m;
    public int StartI { get; init; } = m.Index;
    public string Replacement{ get; set; } = string.Empty;
}