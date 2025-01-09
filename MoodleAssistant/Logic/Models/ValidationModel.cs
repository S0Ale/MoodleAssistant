using Microsoft.AspNetCore.Components.Forms;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// 
/// </summary>
/// <param name="file">The instance of <see cref="IBrowserFile"/> representing the file to validate.</param>
public class ValidationModel(IBrowserFile file){
    /// <summary>
    /// Checks if the file is empty.
    /// </summary>
    /// <returns><c>true</c> if the file is empty; otherwise <c>false</c></returns>
    public bool IsEmpty(){
        switch (file.Size){
            case 0:
                return true;
            case >= 6:
                return false;
        }

        var stream = file.OpenReadStream();
        using var reader = new StreamReader(stream);
        stream.Position = 0;
        return reader.ReadToEnd().Length == 0;
    }
}