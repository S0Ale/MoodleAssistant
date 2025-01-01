using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Forms;

namespace MoodleAssistant.Services;

/// <summary>
/// Represents a service that manages the file operations during a user session.
/// </summary>
/// <param name="env">The <see cref="IWebHostEnvironment"/> instance that provides information about the web hosting environment.</param>
//public class FileService(IWebHostEnvironment env) : IBrowserFileService, IDisposable{
public class FileService() : IBrowserFileService, IDisposable{
    private const long MaxFileSize = 10000000;
    //private readonly string _rootFolder = Path.Combine(env.WebRootPath, "Uploads");
    private readonly string _rootFolder = Path.Combine("", "Uploads");
    
    // Maps fixed file names to their trusted file names
    //private Dictionary<string, string> _trustedFiles = new Dictionary<string, string>();
    private Dictionary<string, IBrowserFile> _trustedFiles = new Dictionary<string, IBrowserFile>();

    /// <summary>
    /// Saves the specified file inside the root folder.
    /// </summary>
    /// <param name="file">Instance of <see cref="IBrowserFile"/> to save.</param>
    /// <param name="fileName">The file name.</param>
    /// <returns>The save operation result.</returns>
    public Task<bool> SaveFile(IBrowserFile file, string fileName){
        // if name exists, overwrite
        if(_trustedFiles.ContainsKey(fileName)){
            DeleteFile(fileName);
        }
        //var trustedFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
        //_trustedFiles.Add(fileName, trustedFileName);
        _trustedFiles.Add(fileName, file);
        
        /*
        if(!Directory.Exists(_rootFolder)){
            Directory.CreateDirectory(_rootFolder);
        }
        
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        await using var fileStream = new FileStream(trustedFilePath, FileMode.Create);
        await file.OpenReadStream(MaxFileSize).CopyToAsync(fileStream);
        */
        return Task.FromResult(true);
    }

    /// <summary>
    /// Gets the <see cref="FileStream"/> of the specified file.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The <see cref="FileStream"/> that encapsulates the file with the specified name.</returns>
    public async Task<Stream> GetFile(string fileName){
        //var trustedFileName = _trustedFiles[fileName];
        //var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        //return new FileStream(trustedFilePath, FileMode.Open, FileAccess.Read);
        var stream = new MemoryStream();
        await _trustedFiles[fileName].OpenReadStream(MaxFileSize).CopyToAsync(stream);
        stream.Position = 0;
        return stream;
    }

    /// <summary>
    /// Gets the <see cref="FileInfo"/> of the specified file.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The <see cref="FileInfo"/> if the file with the specified name.</returns>
    public FileInfo GetFileInfo(string fileName){
        //var trustedFileName = _trustedFiles[fileName];
        //var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        //return new FileInfo(trustedFilePath);
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Deletes the file with the specified name.
    /// </summary>
    /// <param name="fileName">The name of the file to delete.</param>
    public void DeleteFile(string fileName){
        _trustedFiles.Remove(fileName);
    }
    
    /// <summary>
    /// Deletes all files inside the root folder.
    /// </summary>
    public void DeleteAllFiles(){
        _trustedFiles = new Dictionary<string, IBrowserFile>();
    }
    
    /// <summary>
    /// Gets the base64 string of the file with the specified name.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The base64 string of the file.</returns>
    public async Task<string> GetBase64(string fileName){
        //var trustedFileName = _trustedFiles[fileName];
        //var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        
        //using var fileStream = new FileStream(trustedFilePath, FileMode.Open, FileAccess.Read);
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