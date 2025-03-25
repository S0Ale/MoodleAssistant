using AikenDoc;

namespace MoodleAssistant.Logic.Processing.Aiken;

/// <summary>
/// Creates all the preview data for the current Aiken file.
/// </summary>
public class AikenPreviewHandler : IPreviewHandler{
    public List<PreviewItem> Items{ get; } = [];
    public void GenerateItems(object doc){
        if(doc is not AikenDocument aikenDoc) return;
        
        foreach (var question in aikenDoc.Questions){
            var answers = question.Options.Select(option => $"{option.Letter}) {option.Text}");
            answers = answers.Append($"ANSWER: {question.CorrectAnswer}");
            var item = new PreviewItem(question.Text){
                Answers = answers.ToArray()
            };
            Items.Add(item);
        }
    }
}