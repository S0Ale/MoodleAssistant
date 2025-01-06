namespace MoodleAssistant.Logic.Utils;

/// <summary>
/// Represents an error that occurred in the replication process.
/// </summary>
/// <param name="error">The <see cref="Utils.Error"/> that occurred.</param>
public class ReplicatorException(Error error) : Exception{
    /// <summary>
    /// Gets the error.
    /// </summary>
    public Error Error{ get; } = error;
}