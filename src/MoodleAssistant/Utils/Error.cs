using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //csv errors
        public const string NonCsvFile = "File type must be CSV.";
        public const string CsvWithoutHeaders = "One or more csv header missing.";

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
                Error.CsvWithoutHeaders => CsvWithoutHeaders,
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
        CsvWithoutHeaders
    }
}
