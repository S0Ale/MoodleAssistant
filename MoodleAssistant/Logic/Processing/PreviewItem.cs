namespace MoodleAssistant.Logic.Processing;

/// <summary>
/// Represents a preview item of a question tag (inside the merged XML file), with its question text and answers.
/// </summary>
/// <param name="questionText">The question text <see cref="string"/>.</param>
public class PreviewItem(string questionText){
    /// <summary>
    /// Gets the question text.
    /// </summary>
    public string QuestionText{ get; } = questionText;
    /// <summary>
    /// Gets or sets the answers.
    /// </summary>
    public string[] Answers{ get; set; } = [];
}