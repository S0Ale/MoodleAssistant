using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Models;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic;

/// <summary>
/// Loads the files uploaded by the user.
/// </summary>
/// <param name="fileService">An instance of <see cref="IBrowserFileService"/> to manage saved files.</param>
public class Loader(IBrowserFileService fileService){
    /// <summary>
    /// Loads the template question file and validates it.
    /// </summary>
    /// <param name="file">An instance of <see cref="IBrowserFile"/>representing the template question.</param>
    /// <returns>An instance of <see cref="ITemplateModel"/> to manage the file.</returns>
    /// <exception cref="ReplicatorException">Thrown when a validation error occurs.</exception>
    public async Task<ITemplateModel> LoadTemplate(IBrowserFile file){
        if(file.Size > 10000000)
            throw new ReplicatorException(Error.FileTooBig);
        
        // change model according to the question type
        var model = new XmlModel(file, fileService);
        await fileService.SaveFile(file, XmlModel.FileName);
        model.Validate();

        model.TakeParameters();
        return model;
    }

    /// <summary>
    /// Loads the CSV file and validates it.
    /// </summary>
    /// <param name="file">An instance of <see cref="IBrowserFile"/> representing the CSV file.</param>
    /// <param name="templateModel">An instance of <see cref="ITemplateModel"/> representing the template file.</param>
    /// <returns>A list of string arrays representing the CSV file.</returns>
    /// <exception cref="ReplicatorException">Thrown when a validation error occurs.</exception>
    public async Task<IEnumerable<string[]>> LoadCsv(IBrowserFile file, ITemplateModel templateModel){
        if(file.Size > 10000000)
            throw new ReplicatorException(Error.FileTooBig);
        
        var model = new CsvModel(file, fileService){
            QuestionParametersList = templateModel.QuestionParametersList,
            AnswersParametersList = templateModel.AnswerParametersList
        };
        _ = await fileService.SaveFile(file, CsvModel.FileName);
        model.Validate();

        return model.ConvertCsvToListOfArrayString();
    }
    
    /// <summary>
    /// Loads the files uploaded and validates them.
    /// </summary>
    /// <param name="files">Sequence of <see cref="IBrowserFile"/> instances representing the uploaded files.</param>
    /// <exception cref="ReplicatorException">Thrown when a validation error occurs.</exception>
    public async Task LoadFiles(IBrowserFile[] files){
        foreach (var file in files){
            var model = new FileModel(file);
            _ = await fileService.SaveFile(file, file.Name); 
            model.Validate();
        }
    }
}