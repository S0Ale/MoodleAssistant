using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Forms;

namespace MoodleAssistant.Services;

/// <summary>
/// Represents a service that manages the file operations during a user session.
/// </summary>
/// <param name="env">The <see cref="IWebHostEnvironment"/> instance that provides information about the web hosting environment.</param>
public class FileService(IWebHostEnvironment env) : IBrowserFileService, IDisposable{
    /// <summary>
    /// The maximum file size in bytes.
    /// </summary>
    private const long MaxFileSize = 10000000;
    
    /// <summary>
    /// The root folder where the files are saved.
    /// </summary>
    private readonly string _rootFolder = Path.Combine(env.WebRootPath, "Uploads");
    
    /// <summary>
    /// Map of fixed file names with their trusted file names.
    /// </summary>
    private Dictionary<string, string> _trustedFiles = new Dictionary<string, string>();

    /// <inheritdoc/>
    public async Task<bool> SaveFile(IBrowserFile file, string fileName){
        // if name exists, overwrite
        if(_trustedFiles.ContainsKey(fileName)){
            DeleteFile(fileName);
        }
        var trustedFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
        _trustedFiles.Add(fileName, trustedFileName);

        if(!Directory.Exists(_rootFolder)){
            Directory.CreateDirectory(_rootFolder);
        }
        
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        await using var fileStream = new FileStream(trustedFilePath, FileMode.Create);
        await file.OpenReadStream(MaxFileSize).CopyToAsync(fileStream);
        return true;
    }

    /// <inheritdoc/>
    public FileStream GetFile(string fileName){
        var trustedFileName = _trustedFiles[fileName];
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        return new FileStream(trustedFilePath, FileMode.Open, FileAccess.Read);
    }

    /// <inheritdoc/>
    public FileInfo GetFileInfo(string fileName){
        var trustedFileName = _trustedFiles[fileName];
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        return new FileInfo(trustedFilePath);
    }
    
    /// <inheritdoc/>
    public void DeleteFile(string fileName){
        var trustedFileName = _trustedFiles[fileName];
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        File.Delete(trustedFilePath);
        _trustedFiles.Remove(fileName);
    }
    
    /// <inheritdoc/>
    public void DeleteAllFiles(){
        foreach(var trustedName in _trustedFiles.Values){
            var trustedFilePath = Path.Combine(_rootFolder, trustedName);
            File.Delete(trustedFilePath);
        }
        _trustedFiles = new Dictionary<string, string>();
    }
    
    /// <inheritdoc/>
    public string GetBase64(string fileName){
        var trustedFileName = _trustedFiles[fileName];
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        
        using var fileStream = new FileStream(trustedFilePath, FileMode.Open, FileAccess.Read);
        using var base64Stream = new CryptoStream(fileStream, new ToBase64Transform(), CryptoStreamMode.Read);
        using var reader = new StreamReader(base64Stream);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Disposes the service and deletes all files.
    /// </summary>
    public void Dispose(){
        DeleteAllFiles();
    }
}