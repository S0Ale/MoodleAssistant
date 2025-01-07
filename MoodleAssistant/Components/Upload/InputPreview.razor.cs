using Microsoft.AspNetCore.Components;

namespace MoodleAssistant.Components.Upload;

/// <summary>
/// Code-behind for the <see cref="InputPreview"/> component.
/// Represents a preview of the uploaded file.
/// </summary>
public partial class InputPreview{
    /// <summary>
    /// The name of the file.
    /// </summary>
    [Parameter]
    public required string FileName { get; set; }
    
    /// <summary>
    /// Event callback for closing the preview.
    /// </summary>
    [Parameter]
    public EventCallback<string> OnClose { get; set; }
    
    /// <summary>
    /// Closes the preview.
    /// </summary>
    private async Task Close()
    {
        await OnClose.InvokeAsync(FileName);
    }
}