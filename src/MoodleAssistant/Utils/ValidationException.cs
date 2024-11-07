using System;
using static MoodleAssistant.Utils.ErrorMessage;

namespace MoodleAssistant.Utils;

public class ValidationException(Error error) : Exception(GetErrorMessage(error)) {
}
