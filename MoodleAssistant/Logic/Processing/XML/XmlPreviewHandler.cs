using System.Xml;

namespace MoodleAssistant.Logic.Processing.XML;

/// <summary>
/// Creates all the preview data for the current XML file.
/// </summary>
public class XmlPreviewHandler : IPreviewHandler{
    /// <inheritdoc/>
    public List<PreviewItem> Items{ get; } = [];

    /// <inheritdoc/>
    public void GenerateItems(object doc){
        if(doc is not XmlDocument xmlDocument) return;
        var questions = xmlDocument.GetElementsByTagName("question");

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