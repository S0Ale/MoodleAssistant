using System.Diagnostics.CodeAnalysis;
using System.Xml;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Logic;

/// <summary>
/// Represents a merged document.
/// </summary>
public class MergedDocument(object doc, Format format){

    /// <summary>
    /// Saves the document to the specified file.
    /// </summary>
    /// <param name="filename">The location of the file where you want to save the document.</param>
    /// <exception cref="ArgumentOutOfRangeException"> Thrown when the format is not supported. </exception>
    public void Save(string filename){
        switch (format){
            case Format.Xml:
                ((XmlDocument)doc).Save(filename);
                break;
            case Format.Aiken:
                break;
            case Format.Gift:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(format), format, null);
        }
    }
}