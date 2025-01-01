using System.Xml;

namespace MoodleAssistant.Classes.Models;

public class PreviewModel{
    public List<PreviewItem> Items{ get; } = [];

    public PreviewModel(XmlDocument question, int answers){
        GenerateItems(question, answers);
    }

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