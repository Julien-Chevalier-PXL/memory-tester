namespace Memory.Tester.Core.Business.Business.ViewModels;

/// <summary>
/// Record representing the view model for a question.
/// </summary>
public record QuestionViewModel
{
    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the title of the question.
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// Gets the answer of the question.
    /// </summary>
    public string Answer { get; init; } = string.Empty;
}
