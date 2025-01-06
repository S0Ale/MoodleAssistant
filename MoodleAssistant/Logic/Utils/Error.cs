namespace MoodleAssistant.Logic.Utils;

/// <summary>
/// Represents an error that occurred in the replication process.
/// </summary>
public enum Error{
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