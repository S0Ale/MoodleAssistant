using System.Xml;
using MoodleAssistant.Logic.Parse;

namespace MoodleAssistant.Logic.Processing.XML;

/// <summary>
/// Manager for the parameters of the XML document.
/// </summary>
public class XmlParameterHandler : ParameterHandler{
    
    /// <summary>
    /// Initializes a new instance of <see cref="XmlParameterHandler"/>.
    /// </summary>
    /// <param name="doc">A <see cref="XmlDocument"/> instance.</param>
    /// <param name="csvRows">The number of csv rows in the CSV file.</param>
    public XmlParameterHandler(XmlDocument doc, int csvRows) : base(csvRows){
        Param = new ParameterParser(doc.OuterXml).Match() as List<Parameter>;
    }
}