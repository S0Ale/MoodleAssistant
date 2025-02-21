using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Manages the validation process for a specified file.
/// </summary>
public interface IValidationModel{

    /// <summary>
    /// Validates the file contained in the model.
    /// </summary>
    /// <exception cref="ReplicatorException">Thrown when a validation error occurs.</exception>
    public Task Validate();
}