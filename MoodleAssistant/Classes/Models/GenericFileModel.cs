using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Services;

namespace MoodleAssistant.Classes.Models;

public class GenericFileModel(FileService fileService){ // represent a list of files for a given file parameter
    public IBrowserFile[] Files{ get; set; }
    
    public async Task<bool> SaveFiles(){
        foreach (var file in Files){
            var res = await fileService.SaveFile(file, file.Name);
            if (!res) return false;
        }
        return true;
    }
}