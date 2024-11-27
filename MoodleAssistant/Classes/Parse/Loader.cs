using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Classes.Models;
using MoodleAssistant.Classes.Utils;

namespace MoodleAssistant.Classes.Parse;

public class Loader(){
    public async Task<XmlFileModel> LoadXml(IBrowserFile file){
        var model = new XmlFileModel{ XmlQuestion = file };

        if (null == file)
            throw new ValidationException(Error.NullFile);
        if (!model.IsXml())
            throw new ValidationException(Error.NonXmlFile);
        if (await model.IsEmpty())
            throw new ValidationException(Error.EmptyFile);
        if (!(await model.IsWellFormattedXml()))
            throw new ValidationException(Error.XmlBadFormed);
        if (!model.HasOnlyOneQuestion())
            throw new ValidationException(Error.ZeroOrMoreQuestions);
        if (!model.HasQuestionText())
            throw new ValidationException(Error.ZeroOrMoreQuestions);

        model.TakeParameters();
        return model;
    }

    public async Task<IEnumerable<string[]>> LoadCsv(IBrowserFile file, XmlFileModel xmlModel){
        var model = new CsvFileModel{
            CsvAnswers = file,
            QuestionParametersList = xmlModel.QuestionParametersList,
            AnswersParametersList = xmlModel.AnswerParametersList
        };

        if (null == file)
            throw new ValidationException(Error.NullFile);
        if (!model.IsCsv())
            throw new ValidationException(Error.NonCsvFile);
        if (await model.IsEmpty())
            throw new ValidationException(Error.EmptyFile);
        if (!(await model.HasValidHeader()))
            throw new ValidationException(Error.CsvInvalidHeader);
        if (!(await model.IsWellFormed()))
            throw new ValidationException(Error.CsvBadFormed);

        return await model.ConvertCsvToListOfArrayString();
    }
}