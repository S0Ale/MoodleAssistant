using System.Xml;

namespace MoodleAssistant.Classes.Models;

public class PreviewModel{
    public List<PreviewItem> Items{ get; } = [];
    //public IEnumerable<string> QuestPreviews; // more than 1 question is not allowed


    public PreviewModel(XmlDocument question, int answers){
        GenerateItems(question, answers);
    }

    private void GenerateItems(XmlDocument doc, int answerCount) {
        var questions = doc.GetElementsByTagName("questiontext");
        var answers = doc.GetElementsByTagName("answer");
        var e = answers.GetEnumerator();
        using var e1 = e as IDisposable;

        for (var i = 0; i < questions.Count; i++){
            var item = new PreviewItem(questions[i]?.InnerText ?? string.Empty);

            var answerStrings = new string[answerCount];
            for (var j = 0; j < answerCount; j++) {
                e.MoveNext();
                var node = e.Current as XmlNode;
                answerStrings[j] = node?.InnerText ?? string.Empty;
            }

            item.Answers = answerStrings;
            Items.Add(item);
        }
    }
}