using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace MoodleAssistant.Components;

/// <summary>
/// Represents a message component.
/// </summary>
public partial class Message{
    /// <summary>
    /// Indicates whether the message is visible.
    /// </summary>
    private bool _visible = false;

    /// <summary>
    /// The message's text.
    /// </summary>
    [Parameter]
    public string? MsgText { get; set; }
    
    /// <summary>
    /// The message's type.
    /// </summary>
    [Required][Parameter]
    public MessageType Type { get; set; }
    
    /// <summary>
    /// Indicates whether the message can be closed.
    /// </summary>
    [Required][Parameter]
    public bool CanClose { get; set; }
    
    /// <summary>
    /// The component OnInitialized lifecycle method.
    /// </summary>
    protected override void OnInitialized(){
        _visible = Type != MessageType.Error;
    }
    
    /// <summary>
    /// Shows the message.
    /// </summary>
    public void Show(){
        _visible = true;
    }
    
    /// <summary>
    /// Closes the message.
    /// </summary>
    private void Close(){
        _visible = false;
    }

    /// <summary>
    /// Refreshes the component.
    /// </summary>
    public void Refresh(){
        StateHasChanged();
    }
}