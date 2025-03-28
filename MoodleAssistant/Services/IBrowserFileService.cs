﻿using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Services;

/// <summary>
/// Represents a service that manages the file operations during a user session.
/// </summary>
public interface IBrowserFileService{
    /// <summary>
    /// Saves the specified file.
    /// </summary>
    /// <param name="file">The instance of <see cref="IBrowserFile"/> to save.</param>
    /// <param name="fileName">The file's name.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise <c>false</c>.</returns>
    public Task<bool> SaveFile(IBrowserFile file, string fileName);

    /// <summary>
    /// Saves the specified document to file.
    /// </summary>
    /// <param name="doc">The document to save.</param>
    /// <param name="format">The document's format.</param>
    /// <returns>The file's name if the operation is successful; otherwise <c>null</c>.</returns>
    public Task<string> StoreDownloadFile(object doc, Format format);

    /// <summary>
    /// Gets the <see cref="FileStream"/> of the specified file.
    /// </summary>
    /// <param name="fileName">The file's name.</param>
    /// <returns>The <see cref="FileStream"/> that encapsulates the file with the specified name.</returns>
    public FileStream GetFile(string fileName);

    /// <summary>
    /// Deletes the file with the specified name.
    /// </summary>
    /// <param name="fileName">The name of the file to delete.</param>
    public void DeleteFile(string fileName);

    /// <summary>
    /// Deletes all files.
    /// </summary>
    public void DeleteAllFiles();
    
    /// <summary>
    /// Gets the base64 string of the specified file.
    /// </summary>
    /// <param name="filename">The file's name.</param>
    /// <returns>The base64 string of the file.</returns>
    string GetBase64(string filename);
}