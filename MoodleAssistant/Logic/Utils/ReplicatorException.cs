namespace MoodleAssistant.Logic.Utils;

public class ReplicatorException(Error error) : Exception{
    public Error Error{ get; init; } = error;
}