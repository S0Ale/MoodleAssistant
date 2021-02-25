using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MoodleAssistant.Utils
{
    public static class ErrorMessage
    {
        //common
        public const string NoErrors = "";
        public const string NullFile = "Upload a file.";
        public const string EmptyFile = "File cannot be empty.";

        //xml errors
        public const string NonXmlFile = "File type must be XML.";
        public const string MalFormatted = "XML file is bad formed.";
        public const string ZeroOrMoreQuestions = "XML file must contains only one question.";
        public const string NoParameters = "XML quiz must contains parameters.";
        public const string ZeroAnswers = "XML quiz must contains answers.";
        public const string XmlProcessing = "Something went wrong during Xml Processing. Please try again.";

        //csv errors
        public const string NonCsvFile = "File type must be CSV.";
        public const string CsvInvalidHeader = "Please enter a valid CSV file. One or more csv header missing.";
        public const string CsvBadFormed = "Please enter a valid CSV file. Check if there are missing fields or if each row contains the same number of columns.";

        public static string GetErrorMessage(Error error)
        {
            return error switch
            {
                Error.NoErrors => NoErrors,
                Error.NullFile => NullFile,
                Error.NonXmlFile => NonXmlFile,
                Error.EmptyFile => EmptyFile,
                Error.MalFormatted => MalFormatted,
                Error.ZeroOrMoreQuestions => ZeroOrMoreQuestions,
                Error.NoParameters => NoParameters,
                Error.ZeroAnswers => ZeroAnswers,
                Error.NonCsvFile => NonCsvFile,
                Error.CsvInvalidHeader => CsvInvalidHeader,
                Error.XmlProcessing => XmlProcessing,
                Error.CsvBadFormed => CsvBadFormed,
                _ => NoErrors
            };
        }
    }

    public enum Error
    {
        NoErrors,
        NullFile,
        NonXmlFile,
        EmptyFile,
        MalFormatted,
        ZeroOrMoreQuestions,
        NoParameters,
        ZeroAnswers,
        NonCsvFile,
        CsvInvalidHeader,
        XmlProcessing,
        CsvBadFormed,
    }
}
