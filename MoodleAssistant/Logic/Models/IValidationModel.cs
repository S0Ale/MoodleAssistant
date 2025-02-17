using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Represents a validation model.
/// </summary>
public interface IValidationModel{
    /// <summary>
    /// Validates the file contained in the model.
    /// </summary>
    /// <exception cref="ReplicatorException">Thrown when a validation error occurs.</exception>
    public void Validate();
    
    /// <summary>
    /// Checks if the file is empty.
    /// </summary>
    /// <param name="file">The instance of <see cref="IBrowserFile"/></param>
    /// <returns><c>true</c> if the file is empty; otherwise <c>false</c></returns>
    bool IsEmpty(IBrowserFile file){
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