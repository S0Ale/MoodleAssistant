using System.Globalization;
using System.Text;
using CsvHelper;
using Microsoft.AspNetCore.Components.Forms;

namespace MoodleAssistant.Classes.Models;

public class CsvFileModel{
    public IBrowserFile CsvAnswers;
    private readonly string[] _mimeTypes = ["application/vnd.ms-excel", "text/csv"];

    public IEnumerable<string> QuestionParametersList{ get; set; }
    public IEnumerable<string> AnswersParametersList{ get; set; }

    public bool IsCsv()
    {
        return _mimeTypes.Contains(CsvAnswers.ContentType);
    }

    public bool IsEmpty()
    {
        var stream = new MemoryStream();
        CsvAnswers.OpenReadStream().CopyToAsync(stream);
        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        return streamReader.EndOfStream;
    }
    
    public bool HasValidHeader()
    {
        var stream = new MemoryStream();
        CsvAnswers.OpenReadStream().CopyToAsync(stream);
        using var streamReader = new StreamReader(stream);
        using var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();
        var headerRow = csv.HeaderRecord;
        var questionAndAnswerList = (QuestionParametersList ?? Enumerable.Empty<string>())
            .Concat(AnswersParametersList ?? Enumerable.Empty<string>()).Distinct().ToList();
        return headerRow.All(questionAndAnswerList.Contains) && Equals(headerRow.Count(), questionAndAnswerList.Count());
    }

    public bool IsWellFormed()
    {
        var stream = new MemoryStream();
        CsvAnswers.OpenReadStream().CopyToAsync(stream);
        using var streamReader = new StreamReader(stream, Encoding.Default);
        using var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();
        var numOfHeaders = csv.Parser.Count;
        while (csv.Read())
        {
            if (numOfHeaders != csv.Parser.Count)
                return false;
            for (var i = 0; i < csv.Parser.Count; i++)
                if (string.IsNullOrEmpty(csv.GetField<string>(i)))
                    return false;
        }

        return true;
    }

    public IEnumerable<string[]> ConvertCsvToListOfArrayString()
    {
        var csvAsList = new List<string[]>();
        
        var stream = new MemoryStream();
        CsvAnswers.OpenReadStream().CopyToAsync(stream);
        using var streamReader = new StreamReader(stream);
        using var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();
        var numOfHeaders = csv.Parser.Count;
        csvAsList.Add(csv.HeaderRecord);
        while (csv.Read())
        {
            var temp = new string[numOfHeaders];
            for (var i = 0; i < numOfHeaders; i++)
                temp[i] = csv.GetField<string>(i);
            csvAsList.Add(temp);
        }
        return csvAsList;
    }
}