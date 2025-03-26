using AikenDoc;
using MoodleAssistant.Logic.Parse;

namespace MoodleAssistant.Logic.Processing.Aiken;

/// <summary>
/// Manager for the parameters of the Aiken document.
/// </summary>
public class AikenParameterHandler : ParameterHandler{
    
    /// <summary>
    /// Initializes a new instance of <see cref="AikenParameterHandler"/>.
    /// </summary>
    /// <param name="doc">A <see cref="AikenDocument"/> instance.</param>
    /// <param name="csvRows">The number of csv rows in the CSV file.</param>
    public AikenParameterHandler(AikenDocument doc, int csvRows) : base(csvRows){
        var question = doc.Questions.First();
        Param = new ParameterParser(question.GetAllText()).Match() as List<Parameter>;
    }
}