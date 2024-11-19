using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MoodleAssistant.Models;

public class PreviewModel{
    public IEnumerable<PreviewItem> Items{ get; private set; } = new List<PreviewItem>();
    //public IEnumerable<string> QuestPreviews; // more than 1 question is not allowed
    //public IEnumerable<string[]> AnsPreviews;


    public PreviewModel(XmlDocument question, int answers){
        GenerateItems(question, answers);
    }

    private void GenerateItems(XmlDocument doc, int answerCount) {
        var questions = doc.GetElementsByTagName("questiontext");
        var answers = doc.GetElementsByTagName("answer");
        var e = answers.GetEnumerator();
        using var e1 = e as IDisposable;

        for (var i = 0; i < questions.Count; i++){
            var item = new PreviewItem{ QuestionText = questions[i]?.InnerText };

            var answerStrings = new string[answerCount];
            for (var j = 0; j < answerCount; j++) {
                e.MoveNext();
                var node = e.Current as XmlNode;
                answerStrings[j] = node.InnerText;
            }

            item.Answers = answerStrings;
            var list = Items as List<PreviewItem>;
            list.Add(item);
        }
    }
}
