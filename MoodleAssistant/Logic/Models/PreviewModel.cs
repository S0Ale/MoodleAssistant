using System.Xml;

namespace MoodleAssistant.Logic.Models;

/// <summary>
/// Creates all the preview data for the current merged XML file.
/// </summary>
public class PreviewModel{
    /// <summary>
    /// Gets the list of preview items.
    /// </summary>
    public List<PreviewItem> Items{ get; } = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="PreviewModel"/> class.
    /// </summary>
    /// <param name="question">The current <see cref="XmlDocument"/>.</param>
    /// <param name="answers">The current <see cref="XmlDocument"/>'s answer count.</param>
    public PreviewModel(XmlDocument question, int answers){
        GenerateItems(question, answers);
    }

    /// <summary>
    /// Generates all the preview items of a question.
    /// </summary>
    /// <param name="doc">The current <see cref="XmlDocument"/>.</param>
    /// <param name="answerCount">The current <see cref="XmlDocument"/>'s answer count.</param>
    private void GenerateItems(XmlDocument doc, int answerCount) {
        var questions = doc.GetElementsByTagName("questiontext");
        var answers = doc.GetElementsByTagName("answer");
        var e = answers.GetEnumerator();
        using var e1 = e as IDisposable;

        for (var i = 0; i < questions.Count; i++){
            var question = questions[i];
            var item = new PreviewItem(question?.SelectSingleNode("text")?.InnerText ?? string.Empty);

            var answerStrings = new string[answerCount];
            for (var j = 0; j < answerCount; j++) {
                e.MoveNext();
                var node = e.Current as XmlNode;
                answerStrings[j] = node?.SelectSingleNode("text")?.InnerText ?? string.Empty;
            }

            item.Answers = answerStrings;
            Items.Add(item);
        }
    }
}