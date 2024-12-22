using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Classes.Parse;

/// <summary>
/// Parses a string for parameters.
/// </summary>
/// <param name="str">The <see cref="string"/> to parse</param>
/// <param name="previewMode"></param>
public partial class ParameterParser(string str, bool previewMode = false){
    private const string Pattern =
        @"\[\*\[\[((?!FILE-|IMAGE-)[^\]*\]]+?)\]\]\*\]|\[\*\[\[FILE-([^\]*\]]+?)\]\]\*\]|\[\*\[\[IMAGE-([^\]*\]]+?)\]\]\*\]";
    [GeneratedRegex(Pattern)]
    private static partial Regex ParameterPattern();

    /// <summary>
    /// Finds all parameters in the string, and returns them as a list.
    /// </summary>
    /// <returns>A list of <see cref="Parameter"/> instances found in the string.</returns>
    public IEnumerable<Parameter> Match(){
        var list = new List<Parameter>();
        var matches = ParameterPattern().Matches(str);

        foreach (Match match in matches){
            if (!previewMode){
                if (match.Groups[3].Success){
                    list.Add(new ImageParameter(match));
                }else if (match.Groups[2].Success){
                    list.Add(new FileParameter(match));
                }else list.Add(new Parameter(match));
            }else{
                var name = match.Groups[1].Value;
                name = match.Groups[2].Success ? $"FILE-{match.Groups[2].Value}" : name;
                name = match.Groups[3].Success ? $"IMAGE-{match.Groups[3].Value}" : name;
                list.Add(new Parameter(match, name));
            }
        }

        return list;
    }

    /// <summary>
    /// Replace all parameters in the string with their replacement values.
    /// </summary>
    /// <param name="parameters">The list of <see cref="Parameter"/> to replace.</param>
    /// <returns>The string with the replaced</returns>
    public string Replace(IEnumerable<Parameter> parameters) {
        var builder = new StringBuilder(str);
        foreach (var parameter in parameters.Reverse()) { // don't need to update indexes
            builder = parameter.Replace(builder);
        }
        return builder.ToString();
    }
}