namespace MoodleAssistant.Classes.Utils;

public static class ErrorMessage
{
    // Validation errors
    //common
    private const string NoErrors = "";
    private const string NoFiles = "Missing files. Please upload your files.";
    private const string NullFile = "Upload a file.";
    private const string EmptyFile = "File cannot be empty.";
    private const string Unexpected = "An unexpected error occurred.";

    //xml errors
    private const string NonXmlFile = "File type must be XML.";
    private const string MalFormatted = "XML file is bad formed.";
    private const string ZeroOrMoreQuestions = "XML file must contains only one question.";
    private const string ZeroAnswers = "XML quiz must contains answers.";

    //csv errors
    private const string NonCsvFile = "File type must be CSV.";
    private const string CsvInvalidHeader = "Please enter a valid CSV file. Use \",\" delimiter. One or more csv header missing.";
    private const string CsvBadFormed = "Please enter a valid CSV file. Check if there are missing fields or if each row contains the same number of columns.";
    
    // file errors
    private const string NoValidFile = "Invalid file found.";
    
    // Merge errors
    private const string FileMismatch = "File names need to be equal to the names inside the CSV file.";
    
    public static string GetErrorMessage(Error error)
    {
        return error switch
        {
            Error.NoErrors => NoErrors,
            Error.NoFiles => NoFiles,
            Error.NullFile => NullFile,
            Error.Unexpected => Unexpected,
            
            Error.NonXmlFile => NonXmlFile,
            Error.EmptyFile => EmptyFile,
            Error.XmlBadFormed => MalFormatted,
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

public enum Error
{
    NoErrors,
    NoFiles,
    NullFile,
    Unexpected,
    
    NonXmlFile,
    EmptyFile,
    XmlBadFormed,
    ZeroOrMoreQuestions,
    ZeroAnswers,
    NonCsvFile,
    CsvInvalidHeader,
    CsvBadFormed,
    
    NoValidFile,
    
    FileMismatch
}