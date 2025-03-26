using AikenDoc;
using MoodleAssistant.Logic.Parse;
using MoodleAssistant.Services;

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
            var parser = new ParameterParser(newQuestion!.Text);
            var parameterList = parser.Match() as List<Parameter> ?? [];
            foreach (var parameter in parameterList){
                parameter.Replacement = !previewMode ? FindInCsv(csvAsList, j, parameter.Name) : 
                    $"<span class=\"code\">[{FindInCsv(csvAsList, j, parameter.Name)}]</span>";
            }
            newQuestion.Text = parser.Replace(parameterList);
            
            // Look in the options for parameters
            foreach (var option in newQuestion.Options){
                parser = new ParameterParser(option.Text);
                parameterList = parser.Match() as List<Parameter> ?? [];
                foreach (var parameter in parameterList){
                    parameter.Replacement = !previewMode ? FindInCsv(csvAsList, j, parameter.Name) : 
                        $"<span class=\"code\">[{FindInCsv(csvAsList, j, parameter.Name)}]</span>";
                }
                option.Text = parser.Replace(parameterList);
            }
            
            // Look into the correct answer for params
            parser = new ParameterParser(newQuestion.CorrectAnswer ?? "");
            parameterList = parser.Match() as List<Parameter> ?? [];
            foreach (var parameter in parameterList){
                parameter.Replacement = !previewMode ? FindInCsv(csvAsList, j, parameter.Name) :
                    $"<span class=\"code\">[{FindInCsv(csvAsList, j, parameter.Name)}]</span>";
            }
            newQuestion.CorrectAnswer = parser.Replace(parameterList);
            
            merged.AppendQuestion(newQuestion);
        }

        return merged;
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