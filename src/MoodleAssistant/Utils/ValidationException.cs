using System;
using static MoodleAssistant.Utils.ErrorMessage;

namespace MoodleAssistant.Utils;

public class ValidationException(Error error) : Exception {
    public Error Error { get; } = error;
}
