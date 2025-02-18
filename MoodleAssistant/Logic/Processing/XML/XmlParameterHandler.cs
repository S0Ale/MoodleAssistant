using System.Xml;
using MoodleAssistant.Logic.Parse;

namespace MoodleAssistant.Logic.Processing.XML;

/// <summary>
/// Represents the parameters of the XML document.
/// </summary>
/// <param name="doc">A <see cref="XmlDocument"/> instance.</param>
/// <param name="csvRows">The number of csv rows in the CSV file.</param>
public class XmlParameterHandler(XmlDocument doc, int csvRows) : IParameterHandler{
    /// <summary>
    /// The parameters of the XML document.
    /// </summary>
    private readonly List<Parameter>? _param = new ParameterParser(doc.OuterXml).Match() as List<Parameter>;

    /// <inheritdoc/>
    public int NeededFiles{ get; } = csvRows;

    /// <inheritdoc/>
    public List<Parameter> GetFileParameters(){
        var fileParams = (_param ?? []).Where(p => p is FileParameter or ImageParameter).ToList();
        return fileParams;
    }
}