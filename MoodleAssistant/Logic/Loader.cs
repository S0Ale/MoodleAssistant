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
    /// Loads the XML file and validates it.
    /// </summary>
    /// <param name="file">An instance of <see cref="IBrowserFile"/>representing the XML file.</param>
    /// <returns>An instance of <see cref="XmlModel"/> to manage the file.</returns>
    /// <exception cref="ReplicatorException">Thrown when a validation error occurs.</exception>
    public async Task<XmlModel> LoadXml(IBrowserFile file){
        var model = new XmlModel(file, fileService);
        await fileService.SaveFile(file, XmlModel.FileName);

        if (null == file)
            throw new ReplicatorException(Error.NullFile);
        if (!XmlModel.IsXml(file))
            throw new ReplicatorException(Error.NonXmlFile);
        if (IsEmpty(file))
            throw new ReplicatorException(Error.EmptyFile);
        if (!await model.IsWellFormattedXml())
            throw new ReplicatorException(Error.XmlBadFormed);
        if (!model.HasOnlyOneQuestion())
            throw new ReplicatorException(Error.ZeroOrMoreQuestions);
        if (!model.HasQuestionText())
            throw new ReplicatorException(Error.ZeroOrMoreQuestions);

        model.TakeParameters();
        return model;
    }

    /// <summary>
    /// Loads the CSV file and validates it.
    /// </summary>
    /// <param name="file">An instance of <see cref="IBrowserFile"/> representing the CSV file.</param>
    /// <param name="xmlModel">An instance of <see cref="XmlModel"/> representing the template XML file.</param>
    /// <returns>A list of string arrays representing the CSV file.</returns>
    /// <exception cref="ReplicatorException">Thrown when a validation error occurs.</exception>
    public async Task<IEnumerable<string[]>> LoadCsv(IBrowserFile file, XmlModel xmlModel){
        var model = new CsvModel(file, fileService){
            QuestionParametersList = xmlModel.QuestionParametersList,
            AnswersParametersList = xmlModel.AnswerParametersList
        };
        _ = await fileService.SaveFile(file, CsvModel.FileName);

        if (null == file)
            throw new ReplicatorException(Error.NullFile);
        if (!CsvModel.IsCsv(file))
            throw new ReplicatorException(Error.NonCsvFile);
        if (IsEmpty(file))
            throw new ReplicatorException(Error.EmptyFile);
        if (!await model.HasValidHeader())
            throw new ReplicatorException(Error.CsvInvalidHeader);
        if (!await model.IsWellFormed())
            throw new ReplicatorException(Error.CsvBadFormed);

        return await model.ConvertCsvToListOfArrayString();
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
            
            if (null == file)
                throw new ReplicatorException(Error.NullFile);
            if (IsEmpty(file))  
                throw new ReplicatorException(Error.EmptyFile);
            if (!model.IsImage(file) && !model.IsOfficeFile(file))
                throw new ReplicatorException(Error.NoValidFile);
        }
    }
    
    /// <summary>
    /// Checks if the file is empty.
    /// </summary>
    /// <param name="file">The instance of <see cref="IBrowserFile"/> representing the file to check.</param>
    /// <returns><c>true</c> if the file is empty; otherwise <c>false</c></returns>
    private static bool IsEmpty(IBrowserFile file){
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