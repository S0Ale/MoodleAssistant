using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace MoodleAssistant.Classes.Parse;

public class ParameterParser(string str) {
    private const string Pattern = @"\[\*\[\[((?!FILE-)[^\]*\]]+?)\]\]\*\]|\[\*\[\[FILE-([^\]*\]]+?)\]\]\*\]";

    public string Str{ get; set; } = str;

    public IEnumerable<Parameter> Match(){
        var list = new List<Parameter>();
        var matches = Regex.Matches(Str, Pattern);

        foreach (Match match in matches){
            var p = match.Groups[2].Success ? new FileParameter(match) : new Parameter(match);
            list.Add(p);
        }

        return list;
    }

    public string Replace(IEnumerable<Parameter> parameters) {
        var builder = new StringBuilder(Str);
        foreach (var parameter in parameters.Reverse()) { // don't need to update indexes
            builder = parameter.Replace(builder);
        }
        return builder.ToString();
    }
}