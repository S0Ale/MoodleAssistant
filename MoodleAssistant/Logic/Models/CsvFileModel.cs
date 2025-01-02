using System.Globalization;
using System.Text;
using CsvHelper;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic.Models;

// This class is used to handle the CSV file uploaded by the user, mostly validation.
public class CsvFileModel(IBrowserFileService fileService){
    public static string FileName => "CSV";
    
    private static readonly string[] MimeTypes = ["application/vnd.ms-excel", "text/csv"];

    public IEnumerable<string> QuestionParametersList{ get; init; } = [];
    public IEnumerable<string> AnswersParametersList{ get; init; } = [];

    public static bool IsCsv(IBrowserFile file)
    {
        return MimeTypes.Contains(file.ContentType);
    }

    public bool IsEmpty()
    {
        return fileService.IsEmpty(FileName);
    }
    
    public bool HasValidHeader()
    {
        var stream = fileService.GetFile(FileName);
        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();
        var headerRow = csv.HeaderRecord ?? [];
        var questionAndAnswerList = QuestionParametersList.Concat(AnswersParametersList).Distinct().ToList();
        return headerRow.All(questionAndAnswerList.Contains) && Equals(headerRow.Length, questionAndAnswerList.Count);
    }

    public bool IsWellFormed()
    {
        var stream = fileService.GetFile(FileName);
        using var reader = new StreamReader(stream, Encoding.Default);
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

    public IEnumerable<string[]> ConvertCsvToListOfArrayString()
    {
        var csvAsList = new List<string[]>();
        
        var stream = fileService.GetFile(FileName);
        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();
        var numOfHeaders = csv.Parser.Count;
        if (csv.HeaderRecord != null) csvAsList.Add(csv.HeaderRecord);
        while (csv.Read())
        {
            var temp = new string[numOfHeaders];
            for (var i = 0; i < numOfHeaders; i++)
                temp[i] = csv.GetField<string>(i)!;
            csvAsList.Add(temp);
        }
        return csvAsList;
    }
}