using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Models;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.Classes.Parse;

// This class is used to load the files uploaded by the user (save, validation).
public class Loader(IBrowserFileService fileService){
    public async Task<XmlFileModel> LoadXml(IBrowserFile file){
        var model = new XmlFileModel(fileService);
        await fileService.SaveFile(file, XmlFileModel.FileName);

        if (null == file)
            throw new ReplicatorException(Error.NullFile);
        if (!XmlFileModel.IsXml(file))
            throw new ReplicatorException(Error.NonXmlFile);
        if (IsEmpty(file))
            throw new ReplicatorException(Error.EmptyFile);
        if (await model.IsWellFormattedXml() == false)
            throw new ReplicatorException(Error.XmlBadFormed);
        if (!model.HasOnlyOneQuestion())
            throw new ReplicatorException(Error.ZeroOrMoreQuestions);
        if (!model.HasQuestionText())
            throw new ReplicatorException(Error.ZeroOrMoreQuestions);

        model.TakeParameters();
        return model;
    }

    public async Task<IEnumerable<string[]>> LoadCsv(IBrowserFile file, XmlFileModel xmlModel){
        var model = new CsvFileModel(fileService){
            QuestionParametersList = xmlModel.QuestionParametersList,
            AnswersParametersList = xmlModel.AnswerParametersList
        };
        _ = await fileService.SaveFile(file, CsvFileModel.FileName);

        if (null == file)
            throw new ReplicatorException(Error.NullFile);
        if (!CsvFileModel.IsCsv(file))
            throw new ReplicatorException(Error.NonCsvFile);
        if (IsEmpty(file))
            throw new ReplicatorException(Error.EmptyFile);
        if (await model.HasValidHeader() == false)
            throw new ReplicatorException(Error.CsvInvalidHeader);
        if (await model.IsWellFormed() == false)
            throw new ReplicatorException(Error.CsvBadFormed);

        return await model.ConvertCsvToListOfArrayString();
    }
    
    public async Task LoadFiles(IBrowserFile[] files){
        foreach (var file in files){
            var model = new FileModel();
            _ = await fileService.SaveFile(file, file.Name); 
            
            if (null == file)
                throw new ReplicatorException(Error.NullFile);
            if (IsEmpty(file))  
                throw new ReplicatorException(Error.EmptyFile);
            if (!model.IsImage(file) && !model.IsOfficeFile(file))
                throw new ReplicatorException(Error.NoValidFile);
        }
    }
    
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