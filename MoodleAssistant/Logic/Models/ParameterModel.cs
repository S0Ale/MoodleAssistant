using System.Xml;
using MoodleAssistant.Logic.Parse;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Represents the parameters of the XML document.
/// </summary>
/// <param name="doc">A <see cref="XmlDocument"/> instance.</param>
/// <param name="csvRows">The number of csv rows in the CSV file.</param>
public class ParameterModel(XmlDocument doc, int csvRows){
    /// <summary>
    /// The parameters of the XML document.
    /// </summary>
    private readonly List<Parameter>? _param = new ParameterParser(doc.OuterXml).Match() as List<Parameter>;
    /// <summary>
    /// Gets the number of needed files.
    /// </summary>
    public int NeededFiles{ get; } = csvRows;

    /// <summary>
    /// Gets the file-type parameters in the XML document.
    /// </summary>
    /// <returns>A list of the file-type parameters.</returns>
    public List<Parameter> GetFileParameters(){
        var fileParams = (_param ?? []).Where(p => p is FileParameter or ImageParameter).ToList();
        return fileParams;
    }
}