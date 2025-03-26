using AikenDoc;
using MoodleAssistant.Logic.Parse;

namespace MoodleAssistant.Logic.Processing.Aiken;

/// <summary>
/// Represents a class that merges the template Aiken file with the CSV file to create a new Aiken file.
/// </summary>
/// <param name="template">The <see cref="AikenDocument"/> of the template question.</param>
/// <param name="csvAsList">The CSV file as a list of string arrays.</param>
public class AikenMerger(AikenDocument template, IEnumerable<string[]> csvAsList) : IMerger{
    
    /// <inheritdoc/>
    public object MergeQuestion(bool previewMode = false){
        var merged = (template.Clone() as AikenDocument)!;
        
        // Get the template question element, removing it from the document
        var question = merged.Questions.First();
        merged.Questions.Remove(question);
        
        for (var j = 1; j < csvAsList.Count(); j++){
            var newQuestion = question.Clone() as AikenQuestion;
            // Replace into the question text
            newQuestion!.Text = ReplaceParameters(newQuestion.Text, previewMode, j);
            
            // Replace into the options' text
            foreach (var option in newQuestion.Options)
                option.Text = ReplaceParameters(option.Text, previewMode, j);
            
            // Replace into the correct answer
            newQuestion.CorrectAnswer = ReplaceParameters(newQuestion.CorrectAnswer!, previewMode, j);
              
            merged.AppendQuestion(newQuestion);
        }

        return merged;
    }

    /// <summary>
    /// Replace the parameters in the input string with the values from the CSV file.
    /// </summary>
    /// <param name="input">The input string to replace the parameters in.</param>
    /// <param name="previewMode">Weather the method is in preview mode or not.</param>
    /// <param name="rowIndex"> The index of the row in the CSV file to use.</param>
    /// <returns> The input string with the parameters replaced.</returns>
    private string ReplaceParameters(string input, bool previewMode, int rowIndex){
        var parser = new ParameterParser(input);
        var parameterList = parser.Match() as List<Parameter> ?? [];

        foreach (var parameter in parameterList){
            parameter.Replacement = !previewMode
                ? FindInCsv(csvAsList, rowIndex, parameter.Name)
                : $"<span class=\"code\">[{FindInCsv(csvAsList, rowIndex, parameter.Name)}]</span>";
        }

        return parser.Replace(parameterList);
    }

    /// <summary>
    /// Finds the value of a parameter in the CSV file.
    /// </summary>
    /// <param name="csv">The contents of the csv file.</param>
    /// <param name="i">Index of the corresponding csv line.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>The value associated with the specified parameter name.</returns>
    /// <exception cref="KeyNotFoundException">Parameter name is not present in the csv.</exception>
    private static string FindInCsv(IEnumerable<string[]> csv, int i, string paramName){
        var stringsEnumerable = csv.ToList();
        var headerRow = stringsEnumerable.ElementAt(0);
        var index = Array.IndexOf(headerRow, paramName);
        if (index == -1) throw new KeyNotFoundException();
        return stringsEnumerable.ElementAt(i)[index];
    }
}