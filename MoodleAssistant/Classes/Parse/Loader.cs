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
            throw new ReplicatorException(Error.NullFile);
        if (!XmlFileModel.IsXml(file))
            throw new ReplicatorException(Error.NonXmlFile);
        if (model.IsEmpty())
            throw new ReplicatorException(Error.EmptyFile);
        if (!model.IsWellFormattedXml())
            throw new ReplicatorException(Error.XmlBadFormed);
        if (!model.HasOnlyOneQuestion())
            throw new ReplicatorException(Error.ZeroOrMoreQuestions);
        if (!model.HasQuestionText())
            throw new ReplicatorException(Error.ZeroOrMoreQuestions);

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
            throw new ReplicatorException(Error.NullFile);
        if (!CsvFileModel.IsCsv(file))
            throw new ReplicatorException(Error.NonCsvFile);
        if (model.IsEmpty())
            throw new ReplicatorException(Error.EmptyFile);
        if (!model.HasValidHeader())
            throw new ReplicatorException(Error.CsvInvalidHeader);
        if (!model.IsWellFormed())
            throw new ReplicatorException(Error.CsvBadFormed);

        return model.ConvertCsvToListOfArrayString();
    }
    
    public async Task LoadFiles(IBrowserFile[] files){
        foreach (var file in files){
            var model = new FileModel(fileService, file.Name);
            _ = await fileService.SaveFile(file, file.Name); 
            
            if (null == file)
                throw new ReplicatorException(Error.NullFile);
            if (model.IsEmpty())  
                throw new ReplicatorException(Error.EmptyFile);
            if (!model.IsImage(file))
                throw new ReplicatorException(Error.NoImage);
        }
    }
}