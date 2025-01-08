using Microsoft.AspNetCore.Components;
using MoodleAssistant.Components.Upload;
using MoodleAssistant.Logic;
using MoodleAssistant.Logic.Models;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Components.Sections;

/// <summary>
/// Represents a section of the page that handles file uploads for file-type paarameters.
/// </summary>
public partial class FileParam{
    /// <summary>
    /// The event callback invoked when the submit process is successful.
    /// </summary>
    [Parameter]
    public EventCallback<bool> OnSuccess { get; set; }
    
    /// <summary>
    /// The error of the section.
    /// </summary>
    public Error ErrorMsg{ get; private set; } = Error.NoErrors; // public for testing purposes
    
    /// <summary>
    /// The error dialog of the section.
    /// </summary>
    private Message _dialog = null!;
    
    /// <summary>
    /// The file inputs of this section.
    /// </summary>
    private Dictionary<string, DropInput> _inputs = [];
    
    private bool _isUploading;
    private bool _successfulUpload;
    
    public bool IsUploading => _isUploading; // testing
    public bool SuccessUpload => _successfulUpload; // testing

    /// <summary>
    /// Submits the uploaded files
    /// </summary>
    private async Task Submit(){
        _successfulUpload = false;
        await OnSuccess.InvokeAsync(false);
        
        Thread.Sleep(250);
        var state = ReplicatorState;
        if (state == null){
            SetError(Error.Unexpected);
            return;
        }

        // Check if all needed files are uploaded
        var totalFiles = _inputs.Values.Sum(input => input.UploadedFiles.Count);
        if (totalFiles != state.Parameters?.GetFileParameters().Count * state.Parameters?.NeededFiles){
            SetError(Error.NoFiles);
            return;
        }
        
        // Load file parameters
        var loader = new Loader(FileService);
        try{
            foreach (var param in state.Parameters?.GetFileParameters() ?? [])
                await loader.LoadFiles(_inputs[param.Name].UploadedFiles.Values.ToArray());
        }catch (ReplicatorException e){
            SetError(e.Error);
            return;
        }catch (Exception e){
            Logger.LogError(e, e.Message);
            SetError(Error.Unexpected);
            return;
        }
        var merger = new Merger(FileService, state.Template, state.CsvAsList);

        // Merge question
        try{
            state.Preview = new PreviewModel(await merger.MergeQuestion(true), state.AnswerCount);
            state.Merged = await merger.MergeQuestion();
        }
        catch (ReplicatorException e){
            SetError(e.Error);
            return;
        }
        catch (KeyNotFoundException){
            SetError(Error.FileMismatch);
            return;
        }catch (Exception e){
            Logger.LogError(e, e.Message);
            SetError(Error.Unexpected);
            return;
        }
        FileService.DeleteAllFiles();
        ClearForm();

        _isUploading = false;
        _successfulUpload = true;
        await OnSuccess.InvokeAsync(true);
    }

    /// <summary>
    /// Clears the form.
    /// </summary>
    private void ClearForm(){
        foreach (var input in _inputs.Values){
            input.ClearFiles();
        }
    }

    /// <summary>
    /// Sets the error message of the section.
    /// </summary>
    /// <param name="err">The <see cref="Error"/> that occurred.</param>
    private void SetError(Error err){
        _isUploading = false;
        FileService.DeleteAllFiles();
        ErrorMsg = err;
        _dialog.Show();
        _dialog.Refresh();
    }
}