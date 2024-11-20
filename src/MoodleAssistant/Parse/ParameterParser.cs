using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Parse;

public class ParameterParser(string str) {
    private const string Pattern = @"\[\*\[\[((?!FILE-)[^\]*\]]+?)\]\]\*\]|\[\*\[\[FILE-([^\]*\]]+?)\]\]\*\]";

    public IEnumerable<Parameter> Match(){
        var list = new List<Parameter>();
        var matches = Regex.Matches(str, Pattern);

        foreach (Match match in matches){
            var p = match.Groups[2].Success ? new FileParameter(match) : new Parameter(match);
            list.Add(p);
        }

        return list;
    }

    public string Replace(IEnumerable<Parameter> parameters) {
        var builder = new StringBuilder(str);
        foreach (var parameter in parameters.Reverse()) { // don't need to update indexes
            builder = builder.Remove(parameter.StartI, parameter.Match.Length);
            builder = builder.Insert(parameter.StartI, parameter.Replacement);
        }
        return builder.ToString();
    }
}
