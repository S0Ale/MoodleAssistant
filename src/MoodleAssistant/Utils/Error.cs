using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodleAssistant.Utils
{
    public static class ErrorMessage
    {
        public const string NoErrors = "";
        public const string NullFile = "Upload a file.";
        public const string NonXmlFile = "File type must be XML.";
        public const string EmptyFile = "File cannot be empty.";
        public const string MalFormatted = "XML file is bad formed.";
        public const string ZeroOrMoreQuestions = "XML file must contains only one question.";
        public const string NoParameters = "XML quiz must contains parameters.";
        public const string ZeroAnswers = "XML quiz must contains answers.";

        public static string GetErrorMessage(Error error)
        {
            switch (error)
            {
                case Error.NoErrors:
                    return NoErrors;
                    
                case Error.NullFile:
                    return NullFile;

                case Error.NonXmlFile:
                    return NonXmlFile;

                case Error.EmptyFile:
                    return EmptyFile;

                case Error.MalFormatted:
                    return MalFormatted;

                case Error.ZeroOrMoreQuestions:
                    return ZeroOrMoreQuestions;

                case Error.NoParameters:
                    return NoParameters;

                case Error.ZeroAnswers:
                    return ZeroAnswers;

                default:
                    return NoErrors;
            }
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
        ZeroAnswers
    }
}
