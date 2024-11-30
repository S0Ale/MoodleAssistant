using System.IO.Pipelines;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;

namespace MoodleAssistant.Services;

public class FileService(IWebHostEnvironment env) : IDisposable{
    private const long MaxFileSize = 10000000;
    private readonly string _rootFolder = Path.Combine(env.WebRootPath, "Uploads");
    
    //Maps fixed file names to their trusted file names
    private Dictionary<string, string> _trustedFiles = new Dictionary<string, string>();
    
    public async Task<bool> SaveFile(IBrowserFile file, string fileName){
        // if name exists, overwrite
        if(_trustedFiles.ContainsKey(fileName)){
            DeleteFile(fileName);
        }
        var trustedFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
        _trustedFiles.Add(fileName, trustedFileName);
        
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        await using var fileStream = new FileStream(trustedFilePath, FileMode.Create);
        await file.OpenReadStream(MaxFileSize).CopyToAsync(fileStream);
        return true;
    }
    
    public FileStream GetFile(string fileName){
        var trustedFileName = _trustedFiles[fileName];
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        return new FileStream(trustedFilePath, FileMode.Open, FileAccess.Read);
    }
    
    public FileInfo GetFileInfo(string fileName){
        var trustedFileName = _trustedFiles[fileName];
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        return new FileInfo(trustedFilePath);
    }
    
    public void DeleteFile(string fileName){
        var trustedFileName = _trustedFiles[fileName];
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        File.Delete(trustedFilePath);
        _trustedFiles.Remove(fileName);
    }
    
    public void DeleteAllFiles(){
        foreach(var trustedName in _trustedFiles.Values){
            var trustedFilePath = Path.Combine(_rootFolder, trustedName);
            File.Delete(trustedFilePath);
        }
        _trustedFiles = new Dictionary<string, string>();
    }
    
    public string GetBase64(string fileName){
        var trustedFileName = _trustedFiles[fileName];
        var trustedFilePath = Path.Combine(_rootFolder, trustedFileName);
        
        using var fileStream = new FileStream(trustedFilePath, FileMode.Open, FileAccess.Read);
        using var base64Stream = new CryptoStream(fileStream, new ToBase64Transform(), CryptoStreamMode.Read);
        using var reader = new StreamReader(base64Stream);
        return reader.ReadToEnd();
    }

    public void Dispose(){
        DeleteAllFiles();
    }
}