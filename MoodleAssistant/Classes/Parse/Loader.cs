using MoodleAssistant.Classes.Models;
using MoodleAssistant.Classes.Utils;

namespace MoodleAssistant.Classes.Parse;

public class Loader{
    public XmlFileModel LoadXml(IFormFile file){
        var model = new XmlFileModel{ XmlQuestion = file };

        if (null == file)
            throw new ValidationException(Error.NullFile);
        if (!model.IsXml())
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

    public IEnumerable<string[]> LoadCsv(IFormFile file, XmlFileModel xmlModel){
        var model = new CsvFileModel{
            CsvAnswers = file,
            QuestionParametersList = xmlModel.QuestionParametersList,
            AnswersParametersList = xmlModel.AnswerParametersList
        };

        if (null == file)
            throw new ValidationException(Error.NullFile);
        if (!model.IsCsv())
            throw new ValidationException(Error.NonCsvFile);
        if (model.IsEmpty())
            throw new ValidationException(Error.EmptyFile);
        if (!model.HasValidHeader())
            throw new ValidationException(Error.CsvInvalidHeader);
        if (!model.IsWellFormed())
            throw new ValidationException(Error.CsvBadFormed);

        return model.ConvertCsvToListOfArrayString();
    }
}