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
    
    private async Task<StreamReader> GetReaderAsync(IBrowserFile file, Encoding? encoding){
        var stream = new MemoryStream();
        await file.OpenReadStream().CopyToAsync(stream);
        stream.Position = 0;
        return encoding == null ? new StreamReader(stream) : new StreamReader(stream, encoding);
    }

    public bool IsCsv()
    {
        return _mimeTypes.Contains(CsvAnswers.ContentType);
    }

    public async Task<bool> IsEmpty()
    {
        using var reader = await GetReaderAsync(CsvAnswers, Encoding.UTF8);
        return reader.EndOfStream;
    }
    
    public async Task<bool> HasValidHeader()
    {
        using var reader = await GetReaderAsync(CsvAnswers, null);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();
        var headerRow = csv.HeaderRecord;
        var questionAndAnswerList = (QuestionParametersList ?? Enumerable.Empty<string>())
            .Concat(AnswersParametersList ?? Enumerable.Empty<string>()).Distinct().ToList();
        return headerRow.All(questionAndAnswerList.Contains) && Equals(headerRow.Count(), questionAndAnswerList.Count());
    }

    public async Task<bool> IsWellFormed()
    {
        using var reader = await GetReaderAsync(CsvAnswers, Encoding.Default);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
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

    public async Task<IEnumerable<string[]>> ConvertCsvToListOfArrayString()
    {
        var csvAsList = new List<string[]>();
        
        using var reader = await GetReaderAsync(CsvAnswers, null);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
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