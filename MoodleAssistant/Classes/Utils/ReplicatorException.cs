namespace MoodleAssistant.Classes.Utils;

public class ReplicatorException(Error error) : Exception{
    public Error Error{ get; init; } = error;
}