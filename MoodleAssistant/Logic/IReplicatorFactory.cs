using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Logic.Models;

namespace MoodleAssistant.Logic;

/// <summary>
/// Defines the factory for the logic components.
/// </summary>
public interface IReplicatorFactory{
    
    /// <summary>
    /// Creates a new instance of <see cref="ITemplateModel"/>.
    /// </summary>
    /// <param name="file">The file to create the model from.</param>
    /// <returns>An instance of <see cref="ITemplateModel"/>.</returns>
    public ITemplateModel CreateTemplateModel(IBrowserFile file);
    
    /// <summary>
    /// Creates a new instance of <see cref="IAnalyzer"/>.
    /// </summary>
    /// <returns>An instance of <see cref="IAnalyzer"/>.</returns>
    public IAnalyzer CreateAnalyzer();
    
    /// <summary>
    /// Creates a new instance of <see cref="IMerger"/>.
    /// </summary>
    /// <param name="template">The template document.</param>
    /// <param name="csvAsList">The csv file contained in a <see cref="IEnumerable{T}"/></param>
    /// <returns>An instance of <see cref="IMerger"/>.</returns>
    public IMerger CreateMerger(object template, IEnumerable<string[]> csvAsList);
    
    /// <summary>
    /// Creates a new instance of <see cref="IParameterModel"/>.
    /// </summary>
    /// <param name="doc">The template document.</param>
    /// <param name="csvRows">The number of csv rows in the CSV file.</param>
    /// <returns>An instance of <see cref="IParameterModel"/>.</returns>
    public IParameterModel CreateParameterModel(object doc, int csvRows);
}