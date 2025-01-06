using System.Net.Mime;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Manage the validation of a uploaded file.
/// </summary>
/// <param name="fileService">An instance of <see cref="IBrowserFileService"/> to manage saved files.</param>
/// <param name="name">The file's name.</param>
public class FileModel(IBrowserFileService fileService, string name){
    /// <summary>
    /// A list of supported image MIME types.
    /// </summary>
    private static readonly string[] ImageMimeTypes = [
        MediaTypeNames.Image.Png,
        MediaTypeNames.Image.Jpeg,
        MediaTypeNames.Image.Webp,
        MediaTypeNames.Image.Bmp,
    ];
    
    /// <summary>
    /// A list of supported Microsoft Office MIME types.
    /// </summary>
    private static readonly string[] MsMimeTypes = [
        // Word
        "application/msword",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.template",
        "application/vnd.ms-word.document.macroEnabled.12",
        
        // Excel
        "application/vnd.ms-excel",
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        "application/vnd.openxmlformats-officedocument.spreadsheetml.template",
        "application/vnd.ms-excel.sheet.macroEnabled.12",
        "application/vnd.ms-excel.template.macroEnabled.12",
        "application/vnd.ms-excel.addin.macroEnabled.12",
        "application/vnd.ms-excel.sheet.binary.macroEnabled.12",
        
        // PowerPoint
        "application/vnd.ms-powerpoint",
        "application/vnd.openxmlformats-officedocument.presentationml.presentation",
        "application/vnd.openxmlformats-officedocument.presentationml.template",
        "application/vnd.openxmlformats-officedocument.presentationml.slideshow",
        "application/vnd.ms-powerpoint.addin.macroEnabled.12",
        "application/vnd.ms-powerpoint.presentation.macroEnabled.12",
        "application/vnd.ms-powerpoint.template.macroEnabled.12",
        "application/vnd.ms-powerpoint.slideshow.macroEnabled.12",
    ];
    
    /// <summary>
    /// Checks if the <see cref="IBrowserFile.ContentType"/> of a file is an image.
    /// </summary>
    /// <param name="file">An instance of <see cref="IBrowserFile"/> representing the file.</param>
    /// <returns><see langword="true"/> if the file is an image; otherwise <see langword="false"/>.</returns>
    public bool IsImage(IBrowserFile file){
        return ImageMimeTypes.Contains(file.ContentType);
    }
    
    /// <summary>
    /// Checks if the <see cref="IBrowserFile.ContentType"/> of a file is a Microsoft Office file.
    /// </summary>
    /// <param name="file">An instance of <see cref="IBrowserFile"/> representing the file.</param>
    /// <returns><see langword="true"/> if the file is a MS Office file; otherwise <see langword="false"/>.</returns>
    public bool IsOfficeFile(IBrowserFile file){
        return MsMimeTypes.Contains(file.ContentType);
    }
    
    /// <summary>
    /// Checks if the file is empty.
    /// </summary>
    /// <returns><see langword="true"/> if the file is empty; otherwise <see langword="false"/>.</returns>
    public bool IsEmpty(){
        return fileService.IsEmpty(name);
    }
}