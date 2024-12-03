using System.Net.Mime;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Services;

namespace MoodleAssistant.Classes.Models;

public class FileModel(IBrowserFileService fileService, string name){
    private readonly string _fileName = name;
    private static readonly string[] MimeTypes = [
        MediaTypeNames.Image.Png,
        MediaTypeNames.Image.Jpeg,
        MediaTypeNames.Image.Webp,
        MediaTypeNames.Image.Bmp,
    ];
    
    public bool IsImage(IBrowserFile file){
        return MimeTypes.Contains(file.ContentType);
    }
    public bool IsEmpty(){
        return fileService.IsEmpty(_fileName);
    }
}