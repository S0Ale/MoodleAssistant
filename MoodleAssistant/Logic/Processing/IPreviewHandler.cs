namespace MoodleAssistant.Logic.Processing;

/// <summary>
/// Creates all the preview data for the current merged file.
/// </summary>
public interface IPreviewHandler{
    /// <summary>
    /// Gets the list of preview items.
    /// </summary>
    public List<PreviewItem> Items{ get; }
    
    /// <summary>
    /// Generates all the preview items of a question.
    /// </summary>
    /// <param name="doc">The question document.</param>
    public void GenerateItems(object doc);
}