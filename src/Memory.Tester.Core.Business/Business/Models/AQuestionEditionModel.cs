namespace Memory.Tester.Core.Business.Business.Models;

/// <summary>
/// Abstract record which defines the common properties for question edition models.
/// </summary>
public abstract record AQuestionEditionModel
{
    /// <summary>
    /// Gets the new title of the question.
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// Gets the new answer of the question.
    /// </summary>
    public string Answer { get; init; } = string.Empty;
}
