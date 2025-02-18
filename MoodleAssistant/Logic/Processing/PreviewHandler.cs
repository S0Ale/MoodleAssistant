using System.Xml;

namespace MoodleAssistant.Logic.Processing;

/// <summary>
/// Creates all the preview data for the current merged XML file.
/// </summary>
public class PreviewHandler{
    /// <summary>
    /// Gets the list of preview items.
    /// </summary>
    public List<PreviewItem> Items{ get; } = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="PreviewHandler"/> class.
    /// </summary>
    /// <param name="question">The current <see cref="XmlDocument"/>.</param>
    public PreviewHandler(XmlDocument question){
        GenerateItems(question);
    }

    /// <summary>
    /// Generates all the preview items of a question.
    /// </summary>
    /// <param name="doc">The current <see cref="XmlDocument"/>.</param>
    private void GenerateItems(XmlDocument doc) {
        var questions = doc.GetElementsByTagName("question");

        for (var i = 0; i < questions.Count; i++){
            var question = questions[i];
            var item = new PreviewItem(question?.SelectSingleNode("questiontext")?.SelectSingleNode("text")?.InnerText ?? string.Empty);

            var answers = question?.SelectNodes("answer");
            if (answers != null){
                var e = answers.GetEnumerator();
                using var e1 = e as IDisposable;
            
                var answerStrings = new string[answers.Count];
                for (var j = 0; j < answers.Count; j++) {
                    e.MoveNext();
                    var node = e.Current as XmlNode;
                    answerStrings[j] = node?.SelectSingleNode("text")?.InnerText ?? string.Empty;
                }
                item.Answers = answerStrings;
            }


            Items.Add(item);
        }
    }
}