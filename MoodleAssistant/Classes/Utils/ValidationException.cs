namespace MoodleAssistant.Classes.Utils;

public class ValidationException(Error error) : Exception{
    public Error Error { get; } = error;
}