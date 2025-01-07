﻿using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Forms;

namespace MoodleAssistant.Services;

/// <summary>
/// Represents a service that manages the file operations during a user session.
/// </summary>
public class FileService : IBrowserFileService, IDisposable{
    /// <summary>
    /// The maximum file size in bytes.
    /// </summary>
    private const long MaxFileSize = 10000000;
    
    /// <summary>
    /// Map of fixed file names with their trusted file names.
    /// </summary>
    private Dictionary<string, IBrowserFile> _trustedFiles = new Dictionary<string, IBrowserFile>();

    /// <inheritdoc/>
    public Task<bool> SaveFile(IBrowserFile file, string fileName){
        // if name exists, overwrite
        if(_trustedFiles.ContainsKey(fileName)){
            DeleteFile(fileName);
        }
        _trustedFiles.Add(fileName, file);
        return Task.FromResult(true);
    }

    /// <inheritdoc/>
    public async Task<Stream> GetFile(string fileName){
        var stream = new MemoryStream();
        await _trustedFiles[fileName].OpenReadStream(MaxFileSize).CopyToAsync(stream);
        stream.Position = 0;
        return stream;
    }

    /// <inheritdoc/>
    public FileInfo GetFileInfo(string fileName){
        throw new NotImplementedException();
    }
    
    /// <inheritdoc/>
    public void DeleteFile(string fileName){
        _trustedFiles.Remove(fileName);
    }
    
    /// <inheritdoc/>
    public void DeleteAllFiles(){
        _trustedFiles = new Dictionary<string, IBrowserFile>();
    }
    
    /// <inheritdoc/>
    public async Task<string> GetBase64(string fileName){
        var stream = await GetFile(fileName);
        stream.Position = 0;
        await using var base64Stream = new CryptoStream(stream, new ToBase64Transform(), CryptoStreamMode.Read); // throws an error
        using var reader = new StreamReader(base64Stream);
        return await reader.ReadToEndAsync();
    }

    /// <summary>
    /// Disposes the service and deletes all files.
    /// </summary>
    public void Dispose(){
        DeleteAllFiles();
    }
}