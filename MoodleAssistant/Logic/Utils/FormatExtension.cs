﻿namespace MoodleAssistant.Logic.Utils;

/// <summary>
/// Contains extension methods for file formats.
/// </summary>
public abstract class FormatExtension{
    /// <summary>
    /// The extension for XML files.
    /// </summary>
    private const string Xml = ".xml";
    
    /// <summary>
    /// The extension for Aiken files.
    /// </summary>
    private const string Aiken = ".txt";
    
    /// <summary>
    /// Returns the extension of the specified format.
    /// </summary>
    /// <param name="format">The specified <see cref="Format"/>.</param>
    /// <returns>The extension of the specified <see cref="Format"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified format is not present.</exception>
    public static string GetExtension(Format format){
        return format switch{
            Format.Xml => Xml,
            Format.Aiken => Aiken,
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
        };
    }
}