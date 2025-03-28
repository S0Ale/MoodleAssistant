﻿namespace MoodleAssistant.Logic.Utils;

/// <summary>
/// Contains error messages for the application.
/// </summary>
public static class ErrorMessage
{
    // Validation errors
    //common
    private const string NoErrors = "";
    private const string NoFiles = "Missing files. Please upload your files.";
    private const string NullFile = "Upload a file.";
    private const string EmptyFile = "File cannot be empty.";
    private const string Unexpected = "An unexpected error occurred. Try reloading the page.";
    private const string FileTooBig = "File is too big. File size must be less than 10MB.";

    //template errors
    private const string NonXmlFile = "File type must be XML.";
    private const string NonAikenFile = "File type must be Aiken.";
    private const string AikenWithFile = "Aiken file cannot have file-type parameters.";
    private const string AnswerTooMuchParams = "Aiken file cannot have more than one parameter as the correct answer.";
    private const string TemplateBadFormed = "Template file is bad formed.";
    private const string ZeroOrMoreQuestions = "Template file must contains only one question.";
    private const string ZeroAnswers = "XML quiz must contains answers.";

    //csv errors
    private const string NonCsvFile = "File type must be CSV.";
    private const string CsvInvalidHeader = "Please enter a valid CSV file. Use \",\" delimiter. One or more csv header missing.";
    private const string CsvBadFormed = "Please enter a valid CSV file. Check if there are missing fields or if each row contains the same number of columns.";
    
    // file errors
    private const string NoValidFile = "Invalid file found.";
    
    // Merge errors
    private const string FileMismatch = "File names need to be equal to the names inside the CSV file.";

    /// <summary>
    /// Returns the error message based on the error code.
    /// </summary>
    /// <param name="error">The <see cref="Error"/> that occurred.</param>
    /// <returns>The string matching with the specified <see cref="Error"/>.</returns>
    public static string GetErrorMessage(Error error)
    {
        return error switch
        {
            Error.NoErrors => NoErrors,
            Error.NoFiles => NoFiles,
            Error.NullFile => NullFile,
            Error.Unexpected => Unexpected,
            Error.FileTooBig => FileTooBig,
            
            Error.NonXmlFile => NonXmlFile,
            Error.NonAikenFile => NonAikenFile,
            Error.AikenWithFile => AikenWithFile,
            Error.AnswerTooMuchParams => AnswerTooMuchParams,
            Error.EmptyFile => EmptyFile,
            Error.TemplateBadFormed => TemplateBadFormed,
            Error.ZeroOrMoreQuestions => ZeroOrMoreQuestions,
            Error.ZeroAnswers => ZeroAnswers,
            Error.NonCsvFile => NonCsvFile,
            Error.CsvInvalidHeader => CsvInvalidHeader,
            Error.CsvBadFormed => CsvBadFormed,
            Error.NoValidFile => NoValidFile,
            
            Error.FileMismatch => FileMismatch,
            
            _ => NoErrors
        };
    }
}
