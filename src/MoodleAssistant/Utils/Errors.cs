using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodleAssistant.Utils
{
    public static class Errors
    {
        public const string NoErrors = "";
        public const string NullFile = "Upload a file.";
        public const string NonXmlFile = "File type must be XML.";
        public const string EmptyFile = "File cannot be empty.";
        public const string MalFormatted = "XML file is bad formed.";
        public const string ZeroOrMoreQuestions = "XML file must contains only one question.";
        public const string NoParameters = "XML quiz must contains parameters.";
    }
}
