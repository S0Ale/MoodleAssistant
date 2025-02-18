using System.Xml;
using Microsoft.JSInterop;
using MoodleAssistant.Components.Upload;
using MoodleAssistant.Logic;
using MoodleAssistant.Logic.Models;
using MoodleAssistant.Logic.Utils;

namespace MoodleAssistant.Components.Pages;

/// <summary>
/// Code-behind for the Replicator page.
/// </summary>
public partial class Replicator{
    /// <summary>
    /// The error message of the page.
    /// </summary>
    public Error ErrorMsg{ get; private set; } = Error.NoErrors; // public for testing purposes
    
    /// <summary>
    /// The message dialog on the page.
    /// </summary>
    private Message _dialog = null!;
    
    /// <summary>
    /// The <see cref="DropInput"/> component for the XML file upload.
    /// </summary>
    private DropInput _templateInput = null!;
    
    /// <summary>
    /// The <see cref="DropInput"/> component for the CSV file upload.
    /// </summary>
    private DropInput _csvInput = null!;
    
    private bool _isUploading;
    private bool _successfulUpload;
    private bool _showFileParams;
    private bool _showDownload;
    
    public bool SuccessUpload => _successfulUpload; // testing
    public bool IsUploading => _isUploading; // testing
    public bool ShowFileParams => _showFileParams; // testing
    
    /// <summary>
    /// Submits the uploaded files.
    /// </summary>
    private async Task Submit(){
        ResetSections();
        Thread.Sleep(250);
        var state = ReplicatorState;
        
        // Check if both files are uploaded
        var totalFiles = _templateInput.UploadedFiles.Count + _csvInput.UploadedFiles.Count;
        if(totalFiles < 2){
            SetError(Error.NoFiles);
            return;
        }
        
        // Change factory type according to the question type
        state.Factory = new XmlFactory(FileService);
        
        var loader = new Loader(FileService, state.Factory);
        
        // Load XML file
        ITemplateModel templateModel;
        try{ templateModel = await loader.LoadTemplate(_templateInput.UploadedFiles.Values.FirstOrDefault()!); }
        catch (ReplicatorException e){
            SetError(e.Error);
            return;
        }
        state.Template = (XmlDocument)templateModel.TemplateDocument;
        
        // Load CSV file
        List<string[]> csvList;
        try{
            csvList = await loader.LoadCsv(_csvInput.UploadedFiles.Values.FirstOrDefault()!, templateModel) as List<string[]> ?? []; 
        }catch (ReplicatorException e){
            SetError(e.Error);
            return;
        }catch (Exception e){
            Logger.LogError(e, e.Message);
            SetError(Error.Unexpected);
            return;
        }
        state.CsvAsList = csvList;
        FileService.DeleteAllFiles();
        
        // Load parameters
        state.Parameters = state.Factory.CreateParameterModel(state.Template, csvList.Count - 1);
        if (state.Parameters.GetFileParameters().Count > 0){
            _showFileParams = true;
        }else{
            //var merger = new XmlMerger(FileService, state.Template, state.CsvAsList);
            var merger = state.Factory.CreateMerger(state.Template, state.CsvAsList);

            try{
                state.Preview = new PreviewModel((XmlDocument)merger.MergeQuestion(true));
                state.Merged = (XmlDocument)merger.MergeQuestion();
            }
            catch (ReplicatorException e){
                SetError(e.Error);
                return;
            }catch(KeyNotFoundException){
                SetError(Error.FileMismatch);
                return;
            }catch (Exception e){
                Logger.LogError(e, e.Message);
                SetError(Error.Unexpected);
                return;
            }

            _showDownload = true;
        }

        FileService.DeleteAllFiles();
        ClearForm();
        _successfulUpload = true;
        _isUploading = false;
    }

    /// <summary>
    /// Clears the form.
    /// </summary>
    private void ClearForm(){
        _templateInput.ClearFiles();
        _csvInput.ClearFiles();
    }

    /// <summary>
    /// Resets the sections of the page.
    /// </summary>
    private void ResetSections(){
        _successfulUpload = false;
        _showFileParams = false;
        _showDownload = false;
    }

    /// <summary>
    /// Resets the page.
    /// </summary>
    private void Reset(){
        FileService.DeleteAllFiles();
        ClearForm();
        ReplicatorState.Reset();
        ResetSections();
    }

    /// <summary>
    /// Sets the error message of the page.
    /// </summary>
    /// <param name="err">The <see cref="Error"/> that occurred.</param>
    private void SetError(Error err){
        _isUploading = false;
        FileService.DeleteAllFiles();
        ErrorMsg = err;
        _dialog.Show();
        _dialog.Refresh();
    }
    
    /// <summary>
    /// Downloads the merged file.
    /// </summary>
    private async Task Download(){
        await FileService.SaveFile(ReplicatorState.Merged!);
        await Js.InvokeVoidAsync("triggerFileDownload", "MERGED.xml", "/Uploads/MERGED.xml");
    }
}