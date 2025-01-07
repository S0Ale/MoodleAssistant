using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace MoodleAssistant.Components.Upload;

/// <summary>
/// The custom label component for a <see cref="DropInput"/> component.
/// </summary>
public partial class CustomLabel{
    /// <summary>
    /// The <see cref="RenderFragment"/> representing the child content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
    
    /// <summary>
    /// The additional attributes of the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }
    
    /// <summary>
    /// The name of the input element.
    /// </summary>
    [Parameter]
    public string InputName { get; set; } = string.Empty;
    
    /// <summary>
    /// The maximum number of files that can be uploaded.
    /// </summary>
    [Required] [Parameter]
    public int MaxFiles { get; init; }
    
    /// <summary>
    /// The uploaded files.
    /// </summary>
    [Parameter]
    public required Dictionary<int, IBrowserFile> UploadedFiles { get; set; }
    
    /// <summary>
    /// The visibility of the component.
    /// </summary>
    [Parameter]
    public bool IsVisible { get; set; }
    
    /// <summary>
    /// The event callback when the input element changes.
    /// </summary>
    [Parameter]
    public EventCallback<InputFileChangeEventArgs> OnChange { get; set; }
}