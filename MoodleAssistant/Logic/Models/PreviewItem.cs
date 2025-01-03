namespace MoodleAssistant.Logic.Models;

public class PreviewItem(string questionText){
    public string QuestionText{ get; } = questionText;
    public string[] Answers{ get; set; } = [];
}