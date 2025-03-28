﻿namespace MoodleAssistant.Logic.Utils;

/// <summary>
/// Represents an error that occurred in the replication process.
/// </summary>
public enum Error{
    /// <summary>
    /// No errors occurred.
    /// </summary>
    NoErrors,
    
    /// <summary>
    /// No files were uploaded.
    /// </summary>
    NoFiles,
    
    /// <summary>
    /// Uploaded files are null.
    /// </summary>
    NullFile,
    
    /// <summary>
    /// An unexpected error occurred.
    /// </summary>
    Unexpected,
        
    /// <summary>
    /// The uploaded file is not a valid XML file.
    /// </summary>
    NonXmlFile,
    
    /// <summary>
    /// The uploaded file is not a valid Aiken file.
    /// </summary>
    NonAikenFile,
    
    /// <summary>
    /// The uploaded Aiken file cannot have file-ype parameters.
    /// </summary>
    AikenWithFile,
    
    /// <summary>
    /// The uploaded Aiken file cannot have more than one parameter.
    /// </summary>
    AnswerTooMuchParams,
    
    /// <summary>
    /// The uploaded file is empty.
    /// </summary>
    EmptyFile,
    
    /// <summary>
    /// The uploaded file is too big.
    /// </summary>
    FileTooBig,
    
    /// <summary>
    /// The uploaded template file is not well-formatted.
    /// </summary>
    TemplateBadFormed,
    
    /// <summary>
    /// The uploaded template file has zero or more than one question.
    /// </summary>
    ZeroOrMoreQuestions,
    
    /// <summary>
    /// The uploaded XML file has no answers.
    /// </summary>
    ZeroAnswers,
    
    /// <summary>
    /// The uploaded file is not a valid CSV file.
    /// </summary>
    NonCsvFile,
    
    /// <summary>
    /// The uploaded CSV file has not a valid header.
    /// </summary>
    CsvInvalidHeader,
    
    /// <summary>
    /// The uploaded CSV file is not well-formed.
    /// </summary>
    CsvBadFormed,
        
    /// <summary>
    /// The uploaded file is not a valid image/MS-Office file.
    /// </summary>
    NoValidFile,
        
    /// <summary>
    /// The uploaded files names or quantity do not match the values inside the CSV file.
    /// </summary>
    FileMismatch
}
