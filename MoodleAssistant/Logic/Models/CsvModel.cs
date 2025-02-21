using System.Globalization;
using System.Text;
using CsvHelper;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Utils;
using MoodleAssistant.Services;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Manages the validation of a CSV file and other operations.
/// </summary>
/// <param name="file">The instance of <see cref="IBrowserFile"/> representing the file to validate.</param>
/// <param name="fileService">An instance of <see cref="IBrowserFileService"/> to manage saved files.</param>
public class CsvModel(IBrowserFile file, IBrowserFileService fileService) : IValidationModel{
    /// <summary>
    /// The standard name of the XML file managed by the <see cref="CsvModel"/>.
    /// </summary>
    public static string FileName => "CSV";
    
    /// <summary>
    /// A list of supported CSV MIME types.
    /// </summary>
    private static readonly string[] MimeTypes = ["application/vnd.ms-excel", "text/csv"];
    
    /// <summary>
    /// Gets the parameters found in the question text
    /// </summary>
    public IEnumerable<string> QuestionParametersList{ get; init; } = [];
    
    /// <summary>
    /// Gets the parameters found in the answers.
    /// </summary>
    public IEnumerable<string> AnswersParametersList{ get; init; } = [];

    /// <summary>
    /// Checks if the <see cref="IBrowserFile.ContentType"/> of a file is CSV.
    /// </summary>
    /// <param name="file">An instance of <see cref="IBrowserFile"/> representing the file.</param>
    /// <returns><c>true</c> if the file is CSV; otherwise <c>false</c>.</returns>
    private static bool IsCsv(IBrowserFile file)
    {
        return MimeTypes.Contains(file.ContentType);
    }
    
    /// <summary>
    /// Checks if the file with the <see cref="CsvModel"/>'s file name has a valid header.
    /// </summary>
    /// <returns><c>true</c> if the file as a valid header; otherwise <c>false</c>.</returns>
    private async Task<bool> HasValidHeader()
    {
        var stream = await fileService.GetFile(FileName);
        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        await csv.ReadAsync();
        csv.ReadHeader();
        var headerRow = csv.HeaderRecord ?? [];
        var questionAndAnswerList = QuestionParametersList.Concat(AnswersParametersList).Distinct().ToList();
        return headerRow.All(questionAndAnswerList.Contains) && Equals(headerRow.Length, questionAndAnswerList.Count);
    }

    /// <summary>
    /// Checks if the file with the <see cref="CsvModel"/>'s file name is well-formed.
    /// </summary>
    /// <returns><c>true</c> if the file is well-formed; otherwise <c>false</c>.</returns>
    private async Task<bool> IsWellFormed()
    {
        var stream = await fileService.GetFile(FileName);
        using var reader = new StreamReader(stream, Encoding.Default);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        await csv.ReadAsync();
        csv.ReadHeader();
        var numOfHeaders = csv.Parser.Count;
        while (await csv.ReadAsync())
        {
            if (numOfHeaders != csv.Parser.Count)
                return false;
            for (var i = 0; i < csv.Parser.Count; i++)
                if (string.IsNullOrEmpty(csv.GetField<string>(i)))
                    return false;
        }

        return true;
    }

    /// <summary>
    /// Converts the CSV file to a list of string arrays.
    /// </summary>
    /// <returns>A list of string arrays representing the parameters' values.</returns>
    public async Task<IEnumerable<string[]>> ConvertCsvToListOfArrayString()
    {
        var csvAsList = new List<string[]>();
        
        var stream = await fileService.GetFile(FileName);
        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        await csv.ReadAsync();
        csv.ReadHeader();
        var numOfHeaders = csv.Parser.Count;
        if (csv.HeaderRecord != null) csvAsList.Add(csv.HeaderRecord);
        while (await csv.ReadAsync())
        {
            var temp = new string[numOfHeaders];
            for (var i = 0; i < numOfHeaders; i++)
                temp[i] = csv.GetField<string>(i)!;
            csvAsList.Add(temp);
        }
        return csvAsList;
    }

    /// <inheritdoc/>
    public async Task Validate(){
        if (!IsCsv(file))
            throw new ReplicatorException(Error.NonCsvFile);
        if (!await HasValidHeader())
            throw new ReplicatorException(Error.CsvInvalidHeader);
        if (!await IsWellFormed())
            throw new ReplicatorException(Error.CsvBadFormed);
    }
}