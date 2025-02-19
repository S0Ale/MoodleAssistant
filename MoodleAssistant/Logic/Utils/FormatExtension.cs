namespace MoodleAssistant.Logic.Utils;

/// <summary>
/// Contains extension methods for file formats.
/// </summary>
public class FormatExtension{
    /// <summary>
    /// The extension for XML files.
    /// </summary>
    private const string Xml = ".xml";
    
    /// <summary>
    /// Returns the extension of the specified format.
    /// </summary>
    /// <param name="format">The specified <see cref="Format"/>.</param>
    /// <returns>The extension of the specified <see cref="Format"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified format is not present.</exception>
    public static string GetExtension(Format format){
        return format switch{
            Format.Xml => Xml,
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
        };
    }
}