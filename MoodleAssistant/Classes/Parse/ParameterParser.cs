using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace MoodleAssistant.Classes.Parse;

public partial class ParameterParser(string str) {
    private const string Pattern =
        @"\[\*\[\[((?!FILE-|IMAGE-)[^\]*\]]+?)\]\]\*\]|\[\*\[\[FILE-([^\]*\]]+?)\]\]\*\]|\[\*\[\[IMAGE-([^\]*\]]+?)\]\]\*\]";
    [GeneratedRegex(Pattern)]
    private static partial Regex ParameterPattern();

    private string Str{ get; set; } = str;

    public IEnumerable<Parameter> Match(){
        var list = new List<Parameter>();
        var matches = ParameterPattern().Matches(Str);

        foreach (Match match in matches){
            //var p = match.Groups[2].Success ? new FileParameter(match) : new Parameter(match);
            if (match.Groups[3].Success){
                list.Add(new ImageParameter(match));
            }else if(match.Groups[2].Success){
                list.Add(new FileParameter(match));
            }else{
                list.Add(new Parameter(match));
            }
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