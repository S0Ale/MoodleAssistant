using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Models;
using MoodleAssistant.Classes.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.Classes.Parse;

public class Loader(IBrowserFileService fileService){
    public async Task<XmlFileModel?> LoadXml(IBrowserFile file){
        var model = new XmlFileModel(fileService);
        await fileService.SaveFile(file, XmlFileModel.FileName);

        if (null == file)
            throw new ValidationException(Error.NullFile);
        if (!XmlFileModel.IsXml(file))
            throw new ValidationException(Error.NonXmlFile);
        if (model.IsEmpty())
            throw new ValidationException(Error.EmptyFile);
        if (!model.IsWellFormattedXml())
            throw new ValidationException(Error.XmlBadFormed);
        if (!model.HasOnlyOneQuestion())
            throw new ValidationException(Error.ZeroOrMoreQuestions);
        if (!model.HasQuestionText())
            throw new ValidationException(Error.ZeroOrMoreQuestions);

        model.TakeParameters();
        return model;
    }

    public async Task<IEnumerable<string[]>> LoadCsv(IBrowserFile file, XmlFileModel? xmlModel){
        var model = new CsvFileModel(fileService){
            QuestionParametersList = xmlModel.QuestionParametersList,
            AnswersParametersList = xmlModel.AnswerParametersList
        };
        _ = await fileService.SaveFile(file, CsvFileModel.FileName);

        if (null == file)
            throw new ValidationException(Error.NullFile);
        if (!CsvFileModel.IsCsv(file))
            throw new ValidationException(Error.NonCsvFile);
        if (model.IsEmpty())
            throw new ValidationException(Error.EmptyFile);
        if (!model.HasValidHeader())
            throw new ValidationException(Error.CsvInvalidHeader);
        if (!model.IsWellFormed())
            throw new ValidationException(Error.CsvBadFormed);

        return model.ConvertCsvToListOfArrayString();
    }
    
    public async Task LoadFiles(IBrowserFile[] files){
        foreach (var file in files){
            _ = await fileService.SaveFile(file, file.Name); 
        }
    }
}