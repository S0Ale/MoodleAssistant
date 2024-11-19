using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MoodleAssistant.Models;

public class PreviewModel{
    public IEnumerable<PreviewItem> Items{ get; private set; }
    //public IEnumerable<string> QuestPreviews; // more than 1 question is not allowed
    //public IEnumerable<string[]> AnsPreviews;


    public PreviewModel(XmlDocument question, int answers){
        Items = new List<PreviewItem>();
        GenerateItems(question, answers);
    }

    private void GenerateItems(XmlDocument doc, int answerCount) {
        var questions = doc.GetElementsByTagName("questiontext");
        var answers = doc.GetElementsByTagName("answer");
        var e = answers.GetEnumerator();

        for (int i = 0; i < questions.Count; i++){
            var item = new PreviewItem(){ QuestionText = questions[i].InnerText };

            string[] answerStrings = new string[answerCount];
            for (int j = 0; j < answerCount; j++) {
                e.MoveNext();
                answerStrings[j] = (e.Current as XmlNode).InnerText;
            }

            item.Answers = answerStrings;
            (Items as List<PreviewItem>).Add(item);
            //answerStrings[j - 1] = answers[i * j - 1].InnerText;
        }
    }
}
