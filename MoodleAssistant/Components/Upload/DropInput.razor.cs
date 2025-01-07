using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace MoodleAssistant.Components.Upload;

/// <summary>
/// The component for uploading one or multiple files.
/// </summary>
public partial class DropInput{
    /// <summary>
    /// The <see cref="RenderFragment"/> representing the child content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
    
    /// <summary>
    /// The name of the input element.
    /// </summary>
    [Parameter] public string InputName{ get; set; } = string.Empty;
    
    /// <summary>
    /// The maximum number of files that can be uploaded.
    /// </summary>
    [Parameter] public int MaxFiles{ get; init; } = 1;

    /// <summary>
    /// The current index of the uploaded files.
    /// </summary>
    private int _current = 1;

    /// <summary>
    /// A JavaScript module reference.
    /// </summary>
    private IJSObjectReference? _module;
    
    /// <summary>
    /// The uploaded files.
    /// </summary>
    public Dictionary<int, IBrowserFile> UploadedFiles{ get; private set; } = [];

    /// <summary>
    /// Uploads the files.
    /// </summary>
    /// <param name="e">The <see cref="InputFileChangeEventArgs"/> instance containing the uploaded files.</param>
    private void UploadFile(InputFileChangeEventArgs e){
        if (e.FileCount != 0 && UploadedFiles.Count < MaxFiles && _current <= MaxFiles){
            foreach (var file in e.GetMultipleFiles()){
                UploadedFiles.Add(_current, file);
                // set current to the next available index
                _current = FindNext();
            }

            StateHasChanged();
        }
    }

    /// <summary>
    /// Finds the next available index for the uploaded files.
    /// </summary>
    /// <returns>The next available index.</returns>
    private int FindNext(){
        var i = 1;
        for (;i <= MaxFiles && UploadedFiles.ContainsKey(i); i++);
        return i;
    }

    /// <summary>
    /// Removes a file from the uploaded files.
    /// </summary>
    /// <param name="index">The index of the file to be removed.</param>
    public void RemoveFile(int index){
        UploadedFiles.Remove(index);
        _current = index;
    }

    /// <summary>
    /// Clears the uploaded files.
    /// </summary>
    public void ClearFiles(){
        UploadedFiles.Clear();
        _current = 1;
    }
    
    /// <summary>
    /// Function invoked when the component has been rendered.
    /// </summary>
    /// <param name="firstRender">
    /// <c>true</c> if this is the first time <see cref="ComponentBase.OnAfterRender(bool)"/> has been called; otherwise, <c>false</c>.
    /// </param>
    protected override async Task OnAfterRenderAsync(bool firstRender){
        if (firstRender){
            _module = await Js.InvokeAsync<IJSObjectReference>("import",
                "./Components/Upload/DropInput.razor.js");

            await _module.InvokeVoidAsync("initComponent", $"#{InputName}");
        }
    }
    
    /// <summary>
    /// Disposes the component asynchronously.
    /// </summary>
    async ValueTask IAsyncDisposable.DisposeAsync(){
        if (_module is not null){
            try{
                await _module.DisposeAsync();
            }
            catch (JSDisconnectedException){
            }
        }
    }
}