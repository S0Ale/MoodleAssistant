using System.Xml;

namespace MoodleAssistant.Logic;

/// <summary>
/// Manage the merge process of the questions.
/// </summary>
public interface IMerger{
    /// <summary>
    /// Creates a document with the replicated questions using the template file and the CSV file to find the parameter values.
    /// </summary>
    /// <param name="previewMode">Whether the merge process is executing in preview mode or not.</param>
    /// <returns>The merged document.</returns>
    public object MergeQuestion(bool previewMode = false);
}